using BudgetPlanner.UI.Pages;
using BudgetPlanner.UI.Services.Navigation;
using BudgetPlanner.UI.ViewModels;
using BudgetPlanner.UI.ViewModels.Main;
using Microsoft.Extensions.Logging;
using System.Runtime.CompilerServices;

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

        private static MauiAppBuilder RegisterViewModels(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainViewModel>();
            builder.Services.AddTransient<LoginViewModel>();

            return builder;
        }

        private static MauiAppBuilder RegisterPages(this MauiAppBuilder builder)
        {
            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<LoginPage>();

            return builder;
        }

        private static MauiAppBuilder RegisterCustomServices(this MauiAppBuilder builder)
        {
            builder.Services.AddSingleton<INavigationService, NavigationService>();
            builder.Services.AddSingleton<IServiceProvider, ServiceProvider>();

            return builder;
        }
    }
}
