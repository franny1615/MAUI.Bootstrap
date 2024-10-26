using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class TabModelExtensions
{
    public static TabModel MaterialIcon(
        this TabModel tabModel,
        string icon)
    {
        tabModel.MaterialIcon = icon;
        return tabModel;
    }

    public static TabModel TranslateKey(
        this TabModel tabModel,
        string newKey)
    {
        tabModel.TranslateKey = newKey;
        return tabModel;
    }

    public static TabModel Active(this TabModel tabModel)
    {
        tabModel.IsActive = true;
        return tabModel;
    }

    public static TabModel NotActive(this TabModel tabModel)
    {
        tabModel.IsActive = false;
        return tabModel;
    }

    public static TabControl Horizontal(this TabControl control)
    {
        control.Orientation = TabOrientation.Horizontal;
        return control;
    }

    public static TabControl Vertical(this TabControl control)
    {
        control.Orientation = TabOrientation.Vertical;
        return control;
    }

    #region Tab Selected
    public static TabControl OnTabSelected(
        this TabControl control,
        EventHandler<TabEventArgs> tabSelected)
    {
        control.TabSelected += tabSelected;
        return control;
    }
    #endregion

    #region Tabs
    public static T Tabs<T>(
        this T self,
        List<TabModel> source) where T : TabControl
    {
        self.SetValue(TabControl.TabsProperty, source);
        return self;
    }

    public static T Tabs<T>(
        this T self,
        Func<PropertyContext<List<TabModel>>, IPropertyBuilder<List<TabModel>>> configure) where T : TabControl
    {
        var context = new PropertyContext<List<TabModel>>(self, TabControl.TabsProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Tabs<T>(
        this SettersContext<T> self,
        List<TabModel> source)
        where T : TabControl
    {
        self.XamlSetters.Add(new Setter { Property = TabControl.TabsProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Tabs<T>(
        this SettersContext<T> self,
        Func<PropertySettersContext<List<TabModel>>,
        IPropertySettersBuilder<List<TabModel>>> configure) where T : TabControl
    {
        var context = new PropertySettersContext<List<TabModel>>(self.XamlSetters, TabControl.TabsProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}
