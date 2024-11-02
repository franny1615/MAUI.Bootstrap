#if ANDROID 
using MAUIBootstrap.Platforms.Android;
#elif IOS
using MAUIBootstrap.Platforms.iOS;
#endif
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public class ToastDemoPage : ContentPage 
{
    public ToastDemoPage()
    {
        this
            .Title("Toasts")
            .Content(new Grid()
                .Children([
                    new BoxView()
                        .Assign(out var bottomMarker)
                        .VerticalOptions(LayoutOptions.End)
                        .HorizontalOptions(LayoutOptions.Center)
                        .HeightRequest(10)
                        .WidthRequest(10)
                        .BackgroundColor(BootstrapColors.Primary),
                    new BoxView()
                        .Assign(out var topMarker)
                        .VerticalOptions(LayoutOptions.Start)
                        .HorizontalOptions(LayoutOptions.Center)
                        .HeightRequest(10)
                        .WidthRequest(10)
                        .BackgroundColor(BootstrapColors.Primary),
                    new BoxView()
                        .Assign(out var leftMarker)
                        .VerticalOptions(LayoutOptions.Center)
                        .HorizontalOptions(LayoutOptions.Start)
                        .HeightRequest(10)
                        .WidthRequest(10)
                        .BackgroundColor(BootstrapColors.Primary),
                    new BoxView()
                        .Assign(out var rightMarker)
                        .VerticalOptions(LayoutOptions.Center)
                        .HorizontalOptions(LayoutOptions.End)
                        .HeightRequest(10)
                        .WidthRequest(10)
                        .BackgroundColor(BootstrapColors.Primary),
                    new VerticalStackLayout()
                        .Center()
                        .Children([
                            new Button()
                                .Primary()
                                .Text("Bottom")
                                .OnClicked((s, e) =>
                                {
                                    Popover.Instance.Show(
                                        PopoverPlacement.Top,
                                        bottomMarker,
                                        MakeContent(),
                                        5);
                                }),
                            new Button()
                                .Primary()
                                .Text("Top")
                                .OnClicked((s, e) =>
                                {
                                    Popover.Instance.Show(
                                        PopoverPlacement.Bottom,
                                        topMarker,
                                        MakeContent(),
                                        5);
                                }),
                            new Button()
                                .Primary()
                                .Text("Left")
                                .OnClicked((s, e) =>
                                {
                                    Popover.Instance.Show(
                                        PopoverPlacement.Right,
                                        leftMarker,
                                        MakeContent(),
                                        5);
                                }),
                            new Button()
                                .Primary()
                                .Text("Right")
                                .OnClicked((s, e) =>
                                {
                                    Popover.Instance.Show(
                                        PopoverPlacement.Left,
                                        rightMarker,
                                        MakeContent(),
                                        5);
                                }),
                        ])
                ]));
    }

    private VerticalStackLayout MakeContent()
    {
        return new VerticalStackLayout()
            .BackgroundColor(BootstrapColors.Secondary)
            .Children([
                new Label()
                    .Text("Custom Toast")
                    .CardTitle()
                    .Padding(8)
                    .Row(0)
                    .TextColor(Colors.White),
                new BoxView().MakeDivider(Colors.White),
                new Label()
                    .Text("My message to user toast")
                    .CardSubtitle()
                    .Padding(8)
                    .Row(2)
                    .TextColor(Colors.White),
            ]);
    }
}