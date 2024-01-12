using BudgetPlanner.Auth.Services;
using BudgetPlannet.Core.ViewModels;

namespace BudgetPlanner.UI.Pages;

public partial class LoginPage : ContentPage
{
	private readonly IAuthorizationService _authorizationService;

	public LoginPage(IAuthorizationService authorizationService)
	{
		_authorizationService = authorizationService;
		InitializeComponent();

		BindingContext = new LoginViewModel(authorizationService);
	}
}