using BudgetPlanner.Core.Models.CashFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.Services
{
    public class GetIncomesService : IGetIncomesService
    {
        public List<CashFlowDTO> GetCashFlowList()
        {
            List<CashFlowDTO> cashFlows = new List<CashFlowDTO>();
            cashFlows.Add(new CashFlowDTO {
                Name="byleco",
                Price=999.99,
                Date=DateTime.Now.ToString(),
                CashFlowType=1
            });

            return cashFlows;
        }
    }
}
