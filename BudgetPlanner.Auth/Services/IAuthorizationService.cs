﻿using System;
using System.Runtime.CompilerServices;
namespace BudgetPlanner.Auth.Services
{
	public interface IAuthorizationService
	{
		public Task<bool> SignIn(string email, string password);
		void LogoutFromGoogleSource();
    }
}