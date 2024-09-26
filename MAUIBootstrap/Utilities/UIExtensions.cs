using System;
using CommunityToolkit.Maui.Markup;
using MAUIBootstrap.Controls;

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

    public static VerticalStackLayout PrimaryAlert(
        this VerticalStackLayout layout,
        View content,
        bool dismissable = true,
        int timeoutMS = 0
    )
    {
        var alert = new AlertControl
        {
            AlertContent = content,
            Timeout = TimeSpan.FromMilliseconds(timeoutMS),
            Dismissable = dismissable,
            AlertType = AlertType.Primary
        };
        alert.CloseClicked += (s, e) => 
        {
            if (s is AlertControl alertControl)
            {   
                layout.Remove(alertControl);
            }
        };
        layout.Insert(0, alert);

        return layout;
    }
}
