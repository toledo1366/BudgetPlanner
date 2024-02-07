using System;
using System.Collections.ObjectModel;
using System.Globalization;
using BudgetPlanner.UI.Models.CashFlows;
using CommunityToolkit.Mvvm.ComponentModel;
using Microcharts;

namespace BudgetPlanner.UI.ViewModels.Chart
{
	public partial class ChartViewModel : ObservableObject
	{
		[ObservableProperty]
		public ObservableCollection<ChartEntry> chartEntries;

		public ChartViewModel()
		{
			chartEntries = new ObservableCollection<ChartEntry>();
		}

		public void AddCashFlowsToEntitiesList(List<CashFlow> cashFlows)
		{
			ChartEntry incomeEntry;
			ChartEntry expenseEntry;

			float incomeSum = 0.0f;
			float expenseSum = 0.0f;

			for(int i = 0; i<cashFlows.Count; i++)
			{
				if (cashFlows[i].CashFlowType == CashFlowType.Koszty)
				{
                    expenseSum += (float)cashFlows[i].Price;
				}
				else
				{
					incomeSum += (float)cashFlows[i].Price;
                }
			}

			incomeEntry = new ChartEntry(incomeSum)
			{
				Color = SkiaSharp.SKColor.Parse("#00ff00"),
				Label = "Przychody",
				ValueLabel = incomeSum.ToString("c", CultureInfo.CreateSpecificCulture("pl-PL")),
			};
			ChartEntries.Add(incomeEntry);

            expenseEntry = new ChartEntry(expenseSum)
            {
                Color = SkiaSharp.SKColor.Parse("#ff0000"),
                Label = "Koszty",
                ValueLabel = expenseSum.ToString("c", CultureInfo.CreateSpecificCulture("pl-PL")),
            };
            ChartEntries.Add(expenseEntry);
		}
	}

	enum Colors { Red, Green, Blue, Yellow};
}

