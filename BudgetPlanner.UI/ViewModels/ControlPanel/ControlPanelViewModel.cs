using Android.Content;
using Android.Webkit;
using BudgetPlanner.Core.Models.CashFlows;
using BudgetPlanner.Core.Services.Db;
using BudgetPlanner.UI.Helpers;
using BudgetPlanner.UI.Models.CashFlows;
using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Android.Content.ClipData;

namespace BudgetPlanner.UI.ViewModels.ControlPanel
{
    public partial class ControlPanelViewModel : ObservableObject
    {
        readonly private INavigationService _navigationService;
        readonly private IRemoteDatabaseConnectionService _remoteDatabaseConnectionService;
        readonly private CashFlowMapper _cashFlowMapper;

        private List<CashFlow> _bufor = new List<CashFlow>();

        [ObservableProperty]
        public ObservableCollection<CashFlow> items;

        [ObservableProperty]
        private DateTime currentDate;

        [ObservableProperty]
        private bool isNextButtonVisible;

        [ObservableProperty]
        private bool isPreviousButtonVisible;

        [ObservableProperty]
        private bool areAddButtonsVisible;

        [ObservableProperty]
        public bool isListVisible;

        [ObservableProperty]
        public bool isErrorVisible;

        public ControlPanelViewModel(INavigationService navigationService, IRemoteDatabaseConnectionService remoteDatabaseConnectionService, CashFlowMapper cashFlowMapper)
        {
            _navigationService = navigationService;
            _remoteDatabaseConnectionService = remoteDatabaseConnectionService;
            _cashFlowMapper = cashFlowMapper;

            CurrentDate = DateTime.Today;

            Task.Run(async() =>
            {
                await FetchItems();
                UpdateNavigationButtonsState();
            });

            AreAddButtonsVisible = false;
        }

        private void UpdateNavigationButtonsState()
        {
            if(CurrentDate.Month == _bufor.Last().Date.Month)
            {
                IsPreviousButtonVisible = false;
            } else
            {
                IsPreviousButtonVisible = true;
            }
        }

        async Task FetchItems()
        {
            var result = await _remoteDatabaseConnectionService.GetItems();
            List<CashFlow> sortedItems = new List<CashFlow>();

            foreach (var item in result)
            {
                sortedItems.Add(_cashFlowMapper.FromDto(item));
            }

            sortedItems = ListExtensions.SortCashFlowsDescending(sortedItems);

            _bufor = sortedItems;

            Items = new ObservableCollection<CashFlow>();

            _bufor.ForEach(Items.Add);
            SortCashFlowsByDate();

            IsErrorVisible = !_bufor.Any() ? true : false;
            IsListVisible = _bufor.Any() ? true : false;
        }

        [RelayCommand]
        public void GetPreviousMonth()
        {
            CurrentDate = CurrentDate.AddMonths(-1);
            IsNextButtonVisible = true;

            SortCashFlowsByDate();
            UpdateNavigationButtonsState();
        }

        [RelayCommand]
        public void GetNextMonth()
        {
            CurrentDate = CurrentDate.AddMonths(1);

            if(CurrentDate.Month == DateTime.Now.Month)
            {
                IsNextButtonVisible = false;
            }

            SortCashFlowsByDate();
            UpdateNavigationButtonsState();
        }

        [RelayCommand]
        public void OpenCashFlowTypeSelector()
        {
            AreAddButtonsVisible = !AreAddButtonsVisible;
        }

        [RelayCommand]
        public void NavigateToFormAddIncome()
        {
            NavigateToForm(CashFlowType.Przychody);
        }

        [RelayCommand]
        public void NavigateToFormAddExpense()
        {
            NavigateToForm(CashFlowType.Koszty);
        }

        [RelayCommand]
        public void NavigateToChart()
        {
            _navigationService.Navigation.PushAsync(new ChartPage(new Chart.ChartViewModel(), Items.ToList()), true);
        }

        private void NavigateToForm(CashFlowType cashFlowType)
        {
            _navigationService.Navigation.PushAsync(new CashFlowFormPage(new CashFlowForm.CashFlowFormViewModel(_navigationService, _remoteDatabaseConnectionService, cashFlowType)));
        }

        private void SortCashFlowsByDate()
        {
            List<CashFlow> sortedCashFlows = new List<CashFlow>();

            foreach(var cashFlow in _bufor)
            {
                if(cashFlow.Date.Month == CurrentDate.Month)
                {
                    sortedCashFlows.Add(cashFlow);
                }
            }

            Items = new ObservableCollection<CashFlow>(sortedCashFlows);
        }
    }
}
