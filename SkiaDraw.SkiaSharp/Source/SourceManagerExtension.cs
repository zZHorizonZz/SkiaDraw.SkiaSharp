using System.Reflection;
using Microsoft.Maui.Hosting;

namespace Maui.Material.You.Source;

public static class SourceManagerExtension
{
    public static MauiAppBuilder ConfigureSourceService(this MauiAppBuilder builder, Assembly assembly)
    {
        SourceManager.Instance = new SourceManager(assembly);
        return builder;
    }

    public static MauiAppBuilder AddSourceFolder(this MauiAppBuilder builder, string folder)
    {
        SourceManager.Instance?.LoadFolder(folder);
        return builder;
    }

    public static MauiAppBuilder AddSource(this MauiAppBuilder builder, string source, string alias)
    {
        SourceManager.Instance?.LoadSource(source, alias);
        return builder;
    }
}