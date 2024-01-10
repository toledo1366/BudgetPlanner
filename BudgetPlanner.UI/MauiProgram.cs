using BudgetPlanner.Auth.Services;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.LifecycleEvents;
using Plugin.Firebase.Auth.Google;
using Plugin.Firebase.Bundled.Platforms.Android;
using Plugin.Firebase.Bundled.Shared;

namespace BudgetPlanner.UI;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
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

    private static MauiAppBuilder RegisterServices(this MauiAppBuilder builder)
	{
		builder.Services.AddSingleton<IAuthorizationService, AuthorizationService>();
		return builder;
	}

    private static MauiAppBuilder RegisterFirebaseServices(this MauiAppBuilder builder)
    {
        builder.ConfigureLifecycleEvents(events => {
            events.AddAndroid(android => android.OnCreate((activity, _) => {
                var settings = CreateCrossFirebaseSettings();
                CrossFirebase.Initialize(activity, settings);
                FirebaseAuthGoogleImplementation.Initialize(settings.GoogleRequestIdToken);
            }));
        });

        builder.Services.AddSingleton(_ => CrossFirebaseAuthGoogle.Current);

        return builder;
    }

    private static CrossFirebaseSettings CreateCrossFirebaseSettings()
    {
        return new CrossFirebaseSettings(
            /*
            isAnalyticsEnabled: true,
            isAuthEnabled: true,
            isCloudMessagingEnabled: true,
            isDynamicLinksEnabled: true,
            isFirestoreEnabled: true,
            isFunctionsEnabled: true,
            isRemoteConfigEnabled: true,
            isStorageEnabled: true,
            googleRequestIdToken: "537235599720-723cgj10dtm47b4ilvuodtp206g0q0fg.apps.googleusercontent.com"
            */
            );
    }
}

