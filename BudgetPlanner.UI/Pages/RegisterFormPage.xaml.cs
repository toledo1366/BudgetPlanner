using BudgetPlanner.UI.ViewModels.RegisterForm;

namespace BudgetPlanner.UI.Pages;

public partial class RegisterFormPage : ContentPage
{
	public RegisterFormPage(RegisterFromViewModel vm)
	{
		InitializeComponent();
		BindingContext = vm;
	}
}