using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels
{
    public partial class LoginViewModel:ObservableObject
    {
        readonly private INavigationService _navigationService;

        public LoginViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
        }

        [RelayCommand]
        public async Task BeginLogin()
        {
            Console.WriteLine("Logowanie rozpoczęte");
            await _navigationService.Navigate<ControlPanelPage>();
        }
    }
}
