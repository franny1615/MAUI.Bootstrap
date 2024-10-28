using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Platforms.iOS;

public class Popover : IPopover 
{
    public static IPopover Instance { get; } = new Popover();
    
    public void Show(PopoverPlacement placement, View parent, View content)
    {
        
    }
}