using System;
using System.Runtime.CompilerServices;
namespace BudgetPlanner.Auth.Services
{
	public interface IAuthorizationService
	{
		public void AccountRegistration(string username, string email, string password);
		string Uid { get; }
		public Task<bool> SignIn(string email, string password);
    }
}