using SkiaSharp;

namespace Maui.Material.You.Components.Internal;

public class DrawMode
{
    public static readonly DrawMode Fill = new(SKPaintStyle.Fill);
    public static readonly DrawMode Stroke = new(SKPaintStyle.Stroke);
    public static readonly DrawMode StrokeAndFill = new(SKPaintStyle.StrokeAndFill);
    public static readonly DrawMode None = new();

    public DrawMode()
    {
    }

    public DrawMode(SKPaintStyle style)
    {
        Style = style;
    }

    public SKPaintStyle? Style { get; init; }
}