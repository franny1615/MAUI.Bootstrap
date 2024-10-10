using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Extensions;

public static class CarouselExtensions
{
    public static CarouselView Carousel(this CarouselView view, bool swipe = false)
    {
        view.HeightRequest(300)
			.IsSwipeEnabled(swipe)
			.HorizontalScrollBarVisibility(ScrollBarVisibility.Never);
        return view;
    }
}
