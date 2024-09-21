namespace SampleApp.Pages;

public class ControlsPage : ContentPage
{
	public ControlsPage()
	{
		Content = new VerticalStackLayout
		{
			Children = 
			{
				new Label 
				{ 
					HorizontalOptions = LayoutOptions.Center, 
					VerticalOptions = LayoutOptions.Center, 
					Text = "Welcome to .NET MAUI!"
				}
			}
		};
	}
}