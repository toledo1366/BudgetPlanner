using Android.Content;
using Android.Webkit;
using BudgetPlanner.Core.Models.CashFlows;
using BudgetPlanner.Core.Services.Db;
using BudgetPlanner.UI.Models.CashFlows;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels.ControlPanel
{
    public partial class ControlPanelViewModel : ObservableObject
    {
        readonly private IRemoteDatabaseConnectionService _remoteDatabaseConnectionService;

        [ObservableProperty]
        public ObservableCollection<CashFlow> items;

        public ControlPanelViewModel(IRemoteDatabaseConnectionService remoteDatabaseConnectionService) 
        {
            _remoteDatabaseConnectionService = remoteDatabaseConnectionService;
        }

        [RelayCommand]
        private void AddEntity()
        {
            Console.WriteLine("Przycisk działa.");

            //CashFlowDTO xxx = new CashFlowDTO
            //{
            //    Name = "Opłaty",
            //    Price = 9.99,
            //    Date = DateTime.Now.ToLongDateString(),
            //    CashFlowType = 2
            //};

            //_remoteDatabaseConnectionService.PostItem(xxx);

            _remoteDatabaseConnectionService.GetItems();
        }
    }
}
