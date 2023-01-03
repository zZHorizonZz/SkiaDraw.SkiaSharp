using System.Reflection;
using Maui.Material.You.Source;
using Microsoft.Extensions.Logging;
using SkiaDraw.SkiaSharp.Hosting;

namespace Example;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseSkiaDraw(typeof(App).GetTypeInfo().Assembly)
            .AddSourceFolder("Resources.Images")
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}