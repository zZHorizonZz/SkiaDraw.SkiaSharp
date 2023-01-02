using Microsoft.Maui.Graphics;
using SkiaSharp;

namespace Maui.Material.You.Utils;

public static class ColorUtils
{
    public static SKColorFilter CreateIconColorFilter(this Color color)
    {
        var tableRed = new byte[256];
        var tableGreen = new byte[256];
        var tableBlue = new byte[256];

        for (var i = 0; i < 256; i++) color.ToRgb(out tableRed[i], out tableGreen[i], out tableBlue[i]);

        return SKColorFilter.CreateTable(null, tableRed, tableGreen, tableBlue);
    }
}