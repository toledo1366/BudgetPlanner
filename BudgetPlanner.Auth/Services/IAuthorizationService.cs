using System;
using System.Runtime.CompilerServices;
namespace BudgetPlanner.Auth.Services
{
	public interface IAuthorizationService
	{
		Task SignInWithGoogle();
		void LogoutFromGoogleSource();
    }
}

