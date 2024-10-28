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
    public void Show(PopoverPlacement placement, View parent, View content);
}