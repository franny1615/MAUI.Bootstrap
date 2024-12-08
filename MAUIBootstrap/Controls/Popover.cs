namespace MAUIBootstrap.Controls;

public enum PopoverPlacement
{
    Left,
    Right,
    Top,
    Bottom
}

public interface IPopover
{
    public static IPopover Instance { get; }
    public IPopoverInstance? Show(
        PopoverPlacement placement, 
        View parent, 
        View content,
        int dismissInSeconds = 0);
}

public interface IPopoverInstance
{
    public void ClosePopover();
}