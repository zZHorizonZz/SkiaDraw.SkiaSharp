# SkiaDraw.SkiaSharp

This is a repository of a library which provides utilities, views and extensions
for [SkiaSharp](https://github.com/mono/SkiaSharp). Currently you can use ShapeView
trough which you can render shapes rectangles, circle, etc. Or you can create your
own Drawables.

## Installation

To install this library, run the following command in the Package Manager Console:

```
nuget install SkiaDraw.SkiaSharp
```

Then you need to edit your **MauiProgram.cs** file and add the following line:

```csharp
var builder = MauiApp.CreateBuilder();
builder
    .UseMauiApp<App>()
    .UseSkiaDraw(typeof(App).GetTypeInfo().Assembly) // This line will setup the SkiaDraw library
    .AddSourceFolder("Resources.Images") // Trough this line you can add your source folders from which ImageDrawables will load images
    .ConfigureFonts(fonts =>
    {
        fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
        fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
    });

#if DEBUG
        builder.Logging.AddDebug();
#endif

return builder.Build();
```

[![NuGet](https://img.shields.io/nuget/dt/SkiaDraw.SkiaSharp?color=0078d4&label=NuGet&logo=nuget&style=flat-square)]

## Examples

Example application can be found [here](https://github.com/zZHorizonZz/SkiaDraw.SkiaSharp/tree/master/Example)

### ShapeView

```csharp
new ShapeView
{
   ShapeType = ShapeType.Circle,
   BackgroundColor = Color.FromHex("#FF4081"),
   BorderColor = Color.FromHex("#FF5081"),
   BorderWidth = 5,
   HeightRequest = 100,
   WidthRequest = 100,
   IsFilled = false,
   CornerRadius = 10,
   Margin = new Thickness(10)
}
```

## Contributing

We welcome contributions to this library. If you have a bug fix or new feature that you would like to contribute, please
open a pull request.

## License

This library is licensed under the MIT License.
See [LICENSE](https://github.com/zZHorizonZz/SkiaDraw.SkiaSharp/blob/master/LICENSE) for more information.