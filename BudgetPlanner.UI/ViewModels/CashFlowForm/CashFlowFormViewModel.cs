using Android.Accounts;
using BudgetPlanner.Core.Models.CashFlows;
using BudgetPlanner.Core.Services.Db;
using BudgetPlanner.UI.Models.CashFlows;
using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Javax.Security.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels.CashFlowForm
{
    public partial class CashFlowFormViewModel:ObservableObject
    {
        readonly private INavigationService _navigationService;
        readonly private IRemoteDatabaseConnectionService _remoteDatabaseConnectionService;

        [ObservableProperty]
        private string name;

        [ObservableProperty]
        private DateTime date;

        [ObservableProperty]
        private double amount;

        [ObservableProperty]
        public CashFlowType cashFlowType;

        [ObservableProperty]
        public string title;

        [ObservableProperty]
        public List<string> categories;

        [ObservableProperty]
        public string selectedCategory;

        public CashFlowFormViewModel(INavigationService navigationService, IRemoteDatabaseConnectionService remoteDatabaseConnectionService, CashFlowType type)
        {
            _navigationService = navigationService;
            _remoteDatabaseConnectionService = remoteDatabaseConnectionService;

            CashFlowType = type;
            Categories = new List<string>();

            if(type == CashFlowType.Koszty)
            {
                foreach(int category in Enum.GetValues(typeof(ExpenseCategory)))
                {
                    var enumItem = Enum.GetName(typeof(ExpenseCategory), category);
                    Categories.Add(enumItem);
                }
            }
            else
            {
                foreach (int category in Enum.GetValues(typeof(IncomeCategory)))
                {
                    var enumItem = Enum.GetName(typeof(IncomeCategory), category);
                    Categories.Add(enumItem);
                }
            }

            Title = CashFlowType == CashFlowType.Koszty ? "Dodaj koszt" : "Dodaj przychód";
            Date = DateTime.Today;
        }

        [RelayCommand]
        private void AddEntity()
        {
            int categoryIndex = Categories.IndexOf(SelectedCategory);

            CashFlowDTO cashFlow = new CashFlowDTO
            {
                Name = Name,
                Price = Amount,
                Date = Date.ToString(),
                CashFlowType = (int)CashFlowType,
                IncomeCategory = CashFlowType == CashFlowType.Przychody ? categoryIndex : null,
                ExpenseCategory = CashFlowType == CashFlowType.Koszty ? categoryIndex : null,
            };

            _remoteDatabaseConnectionService.PostItem(cashFlow);

            _navigationService.Navigate<ControlPanelPage>();
        }
    }

}
