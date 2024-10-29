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
        float width = 0f,
        float height = 0f)
    {
        if (parent.Handler?.MauiContext == null) {  return; }
        
        var currentVc = Platform.GetCurrentUIViewController();
        if (currentVc == null) { return; }
        
        var popoverVc = new PopoverViewController(content.ToPlatform(parent.Handler.MauiContext), width, height);
        if (popoverVc.View == null) { return; }
        
        popoverVc.ModalPresentationStyle = UIModalPresentationStyle.Popover;
        
        var popoverController = popoverVc.PopoverPresentationController;
        if (popoverController == null) { return; }
        switch (placement)
        {
            case PopoverPlacement.Top:
                popoverController.PermittedArrowDirections = UIPopoverArrowDirection.Down;
                break;
            case PopoverPlacement.Bottom:
                popoverController.PermittedArrowDirections = UIPopoverArrowDirection.Up;
                break;
            case PopoverPlacement.Left:
                popoverController.PermittedArrowDirections = UIPopoverArrowDirection.Right;
                break;
            case PopoverPlacement.Right:
                popoverController.PermittedArrowDirections = UIPopoverArrowDirection.Left;
                break;
        }

        var parentView = parent.ToPlatform(parent.Handler.MauiContext);
        
        popoverController.SourceRect = parentView.Bounds;
        popoverController.SourceView = parentView;
        popoverController.Delegate = new PopoverDelegate();
        
        currentVc.PresentViewController(popoverVc, true, null);
    }
}

public class PopoverViewController(
    UIView? content,
    float width,
    float height) : UIViewController
{
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();

        if (View == null || content == null) return;
        
        View.AddSubview(content);

        content.TranslatesAutoresizingMaskIntoConstraints = false;
        
        content.TranslatesAutoresizingMaskIntoConstraints = false;
        content.TopAnchor.ConstraintEqualTo(View.TopAnchor).Active = true;
        content.LeftAnchor.ConstraintEqualTo(View.LeftAnchor).Active = true;
        content.RightAnchor.ConstraintEqualTo(View.RightAnchor).Active = true;
        content.BottomAnchor.ConstraintEqualTo(View.BottomAnchor).Active = true;
        
        PreferredContentSize = new CGSize(width, height);
    }
}

public class PopoverDelegate : UIPopoverPresentationControllerDelegate
{
    public override UIModalPresentationStyle GetAdaptivePresentationStyle(
        UIPresentationController controller,
        UITraitCollection traitCollection)
    {
        return UIModalPresentationStyle.None;
    }
}