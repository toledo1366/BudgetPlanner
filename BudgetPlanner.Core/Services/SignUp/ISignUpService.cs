using System;
namespace BudgetPlanner.Core.Services.SignUp
{
	public interface ISignUpService
	{
		void SignUp(string username, string email, string password);
	}
}

