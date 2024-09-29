# MAUI.Bootstrap

A class library project showcasing .NET MAUI version of the Bootstrap web component library. 


One of the most useful libraries I have seen for C# only MAUI developers.

[FmgLib.MauiMarkup GitHub](https://github.com/FmgLib/FmgLib.MauiMarkup)

[FmgLib.MauiMarkup Docs](https://fmgyazilim.com/en/fmglibmauimarkup#fmglibmauimarkup-section)

### Accordion Control API
Inherits from MAUI Border component. Has access to Stroke/StrokeShape/etc.
```
// regular usage
var accordion = new AccordionControl
{
    Header = new Grid(),            // can be anything that inherits from View
    AccordionContent = new Grid(),  // can be anything that inherits from View
    IsCollapsed = false,            // when true component starts is small mode
    IconSize = 32,                  // dictates the Chevron Down/Up icon size
};

// FmgLib.MauiMarkup powered usage
var accordion = new AccordionControl()
    .Header(new Grid())
    .AccordionContent(new Grid())
    .IsCollapsed(false)
    .IconSize(32);
```

### Alert Control API
Inherits from MAUI Border component. Has access to Stroke/StrokeShape/etc.
```
// regular usage
var alert = new AlertControl
{   
    Timeout = TimeSpan.FromSeconds(10), // when set, triggers CloseClicked
    Dismissable = false,                        // when true, shows close icon
    AlertContent = new Grid(),                  // can be anything that inherits from View
    DismissIcon = new FontImageSource(),        // you decide what dismiss icon looks like
};
alert.CloseClicked += (s,e) => { /* remove from parent logic */ };

// FmgLib.MauiMarkup/Fluent methods powered usage
var alert = new AlertControl()
    .Timeout(TimeSpan.FromSeconds(10))
    .NotDismissable()
    .AlertContent(new Grid())
    .DimissIcon(new FontImageSource());
alert.CloseClicked += (s,e) => { /* remove from parent logic */ };

// you can further simplify usage with the following fluent methods
var primaryAlert = new AlertControl()
    .NotDismissable()
    .Timeout(TimeSpan.FromSeconds(10))
    .AlertContent(new Grid())
    .Primary();

// say you want default behavior non-auto dismiss, show close icon
var primaryAlert = new AlertControl()
    .AlertContent(new Grid())
    .Primary();

// other available style fluent methods
.Secondary()
.Success()
.Danger()
.Warning()
.Info()
.Light()
.Dark()
```

### Badge Control API
Inherits from MAUI Border component. Has access to Stroke/StrokeShape/etc.
```
// regular usage
var badge = new BadgeControl
{
    Text = "some text",
    TextSize = 32,
    TextColor = Colors.White,
    BackgroundColor = Colors.Black
};

// FmgLib.MauiMarkup/Fluent methods
var badge = new BadgeControl()
    .Text("some text")
    .TextColor(Colors.White)
    .BackgroundColor(Colors.Black);

// or with style fluent methods
var primaryBadge = new BadgeControl()
    .Text("some text")
    .Primary();

// other available style fluent methods
.Secondary()
.Success()
.Danger()
.Warning()
.Info()
.Light()
.Dark()

.Rounded() // will try to make the badge pill shaped
```