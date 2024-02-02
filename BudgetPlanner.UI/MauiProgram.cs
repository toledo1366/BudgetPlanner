using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using BudgetPlanner.UI.ViewModels;
using BudgetPlanner.UI.ViewModels.ControlPanel;
using BudgetPlanner.UI.ViewModels.Main;
using Microsoft.Extensions.Logging;
using Firebase.Auth;
using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using BudgetPlanner.Auth.Services;
using BudgetPlanner.Core.Services.Db;
using BudgetPlanner.UI.Models.CashFlows;
using BudgetPlanner.UI.ViewModels.RegisterForm;

namespace BudgetPlanner.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterFirebase()
                .RegisterPages()
                .RegisterCustomServices()
                .RegisterViewModels()
                .RegisterMappers()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
            

            return builder.Build();
        }

        private static MauiAppBuilder RegisterFirebase(this MauiAppBuilder builder) 
        {
            builder.Services.AddSingleton<IFirebaseAuthClient, FirebaseAuthClient>(services => new FirebaseAuthClient(new FirebaseAuthConfig()
            {
                ApiKey = "AIzaSyDa4jRyBSw0WnZ7hCyxyID5hKt2PzW5yqI",
                AuthDomain = "budgetplanner-7ec34.firebaseapp.com",
                Providers = new Firebase.Auth.Providers.FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
            }));

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ControlPanelViewModel>();
            builder.Services.AddTransient<RegisterFromViewModel>();
            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ControlPanelPage>();
            builder.Services.AddTransient<RegisterFormPage>();
            return builder;
        }

        private static MauiAppBuilder RegisterMappers(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<CashFlowMapper>();

            return builder;
        }

        private static MauiAppBuilder RegisterCustomServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();
            builder.Services.AddSingleton<IRemoteDatabaseConnectionService, RemoteDatabaseConnectionService>();

            return builder;
        }

        //private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        //{
        //    return new CrossFirebaseSettings(
        //        //isAnalyticsEnabled: true,
        //        isAuthEnabled: true,
        //        //isCloudMessagingEnabled: true,
        //        //isDynamicLinksEnabled: true,
        //        //isFirestoreEnabled: true,
        //        //isFunctionsEnabled: true,
        //        //isRemoteConfigEnabled: true,
        //        //isStorageEnabled: true,
        //        googleRequestIdToken: "1032501458090-7u266a5uevk6lospp7rvf4rdqdp1o6h6.apps.googleusercontent.com");
        //}
    }
}
