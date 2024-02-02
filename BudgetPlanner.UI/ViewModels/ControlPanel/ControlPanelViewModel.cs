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

        [ObservableProperty]
        public List<CashFlow> items;

        public ControlPanelViewModel(IRemoteDatabaseConnectionService remoteDatabaseConnectionService, CashFlowMapper cashFlowMapper)
        {
            _remoteDatabaseConnectionService = remoteDatabaseConnectionService;
            _cashFlowMapper = cashFlowMapper;

            Task.Run(async () => await FetchItems());
            
        }

        async Task FetchItems()
        {
            Items = new List<CashFlow>();
            var result = await _remoteDatabaseConnectionService.GetItems();
            List<CashFlow> sortedItems = new List<CashFlow>();

            foreach (var item in result)
            {
                CashFlow cashFlow = _cashFlowMapper.FromDto(item);
                sortedItems.Add(cashFlow);
            }

            sortedItems = ListExtensions.SortCashFlowsDescending(sortedItems);

            Items = sortedItems;
        }
    }
}
