using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using BudgetPlanner.UI.ViewModels;
using BudgetPlanner.UI.ViewModels.ControlPanel;
using BudgetPlanner.UI.ViewModels.Main;
using Microsoft.Extensions.Logging;
using Plugin.Firebase.Auth.Google;
using Plugin.Firebase.Auth;
using Plugin.Firebase.Bundled.Shared;
using System.Runtime.CompilerServices;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Bundled.Platforms.Android;

namespace BudgetPlanner.UI
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .RegisterPages()
                .RegisterCustomServices()
                .RegisterViewModels()
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
            builder.ConfigureLifecycleEvents(events => {
                events.AddAndroid(android => android.OnCreate((activity, _) => {
                    var settings = CreateCrossFirebaseSettings();
                    CrossFirebase.Initialize(activity, settings);
                    FirebaseAuthGoogleImplementation.Initialize(settings.GoogleRequestIdToken);
                }));
            });

            builder.Services.AddSingleton(_ => CrossFirebaseAuth.Current);
            builder.Services.AddSingleton(_ => CrossFirebaseAuthGoogle.Current);

            return builder;
        }

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<LoginViewModel>();
            builder.Services.AddTransient<ControlPanelViewModel>();

            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddTransient<ControlPanelPage>();

            return builder;
        }

        private static MauiAppBuilder RegisterCustomServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();

            return builder;
        }

        private static CrossFirebaseSettings CreateCrossFirebaseSettings()
        {
            return new CrossFirebaseSettings(
                isAnalyticsEnabled: true,
                isAuthEnabled: true,
                isCloudMessagingEnabled: true,
                isDynamicLinksEnabled: true,
                isFirestoreEnabled: true,
                isFunctionsEnabled: true,
                isRemoteConfigEnabled: true,
                isStorageEnabled: true,
                googleRequestIdToken: "1032501458090-7u266a5uevk6lospp7rvf4rdqdp1o6h6.apps.googleusercontent.com");
        }
    }
}
