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
        public IncomeCategory? IncomeCategory { get; set; }
        public ExpenseCategory? ExpenseCategory { get; set; }
        public Color Color { get; set; }
    }

    public enum CashFlowType {  Przychody = 1, Koszty = 2}
    public enum IncomeCategory { Wypłata = 1, Darowizna = 2, Inne = 0}
    public enum ExpenseCategory { Opłaty = 1, Jedzenie = 2, Rozrywka = 3, Inne = 0}
}
