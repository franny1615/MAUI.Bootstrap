using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class SpinnerControlExtensions
{
    #region Diameter
    public static T Diameter<T>(
        this T self, 
        int source) where T : SpinnerControl
    {
        self.SetValue(SpinnerControl.DiameterProperty, source);
        return self;
    }

    public static T Diameter<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : SpinnerControl
    {
        var context = new PropertyContext<int>(self, SpinnerControl.DiameterProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Diameter<T>(
        this SettersContext<T> self,
        int source)
        where T : SpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = SpinnerControl.DiameterProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Diameter<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
            IPropertySettersBuilder<int>> configure) where T : SpinnerControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, SpinnerControl.DiameterProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region Color
    public static T Color<T>(
        this T self, 
        Color source) where T : SpinnerControl
    {
        self.SetValue(SpinnerControl.ColorProperty, source);
        return self;
    }

    public static T Color<T>(
        this T self, 
        Func<PropertyContext<Color>, IPropertyBuilder<Color>> configure) where T : SpinnerControl
    {
        var context = new PropertyContext<Color>(self, SpinnerControl.ColorProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Color<T>(
        this SettersContext<T> self,
        Color source)
        where T : SpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = SpinnerControl.ColorProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Color<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<Color>, 
            IPropertySettersBuilder<Color>> configure) where T : SpinnerControl
    {
        var context = new PropertySettersContext<Color>(self.XamlSetters, SpinnerControl.ColorProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region StrokeThickness
    public static T StrokeThickness<T>(
        this T self, 
        int source) where T : SpinnerControl
    {
        self.SetValue(SpinnerControl.StrokeThicknessProperty, source);
        return self;
    }

    public static T StrokeThickness<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : SpinnerControl
    {
        var context = new PropertyContext<int>(self, SpinnerControl.StrokeThicknessProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> StrokeThickness<T>(
        this SettersContext<T> self,
        int source)
        where T : SpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = SpinnerControl.StrokeThicknessProperty, Value = source });
        return self;
    }

    public static SettersContext<T> StrokeThickness<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
            IPropertySettersBuilder<int>> configure) where T : SpinnerControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, SpinnerControl.StrokeThicknessProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region IsLoading
    public static SpinnerControl Start(this SpinnerControl spinner)
    {
        spinner.IsLoading = true;
        return spinner;
    }

    public static SpinnerControl Stop(this SpinnerControl spinner)
    {
        spinner.IsLoading = false;
        return spinner;
    }
    #endregion
}