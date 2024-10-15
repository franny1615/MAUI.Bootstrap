using System.Runtime.CompilerServices;
using CommunityToolkit.Maui.Views;
using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Extensions;
using Microsoft.Maui.Controls.Shapes;

namespace MAUIBootstrap.Popups;

public partial class DropdownItem : ObservableObject
{
	[ObservableProperty]
	private string translateKey = string.Empty;

	[ObservableProperty]
	private string materialIcon = string.Empty;
}

public class DropdownEventArgs : EventArgs 
{
	public DropdownItem? SelectedItem { get; set; } = null;
}

public class Dropdown : Border   
{
	public event EventHandler<DropdownEventArgs>? SelectedItem;

	public static readonly BindableProperty ItemsProperty = BindableProperty.Create(
		nameof(Items),
		typeof(List<DropdownItem>),
		typeof(Dropdown),
		new List<DropdownItem>()
	);
	public List<DropdownItem> Items
	{
		get => (List<DropdownItem>)GetValue(ItemsProperty);
		set => SetValue(ItemsProperty, value);
	}

	private readonly VerticalStackLayout _ContentLayout = new VerticalStackLayout()
		.Spacing(0);

	public Dropdown()
	{
		Content = _ContentLayout;
		this
			.Stroke(BootstrapColors.Secondary)
			.StrokeShape(new RoundRectangle().CornerRadius(5))
			.Content(_ContentLayout);
		this.SetDynamicResource(Border.BackgroundColorProperty, nameof(BootstrapColors.DropdownBG));
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == ItemsProperty.PropertyName)
		{
			LayoutItems();
		}
    }

	private void LayoutItems()
	{
		if (_ContentLayout == null) return;

		_ContentLayout.Clear();

		if (Items == null) return;

		for (int i = 0; i < Items.Count; i++)
		{
			var dropdownItem = new DropdownItemControl();
			dropdownItem.BindingContext = Items[i];
			dropdownItem.SetBinding(DropdownItemControl.TranslateKeyProperty, nameof(DropdownItem.TranslateKey));
			dropdownItem.SetBinding(DropdownItemControl.MaterialIconProperty, nameof(DropdownItem.MaterialIcon));
			dropdownItem.OnTapped((s,e) => {
				if (s is DropdownItemControl control && control.BindingContext is DropdownItem item) 
				{
					SelectedItem?.Invoke(this, new DropdownEventArgs
					{
						SelectedItem = item,
					});
				}
			});
			_ContentLayout.Add(dropdownItem);

			if (i < (Items.Count - 1))
			{
				_ContentLayout.Add(new BoxView().MakeDivider(BootstrapColors.Secondary));
			}
		}
	}
}

public class DropdownItemControl : Grid 
{
	public event EventHandler? Tapped;

	public static readonly BindableProperty TranslateKeyProperty = BindableProperty.Create(
		nameof(TranslateKey),
		typeof(string),
		typeof(DropdownItemControl),
		string.Empty
	);
	public string TranslateKey
	{
		get => (string)GetValue(TranslateKeyProperty);
		set => SetValue(TranslateKeyProperty, value);
	}

	public static readonly BindableProperty MaterialIconProperty = BindableProperty.Create(
		nameof(MaterialIcon),
		typeof(string),
		typeof(DropdownItemControl),
		string.Empty
	);
	public string MaterialIcon
	{
		get => (string)GetValue(MaterialIconProperty);
		set => SetValue(MaterialIconProperty, value);
	}

	private readonly Label _Label = new Label()
		.FontSize(16)
		.FontFamily(DynamicConstants.Instance.BoldFont)
		.Padding(0,8,8,8)
		.HorizontalTextAlignment(TextAlignment.Start);
	private readonly Label _Icon = new Label()
		.Padding(8,0,0,0)
		.FontSize(24)
		.FontFamily(nameof(MaterialIcon))
		.HorizontalTextAlignment(TextAlignment.Center)
		.VerticalTextAlignment(TextAlignment.Center);

	public DropdownItemControl()
	{
		this.ColumnDefinitions(e => e.Auto().Star());
		this.ColumnSpacing(8);
		this.Children([
			_Icon.Column(0),
			_Label.Column(1)
		]);
		this.GestureRecognizers(new TapGestureRecognizer()
			.NumberOfTapsRequired(1)
			.OnTapped((s,e) => {
				Tapped?.Invoke(this, EventArgs.Empty);
			}));
	}

    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == TranslateKeyProperty.PropertyName)
		{
			_Label.Text(e => e.Translate(TranslateKey));
		}
		else if (propertyName == MaterialIconProperty.PropertyName)
		{
			_Icon.Text(MaterialIcon);
		}
    }
}