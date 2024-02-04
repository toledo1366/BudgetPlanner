using System;
using System.Collections.ObjectModel;
using BudgetPlanner.UI.Models.CashFlows;

namespace BudgetPlanner.UI.Helpers
{
	public static class ListExtensions
	{
        public static List<CashFlow> SortCashFlowsAscending(List<CashFlow> list)
        {
            list.Sort((a, b) => a.Date.CompareTo(b.Date));

            return list;
        }

        public static List<CashFlow> SortCashFlowsDescending(List<CashFlow> list)
        {
            list.Sort((a, b) => b.Date.CompareTo(a.Date));

            return list;
        }
    }
}

