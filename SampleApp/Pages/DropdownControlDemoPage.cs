using CommunityToolkit.Maui;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Views;
using FmgLib.MauiMarkup;
using FmgLib.MauiMarkup.Core;
using MAUIBootstrap;
using MAUIBootstrap.Controls;
using MAUIBootstrap.Extensions;
using MAUIBootstrap.Popups;
using MAUIBootstrap.Utilities;
using Microsoft.Maui.Controls.Shapes;

namespace SampleApp.Pages;

public class DropdownControlDemoPage : ContentPage
{
	private readonly Debouncer _Debouncer = new();
	private readonly ButtonControl _DropdownButton = new ButtonControl().Primary();
	private readonly ButtonControl _DropdownButton2 = new ButtonControl().Primary();
	private readonly Dropdown _GridDropdown = new Dropdown();
	private readonly EntryControl _Entry = new EntryControl();
	private readonly Dropdown _EntryDropdown = new Dropdown();
	private readonly EditorControl _Editor = new EditorControl();
	private readonly Dropdown _EditorDropdown = new Dropdown();
	private readonly List<DropdownItem> _DropdownItems = [
		new DropdownItem
		{
			MaterialIcon = MaterialIcon.Ac_unit,
			TranslateKey = "AC Unit"
		},
		new DropdownItem
		{
			MaterialIcon = MaterialIcon.Location_pin,
			TranslateKey = "Location Pin"
		},
		new DropdownItem
		{
			TranslateKey = "Logout"
		}
	];
	public DropdownControlDemoPage()
	{
		#region Community Toolkit Popup Version
		_DropdownButton
			.Content(new Grid()
				.ColumnDefinitions(e => e.Star().Auto())
				.Children([
					new Label()
						.Text("Dropdown w/ Popup")
						.FontFamily(nameof(DynamicConstants.BoldFont))
						.FontSize(16)
						.Center()
						.TextColor(Colors.White)
						.Column(0),
					new Button()
						.Padding(0)
						.Margin(0)
						.MaterialIcon(MaterialIcon.Keyboard_arrow_down, 24, Colors.White)
						.Column(1)
						.OnClicked((s,e) => {
							var popup = new Popup();
							popup.CanBeDismissedByTappingOutsideOfPopup = true;
							// popup.Anchor = _DropdownButton;
							popup.Color = Colors.Transparent;
							popup.VerticalOptions = Microsoft.Maui.Primitives.LayoutAlignment.End;
							popup.Content = new Dropdown() 
								.DropdownItems(_DropdownItems)
								.OnItemSelected((s,e) => {
									if (e.SelectedItem != null)
									{
										Toast.Make(e.SelectedItem.TranslateKey).Show();
									}
								});
							this.ShowPopup(popup);
						}),
				]))
			.AlignLeft()
			.OnTapped((s,e) => {
				Toast.Make("Button Tap").Show();
			});
		#endregion

		#region Grid Z-Index Based Dropdown Version
		_GridDropdown
			.AlignTop()
			.AlignLeft()
			.IsVisible(false)
			.ZIndex(1)
			.DropdownItems(_DropdownItems)
			.OnItemSelected((s,e) => {
				if (e.SelectedItem != null)
				{
					Toast.Make(e.SelectedItem.TranslateKey).Show();
					_GridDropdown.IsVisible(false);
				}
			});
		_DropdownButton2
				.Content(new Grid()
				.ColumnDefinitions(e => e.Star().Auto())
				.Children([
					new Label()
						.Text("Dropdown w/ Grid")
						.FontFamily(nameof(DynamicConstants.BoldFont))
						.FontSize(16)
						.Center()
						.TextColor(Colors.White)
						.Column(0),
					new Button()
						.Padding(0)
						.Margin(0)
						.MaterialIcon(MaterialIcon.Keyboard_arrow_down, 24, Colors.White)
						.Column(1)
						.OnClicked((s,e) => {
							_GridDropdown.IsVisible(!_GridDropdown.IsVisible);
						}),
				]))
			.AlignLeft()
			.OnTapped((s,e) => {
				Toast.Make("Button Tap").Show();
			});
		#endregion

		#region Entry Dropdown
		_Entry
			.VerticalOptions(LayoutOptions.Center)
			.IsBorderless(true)
			.Placeholder("I'm a borderless entry")
			.OnTextChanged((s,e) => {
				if (string.IsNullOrEmpty(e.NewTextValue)) return;
				_Debouncer.Debounce(() => 
				{
					_EntryDropdown.IsVisible(true);
				});
			});
		_EntryDropdown
			.AlignTop()
			.ZIndex(1)
			.IsVisible(false)
			.DropdownItems(_DropdownItems)
			.OnItemSelected((s,e) => {
				if (e.SelectedItem != null)
				{
					Toast.Make(e.SelectedItem.TranslateKey).Show();
					_EntryDropdown.IsVisible(false);
					_Entry.Text = string.Empty;
				}
			});
		#endregion

		#region Editor Dropdown
		_Editor
			.IsBorderless(true)
			.VerticalOptions(LayoutOptions.Center)
			.AutoSize(EditorAutoSizeOption.TextChanges)
			.Placeholder("I'm a borderless editor")
			.OnTextChanged((s,e) => {
				// keep in mind that on new line, string is not empty...
				if (string.IsNullOrEmpty(e.NewTextValue)) return;
				_Debouncer.Debounce(() => 
				{
					_EditorDropdown.IsVisible(true);
				});
			});
		_EditorDropdown
			.AlignTop()
			.ZIndex(1)
			.IsVisible(false)
			.DropdownItems(_DropdownItems)
			.OnItemSelected((s,e) => {
				if (e.SelectedItem != null)
				{
					Toast.Make(e.SelectedItem.TranslateKey).Show();
					_EditorDropdown.IsVisible(false);
					_Editor.Text = string.Empty;
				}
			});
		#endregion

		this
		.Title("Dropdown Control")
		.Content(new ScrollView()
			.Content(new Grid()
				.RowSpacing(8)
				.RowDefinitions(e => e.Auto().Auto().Auto().Auto().Star())
				.Padding(16)
				.Children([
					_DropdownButton.Row(0),
					_DropdownButton2.Row(1),
					_GridDropdown.Row(2).RowSpan(3),
					new Border()
						.Row(2)
						.Card()
						.Padding(8,0,8,0)
						.Content(_Entry),
					_EntryDropdown.Row(3).RowSpan(2),
					new Border()
						.Row(3)
						.Card()
						.Padding(8,0,8,0)
						.Content(_Editor),
					_EditorDropdown.Row(4).RowSpan(1)
				])
				.GestureRecognizers([
					new TapGestureRecognizer()
						.NumberOfTapsRequired(1)
						.OnTapped((s, e) => {
							_GridDropdown.IsVisible(false);
							_EntryDropdown.IsVisible(false);
						})
				])
			)
		);
	}
}