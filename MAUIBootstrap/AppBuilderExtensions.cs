using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using FmgLib.MauiMarkup;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MAUIBootstrap;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiBootstrap(
        this MauiAppBuilder builder,
        string regularFontName,
        string boldFontName)
    {
        DynamicConstants.Instance.RegularFont = regularFontName;
        DynamicConstants.Instance.BoldFont = boldFontName;
        builder
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .UseMauiMarkupLocalization()
            .UseMauiCompatibility()
            .ConfigureFonts((fonts) => 
            {
                fonts.AddFont("MaterialIcons-Regular.ttf", nameof(MaterialIcon));
            });
        return builder;
    }
}