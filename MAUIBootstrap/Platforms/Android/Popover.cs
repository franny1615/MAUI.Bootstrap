using Android.Views;
using Android.Widget;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Platform;
using View = Microsoft.Maui.Controls.View;

namespace MAUIBootstrap.Platforms.Android;

public class Popover : IPopover 
{
    public static IPopover Instance { get; } = new Popover();
    
    public IPopoverInstance? Show(
        PopoverPlacement placement,
        View parent, 
        View content,
        int dismissInSeconds = 0)
    {   
        if (parent.Handler?.MauiContext == null) { return null; }
        
        var contentView = content.ToPlatform(parent.Handler.MauiContext);
        
        var popupWindow = new PopupWindow(
            contentView,
            ViewGroup.LayoutParams.WrapContent,
            ViewGroup.LayoutParams.WrapContent);

        popupWindow.OutsideTouchable = true;
        popupWindow.Focusable = true;
        
        var parentView = parent.ToPlatform(parent.Handler.MauiContext);
        
        var location = new int[2];
        parentView.GetLocationOnScreen(location);
        
        contentView.Measure(0, 0);
        
        switch (placement)
        {   
            case PopoverPlacement.Bottom:
                popupWindow.ShowAtLocation(
                    parentView, 
                    GravityFlags.NoGravity, 
                    location[0] - (int)(Math.Abs(contentView.MeasuredWidth - parentView.MeasuredWidth) * 0.5), 
                    location[1] + parentView.MeasuredHeight);
                break;
            case PopoverPlacement.Top:
                popupWindow.ShowAtLocation(
                    parentView, GravityFlags.NoGravity, 
                    location[0] - (int)(Math.Abs(contentView.MeasuredWidth - parentView.MeasuredWidth) * 0.5), 
                    location[1] - contentView.MeasuredHeight);
                break;
            case PopoverPlacement.Left:
                popupWindow.ShowAtLocation(
                    parentView, 
                    GravityFlags.NoGravity, 
                    location[0] - contentView.MeasuredWidth, 
                    (int)((location[1] + (parentView.MeasuredHeight * 0.5)) - (contentView.MeasuredHeight * 0.5)));
                break;
            case PopoverPlacement.Right:
                popupWindow.ShowAtLocation(
                    parentView, 
                    GravityFlags.NoGravity, 
                    location[0] + parentView.Width, 
                    (int)((location[1] + (parentView.MeasuredHeight * 0.5)) - (contentView.MeasuredHeight * 0.5)));
                break;
        }

        if (dismissInSeconds > 0)
        {
            Task.Run(async () =>
            {
                await Task.Delay(dismissInSeconds * 1000);
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    popupWindow.Dismiss();
                });
            });
        }

        return new PopoverInstance
        {
            Close = () => { MainThread.BeginInvokeOnMainThread(() => popupWindow?.Dismiss()); }
        };
    }
}

public class PopoverInstance : IPopoverInstance
{
    public Action? Close { get; set; }
    
    public void ClosePopover()
    {
        Close?.Invoke();
    }
}