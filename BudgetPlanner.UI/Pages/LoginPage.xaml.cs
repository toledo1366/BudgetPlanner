using BudgetPlanner.UI.ViewModels;

namespace BudgetPlanner.UI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage(LoginViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}