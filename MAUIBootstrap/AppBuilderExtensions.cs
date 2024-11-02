using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Core;
using FmgLib.MauiMarkup;
using Microsoft.Maui.Controls.Compatibility.Hosting;
using MAUIBootstrap.Controls;
using SkiaSharp.Views.Maui.Controls.Hosting;

#if ANDROID
using Microsoft.Maui.Controls.Compatibility.Platform.Android;
#endif

#if IOS
using CoreAnimation;
using CoreGraphics;
#endif

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
            .UseSkiaSharp()
            .ConfigureFonts((fonts) =>
            {
                fonts.AddFont("MaterialIcons-Regular.ttf", nameof(MaterialIcon));
            });

        Microsoft.Maui.Handlers.EntryHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
            if (view is EntryControl control && control.IsBorderless)
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.Layer.BorderColor = UIKit.UIColor.Clear.CGColor;
                handler.PlatformView.BorderStyle = UIKit.UITextBorderStyle.None;
#endif
            }
        });

        Microsoft.Maui.Handlers.EditorHandler.Mapper.AppendToMapping("Borderless", (handler, view) =>
        {
            if (view is EditorControl control)
            {
#if ANDROID
                handler.PlatformView.Background = null;
                handler.PlatformView.SetBackgroundColor(Android.Graphics.Color.Transparent);
                handler.PlatformView.BackgroundTintList = Android.Content.Res.ColorStateList.ValueOf(Colors.Transparent.ToAndroid());
#elif IOS
                handler.PlatformView.BackgroundColor = UIKit.UIColor.Clear;
                handler.PlatformView.Layer.BorderWidth = 0;
                handler.PlatformView.Layer.BorderColor = UIKit.UIColor.Clear.CGColor;
                if (OperatingSystem.IsIOSVersionAtLeast(17))
                {
                    handler.PlatformView.BorderStyle = UIKit.UITextViewBorderStyle.None;
                }
#endif
            }
        });
        return builder;
    }
}