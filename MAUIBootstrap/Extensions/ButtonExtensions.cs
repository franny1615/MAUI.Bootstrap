using FmgLib.MauiMarkup;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Extensions;

public static class ButtonExtensions
{
    #region Styles
    public static Button Primary(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.White)
            .BackgroundColor(BootstrapColors.Primary);
        return button;
    }

    public static Button Secondary(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.White)
            .BackgroundColor(BootstrapColors.Secondary);
        return button;
    }

    public static Button Success(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.White)
            .BackgroundColor(BootstrapColors.Success);
        return button;
    }

    public static Button Warning(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.Black)
            .BackgroundColor(BootstrapColors.Warning);
        return button;
    }

    public static Button Danger(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.White)
            .BackgroundColor(BootstrapColors.Danger);
        return button;
    }

    public static Button Info(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.Black)
            .BackgroundColor(BootstrapColors.Info);
        return button;
    }

    public static Button Light(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.Black)
            .BackgroundColor(BootstrapColors.Light);
        return button;
    }

    public static Button Dark(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(5)
            .TextColor(Colors.White)
            .BackgroundColor(BootstrapColors.Dark);
        return button;
    }

    public static Button Link(this Button button)
    {
        button
            .FontSize(15)
            .BorderColor(Colors.Transparent)
            .BorderWidth(0)
            .Padding(8)
            .CornerRadius(0)
            .TextColor(BootstrapColors.Link)
            .BackgroundColor(Colors.Transparent);
        return button;
    }

    public static Button Outlined(this Button button)
    {
        button
            .BorderColor(button.BackgroundColor)
            .TextColor(button.BackgroundColor)
            .BorderWidth(1)
            .BackgroundColor(Colors.Transparent);
        return button;
    }

    public static Button Disabled(this Button button)
    {
        Color capturedColor = button.BorderWidth == 0 ?
            button.BackgroundColor :
            button.BorderColor;
        if (button.BorderWidth == 0) 
        {
            button.BackgroundColor(capturedColor.WithAlpha(0.5f));
        }
        else 
        {
            button
                .BorderColor(capturedColor.WithAlpha(0.5f))
                .TextColor(capturedColor.WithAlpha(0.5f));
        }
        button.IsEnabled(false);
        return button;
    }

    public static Button Enabled(this Button button)
    {
        Color capturedColor = button.BorderWidth == 0 ?
            button.BackgroundColor :
            button.BorderColor;
        if (button.BorderWidth == 0) 
        {
            button.BackgroundColor(capturedColor.WithAlpha(1));
        }
        else 
        {
            button
                .BorderColor(capturedColor.WithAlpha(1))
                .TextColor(capturedColor.WithAlpha(1));
        }
        button.IsEnabled(true);
        return button;
    }

    public static Button SharpCorners(this Button button)
    {
        button.CornerRadius = 0;
        return button;
    }

    public static RadioButton Bootstrap(
        this RadioButton radioButton,
        Color selected,
        Color deselected)
    {
        radioButton.ControlTemplate(new ControlTemplate(() => {
            var border = new Border()
                .Stroke(deselected)
                .BackgroundColor(Colors.Transparent)
                .Padding(8)
                .StrokeShape(new RoundRectangle().CornerRadius(5))
                .VisualStateGroups([
                    new VisualStateGroup()
                        .Name("CheckedStates")
                        .States([
                            new VisualState()
                                .Name("Checked")
                                .Setters([
                                    new Setter()
                                    {
                                        Property = Border.BackgroundColorProperty,
                                        Value = selected
                                    }
                                ]),
                            new VisualState()
                                .Name("Unchecked")
                                .Setters([
                                    new Setter()
                                    {
                                        Property = Border.BackgroundColorProperty,
                                        Value = deselected
                                    }
                                ])
                        ])
                ]);
            border.Content(new ContentPresenter());
            return border;
        }));
        return radioButton;
    }
    #endregion
}
