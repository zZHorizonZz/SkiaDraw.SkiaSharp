using System.IO;

namespace Maui.Material.You.Source.Animation;

public class LottieSource : ISource
{
    public LottieSource()
    {
    }

    public LottieSource(LottieSource original)
    {
        Scale = original.Scale;
        Animation = original.Animation;
    }

    public float Height => Animation != null ? Animation.Size.Height : 0;

    public float Scale { get; set; } = 1.0f;

    public SkiaSharp.Skottie.Animation Animation { get; private set; }

    public float Width => Animation != null ? Animation.Size.Width : 0;

    public object Clone()
    {
        return new LottieSource(this);
    }

    public void Load(Stream stream)
    {
        Animation ??= SkiaSharp.Skottie.Animation.Create(stream);
    }
}