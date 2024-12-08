using MAUIBootstrap;
using Microsoft.Extensions.Logging;

namespace SampleApp;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
#pragma warning disable MCT001 // `.UseMauiCommunityToolkit()` Not Found on MauiAppBuilder
        builder
			.UseMauiApp<App>()
			.UseMauiBootstrap()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont($"{Constants.RegularFont}.ttf", Constants.RegularFont);
				fonts.AddFont($"{Constants.MediumFont}.ttf", Constants.MediumFont);
			});
#pragma warning restore MCT001 // `.UseMauiCommunityToolkit()` Not Found on MauiAppBuilder

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
