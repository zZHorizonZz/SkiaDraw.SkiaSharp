using System;
using System.IO;
using SkiaSharp;

namespace Maui.Material.You.Source;

public class FontSource : ISource
{
    public FontSource()
    {
    }

    public FontSource(FontSource source)
    {
        Typeface = source.Typeface;
    }

    public SKTypeface Typeface { get; set; }

    public object Clone()
    {
        return new FontSource(this);
    }

    public void Load(Stream stream)
    {
        var typeface = SKTypeface.FromStream(stream);
        if (typeface == null) throw new Exception("Font resource can not be loaded.");

        Typeface = typeface;
    }
}