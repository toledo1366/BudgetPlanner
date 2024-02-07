using System;
namespace BudgetPlanner.Core.Services.Login
{
	public interface ILoginService
	{
        Task<bool> SignIn(string username, string password);
	}
}

