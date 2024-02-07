using System;
using BudgetPlanner.Auth.Services;

namespace BudgetPlanner.Core.Services.Login
{
	public class LoginService:ILoginService
	{
        private readonly IAuthorizationService _authorizationService;

		public LoginService(IAuthorizationService authorizationService)
		{
            _authorizationService = authorizationService;
		}

        public async Task<bool> SignIn(string username, string password)
        {
            return await _authorizationService.SignIn(username, password);
        }
    }
}

