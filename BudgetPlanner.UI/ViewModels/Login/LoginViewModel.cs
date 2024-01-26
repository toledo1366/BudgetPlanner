using BudgetPlanner.Auth.Services;
using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels
{
    public partial class LoginViewModel:ObservableObject
    {
        readonly private INavigationService _navigationService;
        readonly private IAuthorizationService _authorizationService;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private bool errorMessageVisible;

        [ObservableProperty]
        private string errorMessage;

        public LoginViewModel(INavigationService navigationService, IAuthorizationService authorizationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;
        }

        [RelayCommand]
        public async Task BeginLogin()
        {
            try
            {
                bool isLogged = await _authorizationService.SignIn(Email, Password);

                if (isLogged)
                {
                    await _navigationService.Navigate<ControlPanelPage>();
                }
            }
            catch (Exception ex)
            {
                ErrorMessageVisible = true;
                ErrorMessage = "Login failed. Please try again.";
                Password = string.Empty;
            }
        }
    }
}
