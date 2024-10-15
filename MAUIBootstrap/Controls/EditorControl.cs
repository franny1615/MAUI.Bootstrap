using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Controls;

public class EditorControl : Editor
{
	public static readonly BindableProperty IsBorderlessProperty = BindableProperty.Create(
		nameof(IsBorderless),
		typeof(bool),
		typeof(EditorControl),
		false
	);
	public bool IsBorderless
	{
		get => (bool)GetValue(IsBorderlessProperty);
		set => SetValue(IsBorderlessProperty, value);
	}

	public EditorControl()
	{
		this
			.Margin(0)
			.MinimumHeightRequest(40);
	}
}