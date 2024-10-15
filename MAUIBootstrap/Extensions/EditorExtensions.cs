using System;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class EditorExtensions
{
    #region IsBorderless
    public static T IsBorderless<T>(
        this T self, 
        bool source) where T : EditorControl
    {
        self.SetValue(EditorControl.IsBorderlessProperty, source);
        return self;
    }

    public static T IsBorderless<T>(
        this T self, 
        Func<PropertyContext<bool>, IPropertyBuilder<bool>> configure) where T : EditorControl
    {
        var context = new PropertyContext<bool>(self, EditorControl.IsBorderlessProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> IsBorderless<T>(
        this SettersContext<T> self,
        bool source)
        where T : EditorControl
    {
        self.XamlSetters.Add(new Setter { Property = EditorControl.IsBorderlessProperty, Value = source });
        return self;
    }

    public static SettersContext<T> IsBorderless<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<bool>, 
        IPropertySettersBuilder<bool>> configure) where T : EditorControl
    {
        var context = new PropertySettersContext<bool>(self.XamlSetters, EditorControl.IsBorderlessProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}
