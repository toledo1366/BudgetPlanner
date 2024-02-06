using Android.Accounts;
using BudgetPlanner.Core.Models.CashFlows;
using BudgetPlanner.Core.Services.Db;
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



        public CashFlowFormViewModel(INavigationService navigationService, IRemoteDatabaseConnectionService remoteDatabaseConnectionService)
        {
            
            _navigationService = navigationService;
            _remoteDatabaseConnectionService = remoteDatabaseConnectionService;
          
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
