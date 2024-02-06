using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.Models.CashFlows
{
    public class CashFlowDTO
    {
        public required string Name { get; set; }
        public required double Price { get; set; }
        public required string Date { get; set; }
        public required int CashFlowType { get; set; }
        public int? IncomeCategory { get; set; }
        public int? ExpenseCategory { get; set; }
    }
}
