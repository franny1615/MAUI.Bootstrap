using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Extensions;

public static class RadioButtonExtensions
{
    public static RadioButton Bootstrap(this RadioButton radioButton)
    {
        radioButton.SetDynamicResource(
            RadioButton.ControlTemplateProperty, 
            "RadioButtonTemplate");
        return radioButton;
    }
}
