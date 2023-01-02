using System.IO;
using SkiaSharp;

namespace Maui.Material.You.Source.Image;

public class ImageSource : IImageSource
{
    public ImageSource()
    {
    }

    public ImageSource(ImageSource original)
    {
        Fill = original.Fill;
        Scale = original.Scale;
        Image = original.Image;
    }

    public bool Fill { get; set; }

    public SKBitmap Image { get; private set; }

    public float Height => Image != null ? Image.Height : 0;

    public float Scale { get; set; } = 1.0f;

    public float Width => Image != null ? Image.Width : 0;

    public object Clone()
    {
        return new ImageSource(this);
    }

    public void Load(Stream stream)
    {
        Image ??= SKBitmap.Decode(stream);
    }
}