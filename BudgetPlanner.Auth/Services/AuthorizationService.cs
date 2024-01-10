using System;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Auth.Google;

namespace BudgetPlanner.Auth.Services
{
	public class AuthorizationService : IAuthorizationService
	{
        private readonly IFirebaseAuth _firebaseAuth;
        private readonly IFirebaseAuthGoogle _firebaseAuthGoogle;

        public AuthorizationService(IFirebaseAuth firebaseAuth, IFirebaseAuthGoogle firebaseAuthGoogle)
		{
            _firebaseAuth = firebaseAuth;
            _firebaseAuthGoogle = firebaseAuthGoogle;
		}

        async void IAuthorizationService.SignInWithGoogle()
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

