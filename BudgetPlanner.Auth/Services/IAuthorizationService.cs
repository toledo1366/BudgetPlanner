using System;
namespace BudgetPlanner.Auth.Services
{
	public interface IAuthorizationService
	{
		void SignInWithGoogle();
		void LogoutFromGoogleSource();
    }
}

