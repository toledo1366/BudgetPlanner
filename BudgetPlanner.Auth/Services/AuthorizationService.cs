using System;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Auth.Google;

namespace BudgetPlanner.Auth.Services
{
	public class AuthorizationService : IAuthorizationService
	{
        private readonly IFirebaseAuthGoogle _firebaseAuthGoogle;

        public AuthorizationService(IFirebaseAuthGoogle firebaseAuthGoogle)
		{
            _firebaseAuthGoogle = firebaseAuthGoogle;
		}

        async Task IAuthorizationService.SignInWithGoogle()
        {
            var user = await _firebaseAuthGoogle.SignInWithGoogleAsync();
            await user.GetIdTokenResultAsync();
        }

        async void IAuthorizationService.LogoutFromGoogleSource()
        {
            await _firebaseAuthGoogle.SignOutAsync();
        }
    }
}

