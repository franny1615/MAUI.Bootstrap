using System.Timers;
using CommunityToolkit.Mvvm.ComponentModel;
using FmgLib.MauiMarkup;
using MAUIBootstrap;
using MAUIBootstrap.Extensions;

namespace SampleApp.Pages;

public partial class CarouselItemModel : ObservableObject
{
	[ObservableProperty]
	private string title = string.Empty;

	[ObservableProperty]
	private string caption = string.Empty;

	[ObservableProperty]
	private Color background = Colors.White;
}

public class CarouselStylesDemoPage : ContentPage
{
	private readonly ScrollView _Scroll = new ScrollView();
	private readonly VerticalStackLayout _ContentLayout = new VerticalStackLayout().Spacing(0);

	public int CarouselPosition1 { get; set; } = 0;
	public int CarouselPosition2 { get; set; } = 0;
	public List<CarouselItemModel> CarouselItems = new List<CarouselItemModel>
	{
		new CarouselItemModel
		{
			Title = "Item 1",
			Caption = "This is example item 1.",
			Background = BootstrapColors.Warning
		},
		new CarouselItemModel
		{
			Title = "Item 2",
			Caption = "This is example item 2.",
			Background = BootstrapColors.WarningShade 
		},
		new CarouselItemModel
		{
			Title = "Item 3",
			Caption = "This is example item 3.",
			Background = BootstrapColors.Info
		},
	};

	private System.Timers.Timer _AutoplayTimer = new() 
	{
		Interval = 2000, // ms
	};

	public CarouselStylesDemoPage()
	{
		#region Example 1
		var prevButton1 = new Button()
			.CarouselPrevious()
			.OnClicked((s,e) => {
				if (CarouselPosition1 - 1 < 0)
					CarouselPosition1 = CarouselItems.Count - 1;
				else 
					CarouselPosition1--;
				OnPropertyChanged(nameof(CarouselPosition1));
			});
		var nextButton1 = new Button()
			.CarouselNext()
			.OnClicked((s,e) => {
				if (CarouselPosition1 + 1 >= CarouselItems.Count)
					CarouselPosition1 = 0;
				else
					CarouselPosition1++;
				OnPropertyChanged(nameof(CarouselPosition1));
			});
		var carousel1 = new CarouselView()
			.Carousel()
			.Position(e => e.Path(nameof(CarouselPosition1)).Source(this))
			.ItemsSource(CarouselItems)
			.ItemTemplate(new DataTemplate(() => {
				var view = new BoxView()
					.HorizontalOptions(LayoutOptions.Fill)
					.VerticalOptions(LayoutOptions.Fill);
				view.SetBinding(BindingContextProperty, ".");
				view.SetBinding(BoxView.ColorProperty, nameof(CarouselItemModel.Background));
				return view;
			}));
		#endregion

		#region Example 2
		var prevButton2 = new Button()
			.CarouselPrevious()
			.OnClicked((s,e) => {
				_AutoplayTimer.Stop();
				if (CarouselPosition2 - 1 < 0)
					CarouselPosition2 = CarouselItems.Count - 1;
				else 
					CarouselPosition2--;
				OnPropertyChanged(nameof(CarouselPosition2));
			});
		var nextButton2 = new Button()
			.CarouselNext()
			.OnClicked((s,e) => {
				_AutoplayTimer.Stop();
				if (CarouselPosition2 + 1 >= CarouselItems.Count)
					CarouselPosition2 = 0;
				else
					CarouselPosition2++;
				OnPropertyChanged(nameof(CarouselPosition2));
			});
		var carousel2 = new CarouselView()
			.Carousel(swipe: true)
			.Position(e => e.Path(nameof(CarouselPosition2)).Source(this))
			.ItemsSource(CarouselItems)
			.ItemTemplate(new DataTemplate(() => {
				var view = new BoxView()
					.HorizontalOptions(LayoutOptions.Fill)
					.VerticalOptions(LayoutOptions.Fill);
				view.SetBinding(BindingContextProperty, ".");
				view.SetBinding(BoxView.ColorProperty, nameof(CarouselItemModel.Background));

				var title = new Label().CarouselCaptionTitle();
				title.SetBinding(Label.TextProperty, nameof(CarouselItemModel.Title));
				var caption = new Label().CarouselCaptionText();
				caption.SetBinding(Label.TextProperty, nameof(CarouselItemModel.Caption));

				return new Grid()
					.RowSpacing(0)
					.RowDefinitions(e => e.Star().Auto().Auto())
					.Children([
						view.RowSpan(3).Row(0),
						title.Row(1),
						caption.Row(2).Padding(0,0,0,8),
					]);
			}));
		#endregion

		_ContentLayout.Children([
			new Label()
				.Text("No Swipe | Button Navigation")
				.Padding(8)
				.FontFamily(DynamicConstants.Instance.BoldFont),
			new Grid()
				.Children([
					carousel1,
					prevButton1,
					nextButton1
				]),
			new Label()
				.Text("Autoplay | Swipe | Button Navigation | Caption")
				.Padding(8)
				.FontFamily(DynamicConstants.Instance.BoldFont),
			new Grid()
				.Children([
					carousel2,
					prevButton2,
					nextButton2,
				]),
			new Button().MaterialIcon(MaterialIcon.Close, 40)
		]);

		this
			.Title("Carousel Styles")
			.Content(_Scroll.Content(_ContentLayout));
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
		_AutoplayTimer.Start();
		_AutoplayTimer.Elapsed += AutoplayElapsed;

		/*
			NOTE: to do custom intervals for each carousel item
			you may do something like this

			// on appearing set to true
			// on dissapearing set to false
			private bool _AutoplayEnabled = true;

			// on appearing call a method that starts this task
			Task.Run(async () => {
				while(_AutoplayEnabled) { // true should be swapped out by something
					// set carousel position
					await Task.Delay(1000); // based on current index, changed interval
				}
			});
		*/
    }

    protected override void OnDisappearing()
    {
		_AutoplayTimer.Stop();
		_AutoplayTimer.Elapsed -= AutoplayElapsed;
        base.OnDisappearing();
    }

	private void AutoplayElapsed(object? sender, ElapsedEventArgs e)
	{
		if (CarouselPosition2 + 1 >= CarouselItems.Count)
			CarouselPosition2 = 0;
		else
			CarouselPosition2++;
		OnPropertyChanged(nameof(CarouselPosition2));
	}
}