using System.IO;
using Microsoft.Maui.Graphics;
using Svg.Skia;

namespace Maui.Material.You.Source.Image;

public class SvgSource : IImageSource
{
    public SvgSource()
    {
    }

    public SvgSource(SvgSource original)
    {
        Color = original.Color;
        Fill = original.Fill;
        Scale = original.Scale;
        Svg = original.Svg;
    }

    public Color Color { get; set; }

    public bool Fill { get; set; }

    public SKSvg Svg { get; private set; }

    public float Height => Svg != null && Svg.Model != null ? Svg.Model.CullRect.Height : 0;

    public float Scale { get; set; } = 1.0f;

    public float Width => Svg != null && Svg.Model != null ? Svg.Model.CullRect.Width : 0;

    public object Clone()
    {
        return new SvgSource(this);
    }

    public void Load(Stream stream)
    {
        Svg ??= new SKSvg();
        Svg.Load(stream);
    }
}