using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.Models.CashFlows
{
    public class CashFlow
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public DateTime Date { get; set; }
        public CashFlowType CashFlowType { get; set; }
    }

    public enum CashFlowType {  Income = 1, Expense = 2}
}
