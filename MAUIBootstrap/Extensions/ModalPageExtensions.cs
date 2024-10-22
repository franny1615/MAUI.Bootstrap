using System;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Pages;

namespace MAUIBootstrap.Extensions;

public static class ModalPageExtensions
{
    #region Closed Event
    public static T OnClosed<T>(
        this T self, 
        EventHandler closed)
        where T : ModalPage 
    {
        self.Closed += closed;
        return self;
    }
    #endregion

    #region Header
    public static T ModalHeader<T>(
        this T self, 
        View source) where T : ModalPage
    {
        self.SetValue(ModalPage.HeaderProperty, source);
        return self;
    }

    public static T ModalHeader<T>(
        this T self, 
        Func<PropertyContext<View>, IPropertyBuilder<View>> configure) where T : ModalPage
    {
        var context = new PropertyContext<View>(self, ModalPage.HeaderProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> ModalHeader<T>(
        this SettersContext<T> self,
        View source)
        where T : ModalPage
    {
        self.XamlSetters.Add(new Setter { Property = ModalPage.HeaderProperty, Value = source });
        return self;
    }

    public static SettersContext<T> ModalHeader<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<View>, 
        IPropertySettersBuilder<View>> configure) where T : ModalPage
    {
        var context = new PropertySettersContext<View>(self.XamlSetters, ModalPage.HeaderProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region Body
    public static T Body<T>(
        this T self, 
        View source) where T : ModalPage
    {
        self.SetValue(ModalPage.BodyProperty, source);
        return self;
    }

    public static T Body<T>(
        this T self, 
        Func<PropertyContext<View>, IPropertyBuilder<View>> configure) where T : ModalPage
    {
        var context = new PropertyContext<View>(self, ModalPage.BodyProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Body<T>(
        this SettersContext<T> self,
        View source)
        where T : ModalPage
    {
        self.XamlSetters.Add(new Setter { Property = ModalPage.BodyProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Body<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<View>, 
        IPropertySettersBuilder<View>> configure) where T : ModalPage
    {
        var context = new PropertySettersContext<View>(self.XamlSetters, ModalPage.BodyProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region IsFullScreen
    public static T IsFullScreen<T>(
        this T self, 
        bool source) where T : ModalPage
    {
        self.SetValue(ModalPage.IsFullScreenProperty, source);
        return self;
    }

    public static T IsFullScreen<T>(
        this T self, 
        Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure) where T : ModalPage
    {
        var context = new PropertyContext<bool>(self, ModalPage.IsFullScreenProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> IsFullScreen<T>(
        this SettersContext<T> self,
        bool source)
        where T : ModalPage
    {
        self.XamlSetters.Add(new Setter { Property = ModalPage.IsFullScreenProperty, Value = source });
        return self;
    }

    public static SettersContext<T> IsFullScreen<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<bool>, 
        IPropertySettersBuilder<bool>> configure) where T : ModalPage
    {
        var context = new PropertySettersContext<bool>(self.XamlSetters, ModalPage.IsFullScreenProperty);
        configure(context).Build();
        return self;
    }
    #endregion

    #region IsCloseVisible
    public static T IsCloseVisible<T>(
        this T self, 
        bool source) where T : ModalPage
    {
        self.SetValue(ModalPage.IsCloseVisibleProperty, source);
        return self;
    }

    public static T IsCloseVisible<T>(
        this T self, 
        Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure) where T : ModalPage
    {
        var context = new PropertyContext<bool>(self, ModalPage.IsCloseVisibleProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> IsCloseVisible<T>(
        this SettersContext<T> self,
        bool source)
        where T : ModalPage
    {
        self.XamlSetters.Add(new Setter { Property = ModalPage.IsCloseVisibleProperty, Value = source });
        return self;
    }

    public static SettersContext<T> IsCloseVisible<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<bool>, 
        IPropertySettersBuilder<bool>> configure) where T : ModalPage
    {
        var context = new PropertySettersContext<bool>(self.XamlSetters, ModalPage.IsCloseVisibleProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}
