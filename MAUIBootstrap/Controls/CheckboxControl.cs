using System.Runtime.CompilerServices;
using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Controls;

public class CheckboxControl : Border 
{
	public event EventHandler? CheckChanged;

	#region Bindable Properties
	public static readonly BindableProperty IsCheckedProperty = BindableProperty.Create(
		nameof(IsChecked),
		typeof(bool),
		typeof(CheckboxControl),
		false
	); 
	public bool IsChecked
	{
		get => (bool)GetValue(IsCheckedProperty);
		set => SetValue(IsCheckedProperty, value);
	}

	public static readonly BindableProperty SelectedColorProperty = BindableProperty.Create(
		nameof(SelectedColor),
		typeof(Color),
		typeof(CheckboxControl)
	); 
	public Color SelectedColor
	{
		get => (Color)GetValue(SelectedColorProperty);
		set => SetValue(SelectedColorProperty, value);
	}

	public static readonly BindableProperty DeSelectedColorProperty = BindableProperty.Create(
		nameof(DeSelectedColor),
		typeof(Color),
		typeof(CheckboxControl)
	); 
	public Color DeSelectedColor
	{
		get => (Color)GetValue(DeSelectedColorProperty);
		set => SetValue(DeSelectedColorProperty, value);
	}
	#endregion

	public CheckboxControl() 
	{
		this.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped(async (s, e) => {
					await this.ScaleTo(0.95, 70);
					await this.ScaleTo(1.0, 70);
					IsChecked = !IsChecked;
					CheckChanged?.Invoke(this, EventArgs.Empty);
				})
		]);
		this.Stroke(e => e.Path(nameof(SelectedColor)).Source(this));
	}

	#region Methods
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == IsCheckedProperty.PropertyName) 
		{
			if (IsChecked) 
				this.BackgroundColor(SelectedColor);
			else 
				this.BackgroundColor(DeSelectedColor);
		} 
		else if (propertyName == DeSelectedColorProperty.PropertyName)
		{
			this.BackgroundColor(DeSelectedColor);
		}
    }
	#endregion
}