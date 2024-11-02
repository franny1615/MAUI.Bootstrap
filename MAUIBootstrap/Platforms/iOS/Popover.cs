using CoreGraphics;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Platform;
using UIKit;

namespace MAUIBootstrap.Platforms.iOS;

public class Popover : IPopover 
{
    public static IPopover Instance { get; } = new Popover();
    
    public void Show(
        PopoverPlacement placement, 
        View parent, 
        View content,
        int dismissInSeconds = 0)
    {
        if (parent.Handler?.MauiContext == null) { return; }
        var parentView = parent.ToPlatform(parent.Handler.MauiContext);
        var contentView = content.ToPlatform(parent.Handler.MauiContext);
        
        var currentVc = Platform.GetCurrentUIViewController();
        if (currentVc == null || currentVc.View == null) { return; }
        
        var size = contentView.SystemLayoutSizeFittingSize(UIView.UILayoutFittingExpandedSize);

        var absoluteFrame = parentView.ConvertRectFromView(parentView.Bounds, currentVc.View);
        
        var x = Math.Abs(absoluteFrame.X);
        var y = Math.Abs(absoluteFrame.Y);
        var w = absoluteFrame.Size.Width;
        var h = absoluteFrame.Size.Height;
        
        #if DEBUG
        System.Diagnostics.Debug.WriteLine($"CGRect({x},{y},{w},{h}), ContentView size: {size.Width}x{size.Height}");
        #endif
        
        switch (placement)
        {
            case PopoverPlacement.Top:
                contentView.Frame = new(
                    x - (Math.Abs(size.Width - w) * 0.5), 
                    y - size.Height, 
                    size.Width,
                    size.Height);
                break;
            case PopoverPlacement.Bottom:
                contentView.Frame = new(
                    x - (Math.Abs(size.Width - w) * 0.5), 
                    y + h, 
                    size.Width,
                    size.Height);
                break;
            case PopoverPlacement.Left:
                contentView.Frame = new(
                    x - Math.Abs(size.Width - w) - w, 
                    (y + (h * 0.5)) - (size.Height * 0.5), // midYOfParent - halfOfContent = yActualOfContent 
                    size.Width,
                    size.Height);
                break;
            case PopoverPlacement.Right:
                contentView.Frame = new(
                    x + w, 
                    (y + (h * 0.5)) - (size.Height * 0.5), // midYOfParent - halfOfContent = yActualOfContent
                    size.Width,
                    size.Height);
                break;
        }

        var dismissView = new UIView();
        dismissView.Frame = currentVc.View.Frame;
        dismissView.BackgroundColor = UIColor.Clear;
        dismissView.GestureRecognizers = [
            new UITapGestureRecognizer(() =>
            {
                dismissView.RemoveFromSuperview();
                contentView.RemoveFromSuperview();
            })
        ];
        
        currentVc.View.AddSubview(dismissView);
        currentVc.View.BringSubviewToFront(dismissView);
        
        currentVc.View.AddSubview(contentView);
        currentVc.View.BringSubviewToFront(contentView);

        if (dismissInSeconds > 0)
        {
            Task.Run(async () =>
            {
                await Task.Delay(dismissInSeconds * 1000);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    dismissView.RemoveFromSuperview();
                    contentView.RemoveFromSuperview();
                });
            });
        }
    }
}