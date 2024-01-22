using BudgetPlanner.UI.ViewModels.Incomes;

namespace BudgetPlanner.UI.Pages;

public partial class IncomesPage : ContentPage
{
	public IncomesPage(IncomesViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;

		vm.GetIncomesList();
	}
}