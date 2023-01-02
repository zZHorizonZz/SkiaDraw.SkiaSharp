using System;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.View;
using Maui.Material.You.Source;
using Maui.Material.You.Source.Image;
using Maui.Material.You.Utils;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using Svg.Skia;
using IImage = Maui.Material.You.Components.Models.IImage;

namespace Maui.Material.You.Components.Image;

public class VectorDrawable : MaterialDrawable, IImage
{
    public static readonly BindableProperty ColorProperty = ImageElement.ColorProperty;
    public static readonly BindableProperty SourceProperty = ImageElement.SourceProperty;

    private SKSvg mSvg;

    public VectorDrawable()
    {
    }

    public string? Source
    {
        get => (string?)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public void OnSourceChanged()
    {
        if (Source == null) return;

        LoadSource(Source);
    }

    public override void Draw(DrawContext context)
    {
        var canvas = context.Canvas;

        if (string.IsNullOrEmpty(Source) || Source == null)
            return;

        canvas.Save();
        canvas.Translate(GetX() * context.Scale, GetY() * context.Scale);

        var picture = mSvg.Picture;
        var matrix = SKMatrix.CreateScale(context.Scale, context.Scale);
        var paint = new SKPaint
        {
            Color = Color.WithAlpha(Opacity).ToSKColor(),
            ImageFilter = SKImageFilter.CreateColorFilter(Color
                .WithAlpha(Opacity)
                .CreateIconColorFilter())
        };

        canvas.DrawPicture(picture, ref matrix, paint);
        canvas.Restore();
    }

    private void LoadSource(string path)
    {
        var source = SourceManager.Instance?.GetSource(path);
        if (source == null) throw new Exception($"Source ({path}) of the {nameof(VectorDrawable)} can not be found.");

        if (source is not SvgSource svgSource) return;
        if (svgSource.Svg == null || svgSource.Svg.Model == null)
            throw new Exception("Something went wrong with svg source.");

        mSvg = svgSource.Svg;
        var bounds = mSvg.Model.CullRect;
        if (bounds.IsEmpty) return;

        Width = bounds.Width;
        Height = bounds.Height;
    }
}