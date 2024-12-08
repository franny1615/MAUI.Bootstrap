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
    private IPopoverInstance? _CurrentPopover = null;
    
    public PopoverDemoPage()
    {
        this
            .Title("Popovers")
            .Content(new VerticalStackLayout()
                .Children([
                    new Button()
                        .Primary()
                        .Text("Right")
                        .OnClicked(RightPopover)
                        .AlignLeft()
                        .CenterVertical(),
                    new Button()
                        .Primary()
                        .Text("Bottom")
                        .OnClicked(BottomPopover)
                        .Center(),
                    new Button()
                        .Primary()
                        .Text("Left")
                        .OnClicked(LeftPopover)
                        .AlignRight()
                        .CenterVertical(),
                    new Button()
                        .Primary()
                        .Text("Top")
                        .OnClicked(TopPopover)
                        .Center(),
                    new Label()
                        .Text("Popovers will close programmatically after 2 second. May force close by tapping outside of content.")
                        .Center()
                ]));
    }

    private void TopPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        _CurrentPopover = Popover.Instance.Show(
            PopoverPlacement.Top,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Top Popover"));

        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _CurrentPopover?.ClosePopover();
        });
    }

    private void BottomPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        _CurrentPopover = Popover.Instance.Show(
            PopoverPlacement.Bottom,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Bottom Popover"));
        
        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _CurrentPopover?.ClosePopover();
        });
    }

    private void LeftPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        _CurrentPopover = Popover.Instance.Show(
            PopoverPlacement.Left,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Left Popover"));
        
        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _CurrentPopover?.ClosePopover();
        });
    }

    private void RightPopover(object? sender, EventArgs e)
    {
        if (sender is not Button button) return;
        
        _CurrentPopover = Popover.Instance.Show(
            PopoverPlacement.Right,
            button,
            new Label() 
                .Padding(8)
                .BackgroundColor(BootstrapColors.Secondary)
                .TextColor(Colors.White)
                .HorizontalTextAlignment(TextAlignment.Center)
                .Text("Right Popover"));
        
        Task.Run(async () =>
        {
            await Task.Delay(TimeSpan.FromSeconds(2));
            _CurrentPopover?.ClosePopover();
        });
    }
}