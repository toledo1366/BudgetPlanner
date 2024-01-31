using Android.Accounts;
using BudgetPlanner.Core.Models.CashFlows;
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

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        private DateTime date;

        [ObservableProperty]
        private double amount;

        public CashFlowFormViewModel(INavigationService navigationService)
        {
            
            _navigationService = navigationService;

          
        }

        [RelayCommand]
        private void AddEntity()
        {
            Console.WriteLine("Przycisk działa.");

            CashFlowDTO xxx = new CashFlowDTO
            {
                Name = "Opłaty",
                Price = 9.99,
                Date = DateTime.Now.ToLongDateString(),
                CashFlowType = 2
            };

            _remoteDatabaseConnectionService.PostItem(xxx);

            //_remoteDatabaseConnectionService.GetItems();
        }
    }

}
