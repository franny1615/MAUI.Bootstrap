namespace MAUIBootstrap;

public static class BootstrapColors
{
    public static AppTheme CurrentTheme
    {
        get => (AppTheme)Preferences.Default.Get(nameof(CurrentTheme), (int)AppTheme.Light);
        set
        {
            Preferences.Default.Set(nameof(CurrentTheme), (int)value);
            switch (value)
            {
                case AppTheme.Dark:
                    PageColor = PageColorDark;
                    PageTitleColor = PageTitleColorDark;
                    NavigationBarColor = NavigationBarColorDark;
                    TextColor = TextColorDark;
                    break;
                case AppTheme.Light:
                    PageColor = PageColorLight;
                    PageTitleColor = PageTitleColorLight;
                    NavigationBarColor = NavigationBarColorLight;
                    TextColor = TextColorLight;
                    break;
            }
        }
    }
    public static Color Primary 
    { 
        get => ResourceHelpers.GetColor(nameof(Primary)); 
        set => ResourceHelpers.SetColor(nameof(Primary), value); 
    }
    public static Color Secondary
    { 
        get => ResourceHelpers.GetColor(nameof(Secondary)); 
        set => ResourceHelpers.SetColor(nameof(Secondary), value); 
    }
    public static Color Success
    { 
        get => ResourceHelpers.GetColor(nameof(Success)); 
        set => ResourceHelpers.SetColor(nameof(Success), value); 
    }
    public static Color Warning
    { 
        get => ResourceHelpers.GetColor(nameof(Warning)); 
        set => ResourceHelpers.SetColor(nameof(Warning), value); 
    }
    public static Color Danger
    { 
        get => ResourceHelpers.GetColor(nameof(Danger)); 
        set => ResourceHelpers.SetColor(nameof(Danger), value); 
    }
    public static Color Info
    { 
        get => ResourceHelpers.GetColor(nameof(Info)); 
        set => ResourceHelpers.SetColor(nameof(Info), value); 
    }
    public static Color Light
    { 
        get => ResourceHelpers.GetColor(nameof(Light)); 
        set => ResourceHelpers.SetColor(nameof(Light), value); 
    }
    public static Color Dark 
    { 
        get => ResourceHelpers.GetColor(nameof(Dark)); 
        set => ResourceHelpers.SetColor(nameof(Dark), value); 
    }
    public static Color Link
    { 
        get => ResourceHelpers.GetColor(nameof(Link)); 
        set => ResourceHelpers.SetColor(nameof(Link), value); 
    }
    public static Color PrimaryShade
    { 
        get => ResourceHelpers.GetColor(nameof(PrimaryShade)); 
        set => ResourceHelpers.SetColor(nameof(PrimaryShade), value); 
    }
    public static Color SecondaryShade
    { 
        get => ResourceHelpers.GetColor(nameof(SecondaryShade)); 
        set => ResourceHelpers.SetColor(nameof(SecondaryShade), value); 
    }
    public static Color SuccessShade 
    { 
        get => ResourceHelpers.GetColor(nameof(SuccessShade)); 
        set => ResourceHelpers.SetColor(nameof(SuccessShade), value); 
    }
    public static Color WarningShade 
    { 
        get => ResourceHelpers.GetColor(nameof(WarningShade)); 
        set => ResourceHelpers.SetColor(nameof(WarningShade), value); 
    }
    public static Color DangerShade
    { 
        get => ResourceHelpers.GetColor(nameof(DangerShade)); 
        set => ResourceHelpers.SetColor(nameof(DangerShade), value); 
    }
    public static Color InfoShade
    { 
        get => ResourceHelpers.GetColor(nameof(InfoShade)); 
        set => ResourceHelpers.SetColor(nameof(InfoShade), value); 
    }
    public static Color LightShade
    { 
        get => ResourceHelpers.GetColor(nameof(LightShade)); 
        set => ResourceHelpers.SetColor(nameof(LightShade), value); 
    }
    public static Color DarkShade 
    { 
        get => ResourceHelpers.GetColor(nameof(DarkShade)); 
        set => ResourceHelpers.SetColor(nameof(DarkShade), value); 
    }
    public static Color PageColor
    { 
        get => ResourceHelpers.GetColor(nameof(PageColor)); 
        set => ResourceHelpers.SetColor(nameof(PageColor), value); 
    }
    public static Color PageColorLight
    { 
        get => ResourceHelpers.GetColor(nameof(PageColorLight)); 
        set => ResourceHelpers.SetColor(nameof(PageColorLight), value); 
    }
    public static Color PageColorDark
    { 
        get => ResourceHelpers.GetColor(nameof(PageColorDark)); 
        set => ResourceHelpers.SetColor(nameof(PageColorDark), value); 
    }
    public static Color PageTitleColor
    { 
        get => ResourceHelpers.GetColor(nameof(PageTitleColor)); 
        set => ResourceHelpers.SetColor(nameof(PageTitleColor), value); 
    }
    public static Color PageTitleColorLight
    { 
        get => ResourceHelpers.GetColor(nameof(PageTitleColorLight)); 
        set => ResourceHelpers.SetColor(nameof(PageTitleColorLight), value); 
    }
    public static Color PageTitleColorDark
    { 
        get => ResourceHelpers.GetColor(nameof(PageTitleColorDark)); 
        set => ResourceHelpers.SetColor(nameof(PageTitleColorDark), value); 
    }
    public static Color NavigationBarColor
    { 
        get => ResourceHelpers.GetColor(nameof(NavigationBarColor)); 
        set => ResourceHelpers.SetColor(nameof(NavigationBarColor), value); 
    }
    public static Color NavigationBarColorLight
    { 
        get => ResourceHelpers.GetColor(nameof(NavigationBarColorLight)); 
        set => ResourceHelpers.SetColor(nameof(NavigationBarColorLight), value); 
    }
    public static Color NavigationBarColorDark
    { 
        get => ResourceHelpers.GetColor(nameof(NavigationBarColorDark)); 
        set => ResourceHelpers.SetColor(nameof(NavigationBarColorDark), value); 
    }
    public static Color TextColor
    {
        get => ResourceHelpers.GetColor(nameof(TextColor)); 
        set => ResourceHelpers.SetColor(nameof(TextColor), value); 
    }
    public static Color TextColorLight
    {
        get => ResourceHelpers.GetColor(nameof(TextColorLight)); 
        set => ResourceHelpers.SetColor(nameof(TextColorLight), value); 
    }
    public static Color TextColorDark
    {
        get => ResourceHelpers.GetColor(nameof(TextColorDark)); 
        set => ResourceHelpers.SetColor(nameof(TextColorDark), value); 
    }
}

public static class ResourceHelpers
{
    public static string GetString(string key)
    {
        if (Application.Current == null)
            return string.Empty;
        return Application.Current.Resources[key] as string ?? string.Empty;
    }

    public static void SetString(string key, string value)
    {
        if (Application.Current == null)
            return;
        Application.Current.Resources[key] = value;
    }

    public static Color GetColor(string key)
    {
        if (Application.Current == null)
            return Colors.Black;
        return Application.Current.Resources[key] as Color ?? Colors.Black;
    }

    public static void SetColor(string key, Color color)
    {
        if (Application.Current == null)
            return;
        Application.Current.Resources[key] = color;
    }
}
