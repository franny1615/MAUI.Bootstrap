using FmgLib.MauiMarkup;
using MAUIBootstrap.Popups;

namespace MAUIBootstrap.Extensions;

public static class DropdownExtensions
{
    public static DropdownItemControl OnTapped(
        this DropdownItemControl control,
        EventHandler tapped)
    {
        control.Tapped += tapped;
        return control;
    }

    public static Dropdown OnItemSelected(
        this Dropdown popup,
        EventHandler<DropdownEventArgs> selectedItem)
    {
        popup.SelectedItem += selectedItem;
        return popup;
    }

    #region Items
    public static T DropdownItems<T>(
        this T self, 
        List<DropdownItem> source) where T : Dropdown
    {
        self.SetValue(Dropdown.ItemsProperty, source);
        return self;
    }

    public static T DropdownItems<T>(
        this T self, 
        Func<PropertyContext<List<DropdownItem>>, IPropertyBuilder<List<DropdownItem>>> configure) where T : Dropdown
    {
        var context = new PropertyContext<List<DropdownItem>>(self, Dropdown.ItemsProperty);
        configure(context).Build();
        return self;
    }

    public static SettersContext<T> DropdownItems<T>(
        this SettersContext<T> self,
        List<DropdownItem> source)
        where T : Dropdown
    {
        self.XamlSetters.Add(new Setter { Property = Dropdown.ItemsProperty, Value = source });
        return self;
    }

    public static SettersContext<T> DropdownItems<T>(
        this SettersContext<T> self, 
        Func<PropertySettersContext<List<DropdownItem>>, 
        IPropertySettersBuilder<List<DropdownItem>>> configure) where T : Dropdown
    {
        var context = new PropertySettersContext<List<DropdownItem>>(self.XamlSetters, Dropdown.ItemsProperty);
        configure(context).Build();
        return self;
    }
    #endregion
}
