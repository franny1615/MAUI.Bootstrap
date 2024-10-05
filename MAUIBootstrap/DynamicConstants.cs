using CommunityToolkit.Mvvm.ComponentModel;

namespace MAUIBootstrap;

public partial class DynamicConstants : ObservableObject
{
    public static DynamicConstants Instance = new(); 

    [ObservableProperty]
    public string regularFont = "";

    [ObservableProperty]
    public string boldFont = "";
}
