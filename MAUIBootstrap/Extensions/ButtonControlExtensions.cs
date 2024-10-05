using System;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Extensions;

public static class ButtonControlExtensions
{
    #region OnTapped
    public static T OnTapped<T>(
        this T self, 
        EventHandler tapped)
        where T : ButtonControl
    {
        self.Tapped += tapped;
        return self;
    }
    #endregion

    #region Styles
    public static ButtonControl Primary(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Primary);
        return buttonControl;
    }

    public static ButtonControl Secondary(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Secondary);
        return buttonControl;
    }

    public static ButtonControl Success(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Success);
        return buttonControl;
    }

    public static ButtonControl Warning(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Warning);
        return buttonControl;
    }

    public static ButtonControl Danger(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Danger);
        return buttonControl;
    }

    public static ButtonControl Info(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Info);
        return buttonControl;
    }

    public static ButtonControl Light(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Light);
        return buttonControl;
    }

    public static ButtonControl Dark(this ButtonControl buttonControl)
    {
        buttonControl
            .Stroke(Colors.Transparent)
            .StrokeThickness(0)
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .BackgroundColor(BootstrapColors.Dark);
        return buttonControl;
    }

    public static ButtonControl Outlined(this ButtonControl button)
    {
        button
            .Stroke(Colors.Transparent) 
            .Stroke(button.BackgroundColor)
            .StrokeThickness(1)
            .BackgroundColor(Colors.Transparent);
        return button;
    }

    public static ButtonControl Disabled(this ButtonControl button)
    {
        Color capturedColor = button.StrokeThickness == 0 ?
            button.BackgroundColor :
            (button.Stroke as SolidColorBrush)!.Color;
        if (button.StrokeThickness == 0) 
        {
            button.BackgroundColor(capturedColor.WithAlpha(0.5f));
        }
        else 
        {
            button.Stroke(capturedColor.WithAlpha(0.5f));
        }
        button.IsEnabled(false);
        return button;
    }

    public static ButtonControl Enabled(this ButtonControl button)
    {
        Color capturedColor = button.StrokeThickness == 0 ?
            button.BackgroundColor :
            (button.Stroke as SolidColorBrush)!.Color;
        if (button.StrokeThickness == 0) 
        {
            button.BackgroundColor(capturedColor.WithAlpha(1));
        }
        else 
        {
            button.Stroke(capturedColor.WithAlpha(1));
        }
        button.IsEnabled(true);
        return button;
    }

    public static ButtonControl SharpCorners(this ButtonControl button)
    {
        button.StrokeShape = new RoundRectangle().CornerRadius(0);
        return button;
    }
    #endregion
}
