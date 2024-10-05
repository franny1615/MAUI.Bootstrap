using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Extensions;

public static class CheckboxControlExtensions
{
    #region IsChecked
    public static T IsChecked<T>(
        this T self, 
        bool source) where T : CheckboxControl
    {
        self.SetValue(CheckboxControl.IsCheckedProperty, source);
        return self;
    }

    public static T IsChecked<T>(
        this T self, 
        Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure) where T : CheckboxControl
    {
        var context = new PropertyContext<bool>(self, CheckboxControl.IsCheckedProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> IsChecked<T>(
        this SettersContext<T> self,
        bool source)
        where T : CheckboxControl
    {
        self.XamlSetters.Add(new Setter { Property = CheckboxControl.IsCheckedProperty, Value = source });
        return self;
    }

    public static SettersContext<T> IsChecked<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<bool>, 
        IPropertySettersBuilder<bool>> configure) where T : CheckboxControl
    {
        var context = new PropertySettersContext<bool>(self.XamlSetters, CheckboxControl.IsCheckedProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Selected 
    public static T SelectedColor<T>(
        this T self, 
        Color source) where T : CheckboxControl
    {
        self.SetValue(CheckboxControl.SelectedColorProperty, source);
        return self;
    }

    public static T SelectedColor<T>(
        this T self, 
        Func<PropertyContext<Color>, IPropertyBuilder<Color>> configure) where T : CheckboxControl
    {
        var context = new PropertyContext<Color>(self, CheckboxControl.SelectedColorProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> SelectedColor<T>(
        this SettersContext<T> self,
        Color source)
        where T : CheckboxControl
    {
        self.XamlSetters.Add(new Setter { Property = CheckboxControl.SelectedColorProperty, Value = source });
        return self;
    }

    public static SettersContext<T> SelectedColor<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<Color>, 
        IPropertySettersBuilder<Color>> configure) where T : CheckboxControl
    {
        var context = new PropertySettersContext<Color>(self.XamlSetters, CheckboxControl.SelectedColorProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Deselected
    public static T DeSelectedColor<T>(
        this T self, 
        Color source) where T : CheckboxControl
    {
        self.SetValue(CheckboxControl.DeSelectedColorProperty, source);
        return self;
    }

    public static T DeSelectedColor<T>(
        this T self, 
        Func<PropertyContext<Color>, IPropertyBuilder<Color>> configure) where T : CheckboxControl
    {
        var context = new PropertyContext<Color>(self, CheckboxControl.DeSelectedColorProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> DeSelectedColor<T>(
        this SettersContext<T> self,
        Color source)
        where T : CheckboxControl
    {
        self.XamlSetters.Add(new Setter { Property = CheckboxControl.DeSelectedColorProperty, Value = source });
        return self;
    }

    public static SettersContext<T> DeSelectedColor<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<Color>, 
        IPropertySettersBuilder<Color>> configure) where T : CheckboxControl
    {
        var context = new PropertySettersContext<Color>(self.XamlSetters, CheckboxControl.DeSelectedColorProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region OnCheckedChanged
    public static T OnCheckedChanged<T>(
        this T self, 
        EventHandler handler)
        where T : CheckboxControl
    {
        self.CheckChanged += handler;
        return self;
    }
    #endregion

    #region Styles
    public static CheckboxControl Primary(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.PrimaryShade)
            .DeSelectedColor(BootstrapColors.Primary);
        return checkboxControl;
    }

    public static CheckboxControl Secondary(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.SecondaryShade)
            .DeSelectedColor(BootstrapColors.Secondary);
        return checkboxControl;
    }

    public static CheckboxControl Success(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.SuccessShade)
            .DeSelectedColor(BootstrapColors.Success);
        return checkboxControl;
    }

    public static CheckboxControl Warning(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.WarningShade)
            .DeSelectedColor(BootstrapColors.Warning);
        return checkboxControl;
    }

    public static CheckboxControl Danger(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.DangerShade)
            .DeSelectedColor(BootstrapColors.Danger);
        return checkboxControl;
    }

    public static CheckboxControl Info(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.InfoShade)
            .DeSelectedColor(BootstrapColors.Info);
        return checkboxControl;
    }

    public static CheckboxControl Light(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.LightShade)
            .DeSelectedColor(BootstrapColors.Light);
        return checkboxControl;
    }

    public static CheckboxControl Dark(this CheckboxControl checkboxControl)
    {
        checkboxControl
            .StrokeShape(new RoundRectangle().CornerRadius(5))
            .Padding(8)
            .SelectedColor(BootstrapColors.DarkShade)
            .DeSelectedColor(BootstrapColors.Dark);
        return checkboxControl;
    }
    #endregion
}
