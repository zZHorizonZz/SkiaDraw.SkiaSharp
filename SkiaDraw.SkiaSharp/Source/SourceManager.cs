using System.Reflection;
using Maui.Material.You.Source.Animation;
using Maui.Material.You.Source.Image;

namespace Maui.Material.You.Source;

public class SourceManager : ISourceManager
{
    public static SourceManager? Instance;
    public IDictionary<string, ISource> Source;

    public Assembly SourceAssembly;

    public SourceManager(Assembly sourceAssembly)
    {
        SourceAssembly = sourceAssembly;
        Source = new Dictionary<string, ISource>();
    }

    public void LoadFolder(string path)
    {
        var resources = SourceAssembly.GetManifestResourceNames();
        var assemblyName = SourceAssembly.GetName().Name;
        var qualifiedName = $"{assemblyName}.{path}";

        foreach (var resource in resources)
            if (resource.StartsWith(qualifiedName))
            {
                if (string.IsNullOrEmpty(resource)) continue;

                var extension = resource[resource.LastIndexOf('.')..];
                var name = resource[..resource.LastIndexOf('.')];
                name = name[(name.LastIndexOf('.') + 1)..];

                LoadSource(resource, $"{name}{extension}");
            }
    }

    public void LoadSource(string path, string alias)
    {
        var assemblyName = SourceAssembly.GetName().Name;
        var finalPath = path;
        if (!path.StartsWith(assemblyName))
            finalPath = $"{assemblyName}.{path}";

        using var stream = SourceAssembly.GetManifestResourceStream(finalPath);
        if (stream == null)
            return;

        var source = CreateSource(alias, stream);
        var finalName = alias;
        if (alias.Contains('.'))
            finalName = alias[..alias.LastIndexOf('.')];

        if (source != null)
            Source.Add(finalName.ToLower(), source);
    }

    public void UnloadSource(string name)
    {
        Source.Remove(name.ToLower());
    }

    public ISource? GetSource(string name)
    {
        if (Source.ContainsKey(name.ToLower())) return Source[name.ToLower()];

        return null;
    }

    private ISource? CreateSource(string path, Stream stream)
    {
        if (string.IsNullOrEmpty(path))
            return null;

        if (stream == null)
            return null;

        ISource? source = null;

        if (path.TrimEnd().EndsWith(".svg"))
            source = new SvgSource();

        if (path.TrimEnd().EndsWith(".ttf"))
            source = new FontSource();

        if (path.TrimEnd().EndsWith(".png"))
            source = new Image.ImageSource();

        if (path.TrimEnd().EndsWith(".json"))
            source = new LottieSource();

        source?.Load(stream);

        return source;
    }
}