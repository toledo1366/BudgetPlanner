using BudgetPlanner.Auth.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BudgetPlanner.Core.ViewModels;

public partial class LoginViewModel : ObservableObject
{
    private readonly IAuthorizationService _authorizationService;

    public LoginViewModel(IAuthorizationService authorizationService)
    {
        _authorizationService = authorizationService;
    }

    [RelayCommand]
    async Task RunLoginFlow()
    {
        await _authorizationService.SignInWithGoogle();
    }
}
