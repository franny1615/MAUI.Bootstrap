using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class AlertControlExtensions
{
    #region Dismissable
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
    #endregion 

    #region Alert Content
    public static T AlertContent<T>(
        this T self, 
        View source) where T : AlertControl
    {
        self.SetValue(AlertControl.AlertContentProperty, source);
        return self;
    }

    public static T AlertContent<T>(
        this T self, 
        Func<PropertyContext<View>, IPropertyBuilder<View>> configure) where T : AlertControl
    {
        var context = new PropertyContext<View>(self, AlertControl.AlertContentProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> AlertContent<T>(
        this SettersContext<T> self,
        View source)
        where T : AlertControl
    {
        self.XamlSetters.Add(new Setter { Property = AlertControl.AlertContentProperty, Value = source });
        return self;
    }

    public static SettersContext<T> AlertContent<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<View>, 
        IPropertySettersBuilder<View>> configure) where T : AlertControl
    {
        var context = new PropertySettersContext<View>(self.XamlSetters, AlertControl.AlertContentProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Timeout
    public static T Timeout<T>(
        this T self, 
        TimeSpan span) where T : AlertControl
    {
        self.SetValue(AlertControl.TimeoutProperty, span);
        return self;
    }

    public static T Timeout<T>(
        this T self, 
        Func<PropertyContext<TimeSpan>, IPropertyBuilder<TimeSpan>> configure) where T : AlertControl
    {
        var context = new PropertyContext<TimeSpan>(self, AlertControl.TimeoutProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Timeout<T>(
        this SettersContext<T> self,
        TimeSpan source)
        where T : AlertControl
    {
        self.XamlSetters.Add(new Setter { Property = AlertControl.TimeoutProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Timeout<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<TimeSpan>, 
        IPropertySettersBuilder<TimeSpan>> configure) where T : AlertControl
    {
        var context = new PropertySettersContext<TimeSpan>(self.XamlSetters, AlertControl.TimeoutProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Dismiss Icon
    public static T DismissIcon<T>(
        this T self, 
        ImageSource source) where T : AlertControl
    {
        self.SetValue(AlertControl.DismissIconProperty, source);
        return self;
    }

    public static T DismissIcon<T>(
        this T self, 
        Func<PropertyContext<ImageSource>, IPropertyBuilder<ImageSource>> configure) where T : AlertControl
    {
        var context = new PropertyContext<ImageSource>(self, AlertControl.DismissIconProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> DismissIcon<T>(
        this SettersContext<T> self,
        ImageSource source)
        where T : AlertControl
    {
        self.XamlSetters.Add(new Setter { Property = AlertControl.DismissIconProperty, Value = source });
        return self;
    }

    public static SettersContext<T> DismissIcon<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<ImageSource>, 
        IPropertySettersBuilder<ImageSource>> configure) where T : AlertControl
    {
        var context = new PropertySettersContext<ImageSource>(self.XamlSetters, AlertControl.DismissIconProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Styles
    public static AlertControl Primary(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.White)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#0d6efd"));
        return alertControl;
    }

    public static AlertControl Secondary(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.White)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#6c757d"));
        return alertControl;
    }

    public static AlertControl Success(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.White)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#198754"));
        return alertControl;
    }

    public static AlertControl Warning(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.Black)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#ffc107"));
        return alertControl;
    }

    public static AlertControl Danger(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.White)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#dc3545"));
        return alertControl;
    }

    public static AlertControl Info(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.Black)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#0dcaf0"));
        return alertControl;
    }

    public static AlertControl Light(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.Black)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#f8f9fa"));
        return alertControl;
    }

    public static AlertControl Dark(this AlertControl alertControl)
    {
        alertControl
            .DismissIcon(new FontImageSource()
                .FontFamily(nameof(MaterialIcon))
                .Glyph(MaterialIcon.Close)
                .Color(Colors.White)
                .Size(32))
            .BackgroundColor(Color.FromArgb("#212529"));
        return alertControl;
    }
    #endregion
}
