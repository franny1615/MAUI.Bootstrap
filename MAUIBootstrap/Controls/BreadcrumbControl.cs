using System.Runtime.CompilerServices;
using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.MauiMarkup;
using MAUIBootstrap.Extensions;

namespace MAUIBootstrap.Controls;

public partial class Breadcrumb : ObservableObject
{
	[ObservableProperty]
	public string name = string.Empty;

	[ObservableProperty]
	public Color textColor = Color.FromArgb("#0d6efd");

	[ObservableProperty]
	public bool isSelected = false;
}

public class BreadcrumbEventArgs : EventArgs
{
	public string SelectedRoute { get; set; } = string.Empty;
}

public class BreadcrumbControl : ContentView
{
	public event EventHandler<BreadcrumbEventArgs>? RouteClicked;

	#region BindableProperties
	public static readonly BindableProperty RoutesProperty = BindableProperty.Create(
		nameof(Routes),
		typeof(List<Breadcrumb>),
		typeof(BreadcrumbControl),
		new List<Breadcrumb>()
	);

	public List<Breadcrumb> Routes
	{
		get => (List<Breadcrumb>)GetValue(RoutesProperty);
		set => SetValue(RoutesProperty, value);
	}
	#endregion	

	#region UI
	private readonly HorizontalStackLayout _ContentLayout = new HorizontalStackLayout()
		.Padding(0)
		.Spacing(4);
	private readonly ScrollView _Scroll = new ScrollView()
		.Orientation(ScrollOrientation.Horizontal)
		.HorizontalScrollBarVisibility(ScrollBarVisibility.Never);
	#endregion

	#region Constructor
	public BreadcrumbControl()
	{
		this.Content(
			_Scroll.Content(_ContentLayout)
		);
	}
    #endregion

    #region Methods
    protected override void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        base.OnPropertyChanged(propertyName);
		if (propertyName == RoutesProperty.PropertyName)
		{
			_ContentLayout.Clear();
			for (int i = 0; i < Routes.Count; i++)
			{
				var label = new Label()
					.BindingContext(Routes[i])
					.Text(e => e.Translate(Routes[i].Name))
					.TextColor(e => e.Path(nameof(Breadcrumb.TextColor)).Source(Routes[i]))
					.FontSize(13)
					.FontAttributes(FontAttributes.Bold)
					.GestureRecognizers(new TapGestureRecognizer()
						.NumberOfTapsRequired(1)
						.OnTapped((s,e) => 
						{
							if (s is Label lbl && lbl.BindingContext is Breadcrumb breadcrumb)
							{
								foreach(var crumb in Routes)
								{
									crumb.NotSelected();
								}
								breadcrumb.Selected();
								RouteClicked?.Invoke(this, new BreadcrumbEventArgs() { SelectedRoute = breadcrumb.Name });
							}
						}));
				_ContentLayout.Add(label);

				if (i <	(Routes.Count - 1))
				{
					_ContentLayout.Add(new Label()
						.Text("/")
						.FontSize(13)
						.FontAttributes(FontAttributes.Bold)
						.TextColor(Colors.DarkGray));	
				}

				if (i == (Routes.Count - 1) && Routes.Count > 1)
				{
					Task.Run(async () => 
					{
						await Task.Delay(250); // give time to render
						MainThread.BeginInvokeOnMainThread(() => 
						{
							try 
							{
								var selected = Routes.First((i) => i.IsSelected);
								var view = _ContentLayout
									.Children
									.First((i) => 
									{
										if (i is View v && 
											v.BindingContext is Breadcrumb bc &&
											bc.Name == selected.Name)
										{
											return true;
										}
										return false;
									});
								_Scroll.ScrollToAsync(
									view as View, 
									ScrollToPosition.MakeVisible, 
									true);
							}
							catch { }
						});
					});
				}
			}
		}
    }
    #endregion
}