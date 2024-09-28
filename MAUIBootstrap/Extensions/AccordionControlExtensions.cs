using System;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class AccordionControlExtensions
{
    #region Accordion Content
    public static T AccordionContent<T>(
        this T self, 
        View source) where T : AccordionControl
    {
        self.SetValue(AccordionControl.AccordionContentProperty, source);
        return self;
    }

    public static T AccordionContent<T>(
        this T self, 
        Func<PropertyContext<View>, IPropertyBuilder<View>> configure) where T : AccordionControl
    {
        var context = new PropertyContext<View>(self, AccordionControl.AccordionContentProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> AccordionContent<T>(
        this SettersContext<T> self,
        View source)
        where T : AccordionControl
    {
        self.XamlSetters.Add(new Setter { Property = AccordionControl.AccordionContentProperty, Value = source });
        return self;
    }

    public static SettersContext<T> AccordionContent<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<View>, 
        IPropertySettersBuilder<View>> configure) where T : AccordionControl
    {
        var context = new PropertySettersContext<View>(self.XamlSetters, AccordionControl.AccordionContentProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Accordion Header
    public static T Header<T>(
        this T self, 
        View source) where T : AccordionControl
    {
        self.SetValue(AccordionControl.HeaderProperty, source);
        return self;
    }

    public static T Header<T>(
        this T self, 
        Func<PropertyContext<View>, IPropertyBuilder<View>> configure) where T : AccordionControl
    {
        var context = new PropertyContext<View>(self, AccordionControl.HeaderProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Header<T>(
        this SettersContext<T> self,
        View source)
        where T : AccordionControl
    {
        self.XamlSetters.Add(new Setter { Property = AccordionControl.HeaderProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Header<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<View>, 
        IPropertySettersBuilder<View>> configure) where T : AccordionControl
    {
        var context = new PropertySettersContext<View>(self.XamlSetters, AccordionControl.HeaderProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Icon Size
    public static T IconSize<T>(
        this T self, 
        int source) where T : AccordionControl
    {
        self.SetValue(AccordionControl.IconSizeProperty, source);
        return self;
    }

    public static T IconSize<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : AccordionControl
    {
        var context = new PropertyContext<int>(self, AccordionControl.IconSizeProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> IconSize<T>(
        this SettersContext<T> self,
        int source)
        where T : AccordionControl
    {
        self.XamlSetters.Add(new Setter { Property = AccordionControl.IconSizeProperty, Value = source });
        return self;
    }

    public static SettersContext<T> IconSize<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
        IPropertySettersBuilder<int>> configure) where T : AccordionControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, AccordionControl.IconSizeProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}
