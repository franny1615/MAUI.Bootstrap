using FmgLib.MauiMarkup;
using MAUIBootstrap.Controls;

namespace MAUIBootstrap.Extensions;

public static class PageControlExtensions
{
    #region Pagination Changed

    public static PaginationControl OnPageChanged(
        this PaginationControl control,
        EventHandler<PaginationEventArgs> handler)
    {
        control.PaginationChanged += handler;
        return control;
    }
    #endregion
    
    #region Current Page
    public static T CurrentPage<T>(
        this T self, 
        int source) where T : PaginationControl
    {
        self.SetValue(PaginationControl.CurrentPageProperty, source);
        return self;
    }

    public static T CurrentPage<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : PaginationControl
    {
        var context = new PropertyContext<int>(self, PaginationControl.CurrentPageProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> CurrentPage<T>(
        this SettersContext<T> self,
        int source)
        where T : PaginationControl
    {
        self.XamlSetters.Add(new Setter { Property = PaginationControl.CurrentPageProperty, Value = source });
        return self;
    }

    public static SettersContext<T> CurrentPage<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
            IPropertySettersBuilder<int>> configure) where T : PaginationControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, PaginationControl.CurrentPageProperty);
        configure(context).Build();
        return self;
    }
    #endregion
    
    #region Total Pages
    public static T TotalPages<T>(
        this T self, 
        int source) where T : PaginationControl
    {
        self.SetValue(PaginationControl.TotalPagesProperty, source);
        return self;
    }

    public static T TotalPages<T>(
        this T self, 
        Func<PropertyContext<int>, IPropertyBuilder<int>> configure) where T : PaginationControl
    {
        var context = new PropertyContext<int>(self, PaginationControl.TotalPagesProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> TotalPages<T>(
        this SettersContext<T> self,
        int source)
        where T : PaginationControl
    {
        self.XamlSetters.Add(new Setter { Property = PaginationControl.TotalPagesProperty, Value = source });
        return self;
    }

    public static SettersContext<T> TotalPages<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<int>, 
            IPropertySettersBuilder<int>> configure) where T : PaginationControl
    {
        var context = new PropertySettersContext<int>(self.XamlSetters, PaginationControl.TotalPagesProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}