using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Controls;

public class EntryControl : Entry
{
	public static readonly BindableProperty IsBorderlessProperty = BindableProperty.Create(
		nameof(IsBorderless),
		typeof(bool),
		typeof(EntryControl),
		false
	);
	public bool IsBorderless
	{
		get => (bool)GetValue(IsBorderlessProperty);
		set => SetValue(IsBorderlessProperty, value);
	}

	public EntryControl()
	{
		this
			.Margin(0)
			.MinimumHeightRequest(40);
	}
}