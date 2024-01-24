using System;
using Firebase.Auth;
using Firebase.Auth.Providers;

namespace BudgetPlanner.Auth.Services
{
	public class AuthorizationService : IAuthorizationService
	{
        private readonly IFirebaseAuthClient _firebaseAuthGoogle;

        public AuthorizationService(IFirebaseAuthClient firebaseAuthGoogle)
		{
            _firebaseAuthGoogle = firebaseAuthGoogle;
		}

        public async Task<bool> SignIn(string email, string password)
        {
            var user = await _firebaseAuthGoogle.SignInWithEmailAndPasswordAsync(email, password);
            var creds = user.AuthCredential;

            if(creds is null)
            {
                return false;
            }

            return true;
        }

        void IAuthorizationService.LogoutFromGoogleSource()
        {
            _firebaseAuthGoogle.SignOut();
        }
    }
}

