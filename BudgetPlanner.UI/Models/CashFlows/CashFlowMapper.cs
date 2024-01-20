using BudgetPlanner.Core.Models.CashFlows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.Models.CashFlows
{
    public class CashFlowMapper : IMapper<CashFlowDTO, CashFlow>
    {
        public CashFlow FromDto(CashFlowDTO dto)
        {
            return new CashFlow 
            {
                Name = dto.Name,
                Price = dto.Price,
                Date = DateTime.Parse(dto.Date),
                CashFlowType = (CashFlowType)dto.CashFlowType,
            };
        }
        
        public CashFlowDTO ToDto(CashFlow model)
        {
            return new CashFlowDTO
            {
                Name = model.Name,
                Price = model.Price,
                Date = model.Date.ToString(),
                CashFlowType = (int)model.CashFlowType
            };
        }
    }
}
