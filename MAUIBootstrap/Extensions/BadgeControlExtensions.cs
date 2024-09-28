using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Extensions;

public static class BadgeControlExtensions
{
    #region TEXT
    public static T Text<T>(
        this T self, 
        string text) where T : BadgeControl
    {
        self.SetValue(BadgeControl.TextProperty, text);
        return self;
    }

    public static T Text<T>(
        this T self, 
        Func<PropertyContext<string>, IPropertyBuilder<string>> configure) where T : BadgeControl
    {
        var context = new PropertyContext<string>(self, BadgeControl.TextProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Text<T>(
        this SettersContext<T> self,
        string text)
        where T : BadgeControl
    {
        self.XamlSetters.Add(new Setter { Property = BadgeControl.TextProperty, Value = text });
        return self;
    }

    public static SettersContext<T> Text<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<string>, 
        IPropertySettersBuilder<string>> configure) where T : BadgeControl
    {
        var context = new PropertySettersContext<string>(self.XamlSetters, BadgeControl.TextProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region TEXT COLOR 
    public static T TextColor<T>(
        this T self, 
        Color color) where T : BadgeControl
    {
        self.SetValue(BadgeControl.TextColorProperty, color);
        return self;
    }

    public static T TextColor<T>(
        this T self, 
        Func<PropertyContext<Color>, 
        IPropertyBuilder<Color>> configure) where T : BadgeControl
    {
        var context = new PropertyContext<Color>(self, BadgeControl.TextColorProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> TextColor<T>(
        this SettersContext<T> self,
        Color color)
        where T : BadgeControl
    {
        self.XamlSetters.Add(new Setter { Property = BadgeControl.TextColorProperty, Value = color });
        return self;
    }

    public static SettersContext<T> TextColor<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<Color>, 
        IPropertySettersBuilder<Color>> configure) where T : BadgeControl
    {
        var context = new PropertySettersContext<Color>(self.XamlSetters, BadgeControl.TextColorProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region TEXT SIZE
    public static T TextSize<T>(
        this T self, 
        double fontSize) where T : BadgeControl
    {
        self.SetValue(BadgeControl.TextSizeProperty, fontSize);
        return self;
    }

    public static T TextSize<T>(
        this T self, 
        Func<PropertyContext<double>, 
        IPropertyBuilder<double>> configure) where T : BadgeControl
    {
        var context = new PropertyContext<double>(self, BadgeControl.TextSizeProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> TextSize<T>(
        this SettersContext<T> self,
        double fontSize)
        where T : BadgeControl
    {
        self.XamlSetters.Add(new Setter { Property = BadgeControl.TextSizeProperty, Value = fontSize });
        return self;
    }

    public static SettersContext<T> TextSize<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<double>, 
        IPropertySettersBuilder<double>> configure) where T : BadgeControl
    {
        var context = new PropertySettersContext<double>(self.XamlSetters, BadgeControl.TextSizeProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region STYLES
    public static BadgeControl Primary(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.White)
            .BackgroundColor(Color.FromArgb("#0d6efd"));
        return badge;
    }

    public static BadgeControl Secondary(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.White)
            .BackgroundColor(Color.FromArgb("#6c757d"));
        return badge;
    }

    public static BadgeControl Success(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.White)
            .BackgroundColor(Color.FromArgb("#198754"));
        return badge;
    }

    public static BadgeControl Warning(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.Black)
            .BackgroundColor(Color.FromArgb("#ffc107"));
        return badge;
    }

    public static BadgeControl Danger(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.White)
            .BackgroundColor(Color.FromArgb("#dc3545"));
        return badge;
    }

    public static BadgeControl Info(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.Black)
            .BackgroundColor(Color.FromArgb("#0dcaf0"));
        return badge;
    }

    public static BadgeControl Light(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.Black)
            .BackgroundColor(Color.FromArgb("#f8f9fa"));
        return badge;
    }

    public static BadgeControl Dark(this BadgeControl badge)
    {
        badge
            .TextColor(Colors.White)
            .BackgroundColor(Color.FromArgb("#212529"));
        return badge;
    }

    public static BadgeControl Rounded(this BadgeControl badge)
    {
        var height = 
            badge.TextSize + 
            badge.Padding.Top +
            badge.Padding.Bottom;
        badge
            .StrokeShape(new RoundRectangle()
                .CornerRadius(height * 0.75));
        return badge;
    }
    #endregion
}
