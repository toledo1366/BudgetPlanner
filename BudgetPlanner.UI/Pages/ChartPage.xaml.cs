using BudgetPlanner.UI.Models.CashFlows;
using BudgetPlanner.UI.ViewModels.Chart;
using Microcharts;

namespace BudgetPlanner.UI.Pages;

public partial class ChartPage : ContentPage
{
	public ChartPage(ChartViewModel vm, List<CashFlow> cashFlows)
	{
		InitializeComponent();

		BindingContext = vm;

		vm.AddCashFlowsToEntitiesList(cashFlows);

		chart.Chart = new DonutChart
		{
			Entries = vm.ChartEntries
		};

		chart.Chart.LabelTextSize = 25;
	}
}
