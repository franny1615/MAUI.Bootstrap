using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class BreadcrumbControlExtensions
{
    #region Breadcrumb Model
    public static Breadcrumb Name(this Breadcrumb breadcrumb, string name)
    {
        breadcrumb.Name = name;
        return breadcrumb;
    }

    public static Breadcrumb Selected(this Breadcrumb breadcrumb)
    {
        breadcrumb.IsSelected = true;
        breadcrumb.TextColor = Colors.DarkGray;
        return breadcrumb;
    }

    public static Breadcrumb NotSelected(this Breadcrumb breadcrumb)
    {
        breadcrumb.IsSelected = false;
        breadcrumb.TextColor = Color.FromArgb("#0d6efd");
        return breadcrumb;
    }
    #endregion

    #region Route Clicked
    public static T OnRouteClicked<T>(this T self, EventHandler<BreadcrumbEventArgs> handler)
        where T : BreadcrumbControl
    {
        self.RouteClicked += handler;
        return self;
    }
    #endregion

    #region Routes
    public static T Routes<T>(
        this T self, 
        List<Breadcrumb> source) where T : BreadcrumbControl
    {
        self.SetValue(BreadcrumbControl.RoutesProperty, source);
        return self;
    }

    public static T Routes<T>(
        this T self, 
        Func<PropertyContext<List<Breadcrumb>>, IPropertyBuilder<List<Breadcrumb>>> configure) where T : BreadcrumbControl
    {
        var context = new PropertyContext<List<Breadcrumb>>(self, BreadcrumbControl.RoutesProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> Routes<T>(
        this SettersContext<T> self,
        List<Breadcrumb> source)
        where T : BreadcrumbControl
    {
        self.XamlSetters.Add(new Setter { Property = BreadcrumbControl.RoutesProperty, Value = source });
        return self;
    }

    public static SettersContext<T> Routes<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<List<Breadcrumb>>, 
        IPropertySettersBuilder<List<Breadcrumb>>> configure) where T : BreadcrumbControl
    {
        var context = new PropertySettersContext<List<Breadcrumb>>(self.XamlSetters, BreadcrumbControl.RoutesProperty);
        configure(context).Build();
        return self;
    }
    #endregion 
}
