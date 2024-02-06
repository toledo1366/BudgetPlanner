using Android.Content;
using Android.Webkit;
using BudgetPlanner.Core.Models.CashFlows;
using BudgetPlanner.Core.Services.Db;
using BudgetPlanner.UI.Helpers;
using BudgetPlanner.UI.Models.CashFlows;
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

        public ControlPanelViewModel(IRemoteDatabaseConnectionService remoteDatabaseConnectionService, CashFlowMapper cashFlowMapper)
        {
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
            }

            if (CurrentDate.Month == DateTime.Now.Month)
            {
                IsPreviousButtonVisible = true;
                IsNextButtonVisible = false;
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
