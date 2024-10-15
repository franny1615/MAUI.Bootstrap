using System;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class EntryExtensions
{
    #region IsBorderless
    public static T IsBorderless<T>(
        this T self, 
        bool source) where T : EntryControl
    {
        self.SetValue(EntryControl.IsBorderlessProperty, source);
        return self;
    }

    public static T IsBorderless<T>(
        this T self, 
        Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure) where T : EntryControl
    {
        var context = new PropertyContext<bool>(self, EntryControl.IsBorderlessProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> IsBorderless<T>(
        this SettersContext<T> self,
        bool source)
        where T : EntryControl
    {
        self.XamlSetters.Add(new Setter { Property = EntryControl.IsBorderlessProperty, Value = source });
        return self;
    }

    public static SettersContext<T> IsBorderless<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<bool>, 
        IPropertySettersBuilder<bool>> configure) where T : EntryControl
    {
        var context = new PropertySettersContext<bool>(self.XamlSetters, EntryControl.IsBorderlessProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}
