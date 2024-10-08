namespace MAUIBootstrap;

public class DynamicConstants
{
    public static DynamicConstants Instance = new(); 

    public string RegularFont
    {
        get => ResourceHelpers.GetString(nameof(RegularFont)); 
        set => ResourceHelpers.SetString(nameof(RegularFont), value); 
    }

    public string BoldFont
    {
        get => ResourceHelpers.GetString(nameof(BoldFont)); 
        set => ResourceHelpers.SetString(nameof(BoldFont), value); 
    }
}
