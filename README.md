# MAUI.Bootstrap

A class library project showcasing .NET MAUI version of the Bootstrap web component library. 


One of the most useful libraries I have seen for C# only MAUI developers.

[FmgLib.MauiMarkup GitHub](https://github.com/FmgLib/FmgLib.MauiMarkup)

[FmgLib.MauiMarkup Docs](https://fmgyazilim.com/en/fmglibmauimarkup#fmglibmauimarkup-section)

### Using MAUI.Bootstrap
```
In your MauiProgram.cs file
...
builder.UseMauiBootstrap();
...
```

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

### Breadcrumb Control API
```
// regular usage
var breadcrumbControl = new BreadcrumbControl
{
    Routes = 
    {
        new Breadcrumb
        {
            Name = "Route 1",
            IsSelected = true
        }
    }
};

// fluent method powered usage
var breadcrumbControl = new BreadcrumbControl()
    .Routes([
        new Breadcrumb().Name("Route 1").Selected()
    ]);

// string inside .Name() fluent method is the key used for translation
// it is also the key that is delivered in the OnRouteClicked event

// full example
var breadCrumb = new BreadcrumbControl()
    .Routes([
        new Breadcrumb().Name("Main Page"),
        new Breadcrumb().Name("Current Page").Selected()
    ])
    .OnRouteClicked((s, e) => {
        if (e.SelectedRoute == "Main Page") {
            // Main Page routing logic here
        }
    });
```

### Button | RadioButton | CheckboxControl Styles
```
// fluent methods available for existing Button control
.Primary()
.Secondary()
.Success()
.Warning()
.Danger()
.Info()
.Light()
.Dark()
.Link()
// make the button outlined
.Outlined()
// enable/disable state
.Disabled()
.Enabled()
// no corner radius
.SharpCorners()

// primary, outline, sharp
var button = new Button()
    .Primary()
    .Outlined() // must come second
    .SharpCorners();


// also work with custom ButtonControl
var buttonContorl = new ButtonControl()
    .Primary()
    .Outlined()
    .SharpCorners();

// RADIO BUTTON
// fluent method to style existing RadioButton
.Bootstrap(
    selectedColor,
    deselectedColor
);

// CHECK BOX
// fluent methods to style checkbox control
.Primary()
.Secondary()
.Success()
.Warning()
.Danger()
.Info()
.Light()
.Dark()

// example
new CheckboxControl()
    .Primary()
    .Content(new Label()
        .Text("Primary")
        .TextColor(Colors.White)
        .VerticalOptions(LayoutOptions.Center))
    .OnCheckedChanged((s, e) => { 
        if (s is CheckboxControl ctrl) 
        {
            // ctrl.IsChecked has your value;
        }
    });

```