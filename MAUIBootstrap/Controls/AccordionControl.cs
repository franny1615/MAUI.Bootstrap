namespace MAUIBootstrap.Controls;

public class AccordionControl : ContentView
{
	public AccordionControl()
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