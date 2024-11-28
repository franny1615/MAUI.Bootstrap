# MAUI.Bootstrap

A class library project showcasing .NET MAUI version of the Bootstrap web component library. 


One of the most useful libraries I have seen for C# only MAUI developers.

[FmgLib.MauiMarkup GitHub](https://github.com/FmgLib/FmgLib.MauiMarkup)

[FmgLib.MauiMarkup Docs](https://fmgyazilim.com/en/docs/fmglibmauimarkup/)

### Using MAUI.Bootstrap
In your MauiProgram.cs file CreateMauiApp() method
```C#
builder.UseMauiBootstrap("REGULAR_FONT_FAMILY_NAME", "BOLD_FONT_FAMILY_NAME");
```
In your App.cs file constructor
```C#
using MAUIBootstrap.Resources.Styles;
..
Resources.Add(new BootstrapColors());
Resources.Add(new BootstrapStyles());
```
The above will set up everything needed to use the class library.

### Dark/Light Mode Theming
The MAUI.Bootstrap library has basic dark/mode light mode theming available for you to use. 
```C#
// toggle theme
var themeButton = new Button()
    .Text("Toggle Theme")
    .Danger()
    .OnClicked((s, e) => {
        switch (BootstrapColors.CurrentTheme)
        {
            case AppTheme.Dark:
                BootstrapColors.CurrentTheme = AppTheme.Light;
                break;
            case AppTheme.Light:
                BootstrapColors.CurrentTheme = AppTheme.Dark;
                break;
        }
    });
```
Anything inside BootstrapColors.xaml binding to DynamicResource will be adjusted on the fly.
You can add more resource dictionaries to your app and bind them to any of the bootstrap colors.

You may also change available bootstrap colors on the fly as well.
```C#
// change page color to Pink
var pinkPage = new Button()
    .Text("Set Page Color To Pink")
    .Info()
    .OnClicked((s,e) => {
        BootstrapColors.PageColor = Colors.Pink;
    });
```
All available colors that can be changed on the fly are accessible via C# BootstrapColors class.

### Accordion Control API
Inherits from MAUI Border component. Has access to Stroke/StrokeShape/etc.
```C#
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
```C#
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
```C#
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
```C#
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
```C#
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

// Applying Material Icon to Button
// Color is optional
// when not provided, it will be auto themed to black and white based on theme
var materialIconButton = new Button()
    .MaterialIcon(MaterialIcon.Close, 40, Colors.Purple);

// when using Button as a carousel next button
var next = new Button()
    .CarouselNext();

// when using Button as a carousel previous button
var previous = new Button()
    .CarouselPrevious();
```

### Carousel API
```C#
// when you want default bootstrap styling of CarouselView control
// optional can provide swipe boolean.
var carousel = new CarouselView()
    .Carousel();
```

### Label API
```C#
// when using as carousel title, can use
var label = new Label().Text("My Title")
    .CarouselCaptionTitle();

// when using as carousel caption, can use
var label = new Label().Text("My Title")
    .CarouselCaptionText();
```

### Collapse API
```C#
// Against any of the following layouts 
StackLayout
Grid
FlexLayout
VerticalStackLayout
HorizontalStackLayout
Grid
FlexLayout
AbsoluteLayout
// you can use
.Collapse(openHeight); // will animate in/out the openHeight
// you can use
.CollapseWidth(openWidth); // will animate in/out the openWidth

// Against anything that inherits from View class
Collapse.CollapseAnimate(
    myView,
    openHeight
); // to animate vertical collapse
// similarly
Collapse.CollapseWidthAnimate(
    myView,
    openWidth
); // to animate width collapse
```

### EntryControl
Simple wrapper around entry, contains IsBorderless property. 
```C#
var entry = new EntryControl()
    .IsBorderless(true);
```  

### EditorControl
Simple wrapper around editor, contains IsBorderless property.
```C#
var editor = new EditorControl()
    .IsBorderless(true);
```

### Dropdown
A wrapper around Border that contains logic to create a vertical list of items.
Can be used for simple item selection.
```C#
var dropdown = new Dropdown()
    .Items([
        new DropdownItem
        {
            MaterialIcon = MaterialIcon.Close,
            TranslateKey = "MyTranslatableKey"
        }
    ])
    .OnItemSelected((s,e) => {
        if (e.SelectedItem != null) {
            // do work with e.SelectedItem
        }
    });
``` 

### List Group
```C#
// Combine 
.ListGroup() 
// fluent method on Border
// with 
.Divider() 
// on BoxView
// in order to get list group shell

// then use the 
UI.Active(anyView) 
// on anything whose parent is View class
// in order to get active/non active bootstrap style states. 

// an finally use 
.IsEnabled(bool)
// on parent control for the row in order to get disabled state.  

// when doing horizontal list group may use 
.VerticalDivider(); // to complete list group style
```

### Variants
```C#
// may be called when component is rendered to have it enabled by default
// or as part of an on tapped event to toggle the style on/off on anything
// that inherits from View. 
UI.PrimarySubtle(anyView);
UI.SecondarySubtle(anyView);
UI.SuccessSubtle(anyView);
UI.WarningSubtle(anyView);
UI.DangerSubtle(anyView);
UI.InfoSubtle(anyView);
UI.LightSubtle(anyView);
UI.DarkSubtle(anyView);
```

### Boostrap Radio Button
```C#
new RadioButton()
    .Bootstrap(); // will apply the bootstrap-esque radio template to your RadioButton.
```

### Modal Page
```C#
Navigation.PushModalAsync(
    new ModalPage()
        .Assign(out var modalPage)
        .IsCloseVisible(true) // set false for no close button
        .IsFullScreen(false) // set true for modal to take up whole screen
        .ModalHeader(new Label().Text("Title")) // can be any view
        .Body(new Label().Text("Body")) // can be any view
        .OnClosed((s,e) => {
            // modal was closed
        });
);

modalPage.ManualClose(); // will close page programmatically if triggered by some other event
```

### Tab Control
Consistent tab bar across iOS and Android as a view
```C# 
var tabBar = new TabControl()
    // .Vertical() // <-- vertical tab support
    .Tabs([
        new TabModel()
            .TranslateKey("Tab One")
            .MaterialIcon(MaterialIcon.Live_tv)
            .Active(),
        new TabModel()
            .TranslateKey("Tab Two")
            .MaterialIcon(MaterialIcon.Live_tv)
            .Active(),
        new TabModel()
            .TranslateKey("Tab Three")
            .MaterialIcon(MaterialIcon.Live_tv)
            .Active(),
    ])
    .OnTabSelected((s,e) => {
        if (e.SelectedTab == null)
            return;
        
        // use e.SelectedTab.TranslateKey
        // to determine what you want to do next
        // this can be swapping the Content of a ContentView
        // to another view for example
    });
// .Active() will not trigger first event
// you must set the first active tab yourself.
```

### Pagination Control
```C#
new PaginationControl()
    .CurrentPage(1)
    .TotalPages(10)
    .OnPageChanged((s,e) => {
        // e.RequestedPage has your number
    });
```

### Shimmers
```C# 
// available placeholder colors from bootstrap
var view = new Label(); // can be anything that inherits from View
view.PrimaryPlaceholder();
view.SecondaryPlaceholder();
view.SuccessPlaceholder();
view.WarningPlaceholder();
view.DangerPlaceholder();
view.InfoPlaceholder();
view.LightPlaceholder();
view.DarkPlaceholder();

// makes the background transperant again
view.ClearPlacholder();

// then to achieve a 'shimmer' animation
// on the parent layout of the view, or the view itself
Task.Run(async () => 
{
   while(true) // swap with a variable controlled outside of task
   {
        await view.FadeTo(0.85f);
        await view.FadeTo(1);
   }
});

// see ShimmerCard/ShimmersDemoPage in SampleApp project
// for a full example.
```

### Popovers
```C#
#if ANDROID 
using MAUIBootstrap.Platforms.Android;
#elif IOS
using MAUIBootstrap.Platforms.iOS;
#endif

// somewhere inside an EventHandler
Popover.Instance.Show(
    PopoverPlacement.Top, // .Bottom, .Left, .Right also available
    parentView,
    new Label() 
        .Padding(8)
        .BackgroundColor(BootstrapColors.Secondary)
        .TextColor(Colors.White)
        .HorizontalTextAlignment(TextAlignment.Center)
        .Text("Top Popover"),
    0); // final parameter is an auto-dismiss number in seconds. Defaults to zero and doesn't auto dismiss
```

### Spinner
```C#
var primarySpinner = new SpinnerControl()
    .StrokeThickness(4) // controls thickness or arc
    .Diameter(32) // controls width/height of view
    .Color(BootstrapColors.Primary) // color of arc
    .Start(); // starts the animation

primarySpinner.Stop(); // ends the animation, probably want to call in unison with .IsVisible(false);
```

### Rounded Rect Spinner
Progressively colors in the border of a rounded rectangle on the first loop.

Every subsequent loop will show the filled in color spinning.

Works with best with at least two Colors.
```C#
var roundedRectSpinner = new RoundRectSpinnerControl()
    .MinimumHeightRequest(40) 
    .FillHorizontal()
    .ZIndex(0)
    .StaticBorderColor(BootstrapColors.Secondary) // the default border color
    .CornerRadius(16)
    .StrokeThickness(DeviceInfo.Current.Platform == DevicePlatform.iOS ? 8 : 4) // thickness of border
    .Inset(8) // default is 8, defines the padding of rectangle that is drawn
    .Blur(0) // default is 0, whe larger than zero will blur the filled path
    .CornerRadius(12) // border radius 
    .GradientColors([ // your gradient colors
        BootstrapColors.Primary,
        BootstrapColors.Info
    ]);

roundedRectSpinner.IsLoading = true; // starts the animation
roundedRectSpinner.IsLoading = false; // stops the animation
```
