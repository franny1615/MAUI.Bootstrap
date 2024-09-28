using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class UIExtensions
{
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
            .HeightRequest(1)
            .Color(color)
            .BackgroundColor(color)
            .FillHorizontal();
        return boxView;
    }

    public static VerticalStackLayout PrimaryAlert(
        this VerticalStackLayout layout,
        View content,
        bool dismissable = true,
        int timeoutMS = 0
    )
    {
        var alert = new AlertControl()
        {
            Dismissable = dismissable
        }
        .AlertContent(content)
        .Timeout(TimeSpan.FromMilliseconds(timeoutMS))
        .Primary();;
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
