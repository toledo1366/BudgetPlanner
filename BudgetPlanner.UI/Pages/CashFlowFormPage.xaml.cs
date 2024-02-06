using BudgetPlanner.UI.Models.CashFlows;
using BudgetPlanner.UI.ViewModels.CashFlowForm;

namespace BudgetPlanner.UI.Pages;

public partial class CashFlowFormPage : ContentPage
{
	public CashFlowFormPage(CashFlowFormViewModel vm)
	{
		InitializeComponent();

		BindingContext = vm;
	}
}