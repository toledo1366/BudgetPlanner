using BudgetPlanner.UI.ViewModels.CashFlowForm;

namespace BudgetPlanner.UI.Pages;

public partial class CashFlowForm : ContentPage
{
	public CashFlowForm(CashFlowFormViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}