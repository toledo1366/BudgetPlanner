using BudgetPlanner.Core.Services.SignUp;
using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace BudgetPlanner.UI.ViewModels.RegisterForm
{
    public partial class RegisterFromViewModel:ObservableObject
    {
        readonly private INavigationService _navigationService;
        readonly private ISignUpService _signUpService;

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string repeatedPassword;

        public RegisterFromViewModel(INavigationService navigationService, ISignUpService signUpService)
        {
            _navigationService = navigationService;
            _signUpService = signUpService;
        }

        private bool CheckIfPasswordsAreSame()
        {
            if (Password==RepeatedPassword)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [RelayCommand]
        public void Register()
        {
            bool passwordsAreSame = CheckIfPasswordsAreSame();

            if (passwordsAreSame) 
            {
                _signUpService.SignUp(UserName, Email, Password);

                _navigationService.Navigate<LoginPage>();
            }
        }
    }
}

