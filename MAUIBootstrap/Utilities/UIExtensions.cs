using System;
using CommunityToolkit.Maui.Markup;

namespace MAUIBootstrap.Utilities;

public static class UIExtensions
{
    public static VerticalStackLayout Spacing(
        this VerticalStackLayout layout, 
        double spacing)
    {
        layout.Spacing = spacing;
        return layout;
    }

    public static Image ApplyMaterialIcon(
        this Image image,
        string iconName,
        Color color,
        double size) 
    {
        image.Source = new FontImageSource
        {
            FontFamily = nameof(MaterialIcon),
            Glyph = iconName,
            Color = color,
            Size = size 
        };
        return image;
    }

    public static BoxView MakeDivider(this BoxView boxView, Color color)
    {
        boxView
            .Height(1)
            .Color(color)
            .BackgroundColor(color).Fill();
        return boxView;
    }

    public static BoxView Color(this BoxView boxView, Color color)
    {
        boxView.Color = color;
        return boxView;
    }

    public static TapGestureRecognizer TapsRequired(this TapGestureRecognizer gesture, int taps)
    {
        gesture.NumberOfTapsRequired = taps;
        return gesture;
    }
}
