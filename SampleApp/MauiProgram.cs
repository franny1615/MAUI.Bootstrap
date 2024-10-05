using MAUIBootstrap;
using Microsoft.Extensions.Logging;

namespace SampleApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		string regularFontName = "OpenSansRegular";
		string boldFontName = "OpensSansSemibold";

		var builder = MauiApp.CreateBuilder();
#pragma warning disable MCT001 // `.UseMauiCommunityToolkit()` Not Found on MauiAppBuilder
        builder
			.UseMauiApp<App>()
			.UseMauiBootstrap(regularFontName, boldFontName)
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", regularFontName);
				fonts.AddFont("OpenSans-Semibold.ttf", boldFontName);
			});
#pragma warning restore MCT001 // `.UseMauiCommunityToolkit()` Not Found on MauiAppBuilder

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
