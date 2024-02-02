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

        private string _uid;
        public string Uid => _uid;

        public async Task<bool> SignIn(string email, string password)
        {
            var user = await _firebaseAuthGoogle.SignInWithEmailAndPasswordAsync(email, password);
            var creds = user.AuthCredential;
            _uid = user.User.Uid;

            if (creds is null)
            {
                return false;
            }

            return true;
        }

        void IAuthorizationService.LogoutFromGoogleSource()
        {
            _firebaseAuthGoogle.SignOut();
        }

        async void IAuthorizationService.AccountRegistration(string username, string email, string password)
        {
            try
            {
                await _firebaseAuthGoogle.CreateUserWithEmailAndPasswordAsync(email, password,username);
            } catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

