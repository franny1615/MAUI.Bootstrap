using System;
using FmgLib.MauiMarkup;

namespace MAUIBootstrap.Extensions;

public static class LabelExtensions
{
    public static Label CarouselCaptionTitle(this Label label)
    {
        label
            .FontSize(16)
            .FontFamily(DynamicConstants.Instance.BoldFont)
            .MaxLines(1)
            .HorizontalTextAlignment(TextAlignment.Center)
            .LineBreakMode(LineBreakMode.TailTruncation);
        return label;
    }

    public static Label CarouselCaptionText(this Label label)
    {
        label
            .FontSize(14)
            .MaxLines(1)
            .HorizontalTextAlignment(TextAlignment.Center)
            .LineBreakMode(LineBreakMode.TailTruncation);
        return label;
    }
}
