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
using static Android.Content.ClipData;

namespace BudgetPlanner.UI.ViewModels.ControlPanel
{
    public partial class ControlPanelViewModel : ObservableObject
    {
        readonly private IRemoteDatabaseConnectionService _remoteDatabaseConnectionService;
        readonly private CashFlowMapper _cashFlowMapper;

        [ObservableProperty]
        public ObservableCollection<CashFlow> items;

        public ControlPanelViewModel(IRemoteDatabaseConnectionService remoteDatabaseConnectionService, CashFlowMapper cashFlowMapper)
        {
            _remoteDatabaseConnectionService = remoteDatabaseConnectionService;
            _cashFlowMapper = cashFlowMapper;

            Task.Run(async () => await FetchItems());
            
        }

        async Task FetchItems()
        {
            Items = new ObservableCollection<CashFlow>();
            var result = await _remoteDatabaseConnectionService.GetItems();

            foreach (var item in result)
            {
                CashFlow cashFlow = _cashFlowMapper.FromDto(item);
                Items.Add(cashFlow);
            }
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
