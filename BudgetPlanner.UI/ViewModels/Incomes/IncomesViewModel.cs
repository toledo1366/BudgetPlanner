using BudgetPlanner.Core.Services;
using BudgetPlanner.UI.Models.CashFlows;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels.Incomes
{
    public partial class IncomesViewModel : ObservableObject
    {
        [ObservableProperty]
        public ObservableCollection<CashFlow> items;

        readonly private IGetIncomesService _getIncomesService;

        public IncomesViewModel(IGetIncomesService getIncomesService)
        {
            _getIncomesService = getIncomesService;
        }
        
        public void GetIncomesList()
        {
            CashFlowMapper mapper = new CashFlowMapper();
            List<CashFlow> cashFlows = new List<CashFlow>();
            var itemsdto = _getIncomesService.GetCashFlowList();
            items.Add(mapper.FromDto(itemsdto[0]));   
        }
    }
}
