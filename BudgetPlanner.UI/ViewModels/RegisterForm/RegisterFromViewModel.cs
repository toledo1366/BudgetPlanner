﻿using BudgetPlanner.Auth.Services;
using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels.RegisterForm
{
    public partial class RegisterFromViewModel:ObservableObject
    {
        readonly private INavigationService _navigationService;
        readonly private IAuthorizationService _authorizationService;

        [ObservableProperty]
        private string userName;

        [ObservableProperty]
        private string email;

        [ObservableProperty]
        private string password;

        [ObservableProperty]
        private string repeatedPassword;

        public RegisterFromViewModel(INavigationService navigationService, IAuthorizationService authorizationService)
        {
            _navigationService = navigationService;
            _authorizationService = authorizationService;
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
        public async Task Register()
        {
            bool passwordsAreSame = CheckIfPasswordsAreSame();
        }
    }
}

