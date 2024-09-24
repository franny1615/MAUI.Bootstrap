using System;
using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using CommunityToolkit.Maui.Markup;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MAUIBootstrap;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseMauiBootstrap(this MauiAppBuilder builder)
    {
        builder
            .UseMauiCommunityToolkit()
            .UseMauiCommunityToolkitCore()
            .UseMauiCommunityToolkitMarkup()
            .UseMauiCompatibility()
            .ConfigureFonts((fonts) => 
            {
                fonts.AddFont("MaterialIcons-Regular.ttf", nameof(MaterialIcon));
            });
        return builder;
    }
}
