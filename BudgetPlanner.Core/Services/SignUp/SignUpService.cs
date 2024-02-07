using System;
using BudgetPlanner.Auth.Services;

namespace BudgetPlanner.Core.Services.SignUp
{
	public class SignUpService:ISignUpService
	{
        private readonly IAuthorizationService _authorizationService;

		public SignUpService(IAuthorizationService authorizationService)
		{
            _authorizationService = authorizationService;
		}

        public void SignUp(string username, string email, string password)
        {
            _authorizationService.AccountRegistration(username, email, password);
        }
    }
}

