using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Controls.Shapes;

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
        int timeoutMS = 0)
    {
        var alert = new AlertControl()
        {
            Dismissable = dismissable
        }
        .AlertContent(content)
        .Primary()
        .Timeout(TimeSpan.FromMilliseconds(timeoutMS));

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

    public static Label CardTitle(this Label label)
    {
        label
            .FontFamily(DynamicConstants.Instance.BoldFont)
            .FontSize(16)
            .Padding(8);
        return label;
    }

    public static Label CardSubtitle(this Label label)
    {
        label
            .FontSize(13)
            .Padding(8);
        return label;
    }

    public static Button CardAction(this Button button)
    {
        button
            .Margin(8)
            .AlignLeft();
        return button;
    }

    public static Border Card(this Border border)
    {
        border
            .Stroke(BootstrapColors.Secondary)
            .StrokeThickness(1)
            .StrokeShape(new RoundRectangle().CornerRadius(5));
        return border;
    }

    public static Image CardImage(this Image image)
    {
        image
            .Aspect(Aspect.Fill)
            .HeightRequest(180);
        return image;
    }
}
