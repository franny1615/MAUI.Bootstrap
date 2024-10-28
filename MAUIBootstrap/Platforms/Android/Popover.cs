using Android.Views;
using Android.Widget;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Platform;
using View = Microsoft.Maui.Controls.View;

namespace MAUIBootstrap.Platforms.Android;

public class Popover : IPopover 
{
    public static IPopover Instance { get; } = new Popover();
    
    public void Show(
        PopoverPlacement placement,
        View parent, 
        View content)
    {   
        if (parent.Handler?.MauiContext == null) { return; }
        
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
                popupWindow.ShowAtLocation(parentView, GravityFlags.NoGravity, location[0] - (int)(contentView.MeasuredWidth * 0.25), location[1] + contentView.MeasuredHeight);
                break;
            case PopoverPlacement.Top:
                popupWindow.ShowAtLocation(parentView, GravityFlags.NoGravity, location[0] - (int)(contentView.MeasuredWidth * 0.25), location[1] - contentView.MeasuredHeight);
                break;
            case PopoverPlacement.Left:
                popupWindow.ShowAtLocation(parentView, GravityFlags.NoGravity, location[0] - contentView.MeasuredWidth, location[1]);
                break;
            case PopoverPlacement.Right:
                popupWindow.ShowAtLocation(parentView, GravityFlags.NoGravity, location[0] + parentView.Width, location[1]);
                break;
        }
    }
}