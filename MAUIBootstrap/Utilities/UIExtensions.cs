using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Utilities;

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

        public static AccordionControl Header(this AccordionControl control, View view)
    {
        control.Header = view;
        return control;
    }

    public static AccordionControl AccordionContent(this AccordionControl control, View view)
    {
        control.AccordionContent = view;
        return control;
    }

    public static AlertControl Dismissable(this AlertControl control)
    {
        control.Dismissable = true;
        return control;
    }

    public static AlertControl NotDismissable(this AlertControl control)
    {
        control.Dismissable = false;
        return control;
    }

    public static AlertControl AlertContent(this AlertControl control, View view)
    {
        control.AlertContent = view;
        return control;
    }

    public static AlertControl Primary(this AlertControl control)
    {
        control.AlertType = AlertType.Primary;
        return control;
    }

    public static AlertControl Secondary(this AlertControl control)
    {
        control.AlertType = AlertType.Secondary;
        return control;
    }

    public static AlertControl Success(this AlertControl control)
    {
        control.AlertType = AlertType.Success;
        return control;
    }

    public static AlertControl Danger(this AlertControl control)
    {
        control.AlertType = AlertType.Danger;
        return control;
    }

    public static AlertControl Warning(this AlertControl control)
    {
        control.AlertType = AlertType.Warning;
        return control;
    }

    public static AlertControl Info(this AlertControl control)
    {
        control.AlertType = AlertType.Info;
        return control;
    }

    public static AlertControl Light(this AlertControl control)
    {
        control.AlertType = AlertType.Light;
        return control;
    }

    public static AlertControl Dark(this AlertControl control)
    {
        control.AlertType = AlertType.Dark;
        return control;
    }
}
