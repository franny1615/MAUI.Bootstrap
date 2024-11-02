using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class RoundRectSpinnerControlExtensions
{
    #region StrokeThickness
    public static T StrokeThickness<T>(
        this T self, 
        int source) where T : RoundRectSpinnerControl
    {
        self.SetValue(RoundRectSpinnerControl.StrokeThicknessProperty, source);
        return self;
    }

    public static T StrokeThickness<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertyContext<int>(self, RoundRectSpinnerControl.StrokeThicknessProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> StrokeThickness<T>(
        this SettersContext<T> self,
        int source)
        where T : RoundRectSpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = RoundRectSpinnerControl.StrokeThicknessProperty, Value = source });
        return self;
    }

    public static SettersContext<T> StrokeThickness<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
            IPropertySettersBuilder<int>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, RoundRectSpinnerControl.StrokeThicknessProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region CornerRadius
    public static T CornerRadius<T>(
        this T self, 
        int source) where T : RoundRectSpinnerControl
    {
        self.SetValue(RoundRectSpinnerControl.CornerRadiusProperty, source);
        return self;
    }

    public static T CornerRadius<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertyContext<int>(self, RoundRectSpinnerControl.CornerRadiusProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> CornerRadius<T>(
        this SettersContext<T> self,
        int source)
        where T : RoundRectSpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = RoundRectSpinnerControl.CornerRadiusProperty, Value = source });
        return self;
    }

    public static SettersContext<T> CornerRadius<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
            IPropertySettersBuilder<int>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, RoundRectSpinnerControl.CornerRadiusProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region IsLoading
    public static RoundRectSpinnerControl Start(this RoundRectSpinnerControl spinner)
    {
        spinner.IsLoading = true;
        return spinner;
    }

    public static RoundRectSpinnerControl Stop(this RoundRectSpinnerControl spinner)
    {
        spinner.IsLoading = false;
        return spinner;
    }
    #endregion
    
    #region GradientColors
    public static T GradientColors<T>(
        this T self, 
        List<Color> source) where T : RoundRectSpinnerControl
    {
        self.SetValue(RoundRectSpinnerControl.GradientColorsProperty, source);
        return self;
    }

    public static T GradientColors<T>(
        this T self, 
        Func<PropertyContext<List<Color>>, IPropertyBuilder<List<Color>>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertyContext<List<Color>>(self, RoundRectSpinnerControl.GradientColorsProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> GradientColors<T>(
        this SettersContext<T> self,
        List<Color> source)
        where T : RoundRectSpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = RoundRectSpinnerControl.GradientColorsProperty, Value = source });
        return self;
    }

    public static SettersContext<T> GradientColors<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<List<Color>>, 
            IPropertySettersBuilder<List<Color>>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertySettersContext<List<Color>>(self.XamlSetters, RoundRectSpinnerControl.GradientColorsProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region StaticBorderColor
    public static T StaticBorderColor<T>(
        this T self, 
        Color source) where T : RoundRectSpinnerControl
    {
        self.SetValue(RoundRectSpinnerControl.StaticBorderColorProperty, source);
        return self;
    }

    public static T StaticBorderColor<T>(
        this T self, 
        Func<PropertyContext<Color>, IPropertyBuilder<Color>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertyContext<Color>(self, RoundRectSpinnerControl.StaticBorderColorProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> StaticBorderColor<T>(
        this SettersContext<T> self,
        Color source)
        where T : RoundRectSpinnerControl
    {
        self.XamlSetters.Add(new Setter { Property = RoundRectSpinnerControl.StaticBorderColorProperty, Value = source });
        return self;
    }

    public static SettersContext<T> StaticBorderColor<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<Color>, 
            IPropertySettersBuilder<Color>> configure) where T : RoundRectSpinnerControl
    {
        var context = new PropertySettersContext<Color>(self.XamlSetters, RoundRectSpinnerControl.StaticBorderColorProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}