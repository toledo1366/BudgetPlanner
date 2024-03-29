﻿using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.UI.ViewModels.Main
{
    public partial class MainViewModel : ObservableObject
    {
        readonly INavigationService _navigationService;

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            StartUp();
        }

        public async Task StartUp()
        {
            await Task.Delay(2000);

            await _navigationService.Navigate<LoginPage>();
        }
    }
}
