namespace MAUIBootstrap.Extensions;

public static class CollapseExtensions
{
    public static StackLayout Collapse(
        this StackLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseAnimate(layout, openHeight);
        return layout;
    }

    public static VerticalStackLayout Collapse(
        this VerticalStackLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseAnimate(layout, openHeight);
        return layout;
    }

    public static HorizontalStackLayout Collapse(
        this HorizontalStackLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseAnimate(layout, openHeight);
        return layout;
    }

    public static Grid Collapse(
        this Grid layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseAnimate(layout, openHeight);
        return layout;
    }

    public static FlexLayout Collapse(
        this FlexLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseAnimate(layout, openHeight);
        return layout;
    }

    public static AbsoluteLayout Collapse(
        this AbsoluteLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseAnimate(layout, openHeight);
        return layout;
    }

    public static StackLayout CollapseWidth(
        this StackLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseWidthAnimate(layout, openHeight);
        return layout;
    }

    public static VerticalStackLayout CollapseWidth(
        this VerticalStackLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseWidthAnimate(layout, openHeight);
        return layout;
    }

    public static HorizontalStackLayout CollapseWidth(
        this HorizontalStackLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseWidthAnimate(layout, openHeight);
        return layout;
    }

    public static Grid CollapseWidth(
        this Grid layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseWidthAnimate(layout, openHeight);
        return layout;
    }

    public static FlexLayout CollapseWidth(
        this FlexLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseWidthAnimate(layout, openHeight);
        return layout;
    }

    public static AbsoluteLayout CollapseWidth(
        this AbsoluteLayout layout,
        double openHeight = 0)
    {
        Extensions.Collapse.CollapseWidthAnimate(layout, openHeight);
        return layout;
    }
}

public static class Collapse 
{
    public static void CollapseAnimate(
        View someView,
        double openHeight)
    {
        if (someView.IsVisible)
        {
            someView.Animate(
                "collapse",
                new Animation(x => 
                    {
                        someView.HeightRequest = x;
                    },
                    someView.HeightRequest,
                    0,
                    Easing.CubicIn
                ),
                length: 250,
                finished: (_, _) => 
                {
                    someView.IsVisible = false;
                }
            );
        }
        else
        {
            someView.IsVisible = true;
            someView.Animate(
                "uncollapse",
                new Animation(x => 
                    {
                        someView.HeightRequest = x;
                    },
                    0,
                    openHeight,
                    Easing.CubicOut
                ),
                length: 250
            );
        }
    }

    public static void CollapseWidthAnimate(
        View someView,
        double openWidth)
    {
        if (someView.IsVisible)
        {
            someView.Animate(
                "collapse",
                new Animation(x => 
                    {
                        someView.WidthRequest = x;
                    },
                    someView.WidthRequest,
                    0,
                    Easing.CubicIn
                ),
                length: 250,
                finished: (_, _) => 
                {
                    someView.IsVisible = false;
                }
            );
        }
        else
        {
            someView.IsVisible = true;
            someView.Animate(
                "uncollapse",
                new Animation(x => 
                    {
                        someView.WidthRequest = x;
                    },
                    0,
                    openWidth,
                    Easing.CubicOut
                ),
                length: 250
            );
        }
    }
}