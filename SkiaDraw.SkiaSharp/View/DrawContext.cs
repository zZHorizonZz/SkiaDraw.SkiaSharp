using SkiaSharp;

namespace Maui.Material.You.Components.View;

public class DrawContext
{
    public DrawContext(SKCanvas canvas, SKImageInfo info, float scale)
    {
        Canvas = canvas;
        Info = info;
        Scale = scale;
    }

    public SKCanvas Canvas { get; init; }

    public SKImageInfo Info { get; init; }

    public float Scale { get; init; }
}