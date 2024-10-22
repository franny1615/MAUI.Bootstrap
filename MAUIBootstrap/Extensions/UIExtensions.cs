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

    public static BoxView Divider(this BoxView boxView)
    {
        boxView
            .HeightRequest(1)
            .Color(BootstrapColors.Secondary)
            .BackgroundColor(BootstrapColors.Secondary)
            .FillHorizontal();
        return boxView;
    }

    public static BoxView VerticalDivider(this BoxView boxView)
    {
        boxView
            .WidthRequest(1)
            .Color(BootstrapColors.Secondary)
            .BackgroundColor(BootstrapColors.Secondary)
            .FillVertical();
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

public static class UI 
{
    public static void Active(View view)
    {
        if (view.StyleClass != null && view.StyleClass.Contains("active"))
        {
            var noStyle = BootstrapColors.CurrentTheme == AppTheme.Dark ? 
                    "notactivedark" : "notactive";
            view.BackgroundColor(Colors.Transparent);
            view.StyleClass = new List<string>
            {
                noStyle
                
            };
        }
        else
        {
            view.BackgroundColor(BootstrapColors.Primary);
            view.StyleClass = new List<string>
            {
                "active"
            };
        }
    }

    public static void PrimarySubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.PrimarySubtle, "primary");
    public static void SecondarySubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.SecondarySubtle, "secondary");
    public static void SuccessSubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.SuccessSubtle, "success");
    public static void WarningSubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.WarningSubtle, "warning");
    public static void DangerSubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.DangerSubtle, "danger");
    public static void InfoSubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.InfoSubtle, "info");
    public static void LightSubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.LightSubtle, "light");
    public static void DarkSubtle(View view)
        => ApplySubtleStyle(view, BootstrapColors.DarkSubtle, "dark");
    private static void ApplySubtleStyle(
        View view,
        Color color,
        string cssClass)
    {
        if (view.StyleClass != null && view.StyleClass.Contains($"{cssClass}-text-emphasis")) 
        {
            var noStyle = BootstrapColors.CurrentTheme == AppTheme.Dark ? 
                    "notactivedark" : "notactive";
            view.BackgroundColor(Colors.Transparent);
            view.StyleClass = new List<string>
            {
                noStyle
            };
        }
        else 
        {
            view.StyleClass = new List<string> { $"{cssClass}-text-emphasis" };
            view.BackgroundColor(color);
        }
    }
}