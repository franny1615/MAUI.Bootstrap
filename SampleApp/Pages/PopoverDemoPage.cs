using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
#if ANDROID 
using MAUIBootstrap.Platforms.Android;
#elif IOS
using MAUIBootstrap.Platforms.iOS;
#endif

namespace SampleApp.Pages;

public class PopoverDemoPage : ContentPage 
{
    public PopoverDemoPage()
    {
        this
            .Title("Popovers")
            .Content(new Grid()
                .ColumnDefinitions(e => e.Star().Star().Star())
                .RowDefinitions(e => e.Star().Star().Star())
                .Children([
                    new Button()
                        .Primary()
                        .Text("Right")
                        .OnClicked(RightPopover)
                        .Row(0)
                        .Column(0)
                        .AlignLeft()
                        .CenterVertical(),
                    new Button()
                        .Primary()
                        .Text("Bottom")
                        .OnClicked(BottomPopover)
                        .Row(0)
                        .Column(1)
                        .Center(),
                    new Button()
                        .Primary()
                        .Text("Left")
                        .OnClicked(LeftPopover)
                        .Row(0)
                        .Column(2)
                        .AlignRight()
                        .CenterVertical(),
                    new Button()
                        .Primary()
                        .Text("Top")
                        .OnClicked(TopPopover)
                        .Row(2)
                        .Column(1)
                        .Center(),
                ]));
    }

    private void TopPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        Popover.Instance.Show(
            PopoverPlacement.Top,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Top Popover"),
            120,
            50);
    }

    private void BottomPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        Popover.Instance.Show(
            PopoverPlacement.Bottom,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Bottom Popover"),
            120,
            50);
    }

    private void LeftPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        Popover.Instance.Show(
            PopoverPlacement.Left,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Left Popover"),
            120,
            50);
    }

    private void RightPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        Popover.Instance.Show(
            PopoverPlacement.Right,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Right Popover"),
            120,
            50);
    }
}