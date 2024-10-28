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
        View content)
    {
        if (parent.Handler?.MauiContext == null) {  return; }
        
        var currentVc = Platform.GetCurrentUIViewController();
        if (currentVc == null) { return; }
        
        var popoverVc = new PopoverViewController();
        if (popoverVc.View == null) { return; }

        var contentView = content.ToPlatform(parent.Handler.MauiContext);
        
        popoverVc.View.AddSubview(contentView);
        popoverVc.ModalPresentationStyle = UIModalPresentationStyle.Popover;
        
        contentView.TranslatesAutoresizingMaskIntoConstraints = false;
        contentView.TopAnchor.ConstraintEqualTo(popoverVc.View.TopAnchor).Active = true;
        contentView.BottomAnchor.ConstraintEqualTo(popoverVc.View.BottomAnchor).Active = true;
        contentView.LeftAnchor.ConstraintEqualTo(popoverVc.View.LeftAnchor).Active = true;
        contentView.RightAnchor.ConstraintEqualTo(popoverVc.View.RightAnchor).Active = true;
        
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

public class PopoverViewController : UIViewController
{
    public override void ViewDidLoad()
    {
        base.ViewDidLoad();
        // TODO: figure out how to auto calculate height of content
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