using System.Reflection;
using Maui.Material.You.Source;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace SkiaDraw.SkiaSharp.Hosting;

public static class InitializerExtension
{
    public static MauiAppBuilder UseSkiaDraw(this MauiAppBuilder builder, Assembly assembly)
    {
        builder.UseSkiaSharp();
        SourceManager.Instance = new SourceManager(assembly);
        return builder;
    }
}