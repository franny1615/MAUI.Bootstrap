using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Controls;

public class ButtonControl : Border 
{
	public event EventHandler? Tapped;

	public ButtonControl() 
	{
		this.GestureRecognizers([
			new TapGestureRecognizer()
				.NumberOfTapsRequired(1)
				.OnTapped(async (s,e) => {
					await this.ScaleTo(0.95, 70);
					await this.ScaleTo(1.0, 70);
					Tapped?.Invoke(this, EventArgs.Empty);
				})
		]);
	}
}