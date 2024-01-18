using BudgetPlanner.UI.ViewModels;

namespace BudgetPlanner.UI.Pages;

public partial class LoginPage : ContentPage
{
	public LoginPage()
	{
		InitializeComponent();

		BindingContext = new LoginViewModel();
	}
}