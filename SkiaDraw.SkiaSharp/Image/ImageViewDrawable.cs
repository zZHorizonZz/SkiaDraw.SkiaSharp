using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.Models;
using Maui.Material.You.Components.View;
using Maui.Material.You.Extension;
using Maui.Material.You.Source;
using Maui.Material.You.Utils;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using IImage = Maui.Material.You.Components.Models.IImage;
using IImageSource = Maui.Material.You.Source.Image.IImageSource;
using ImageSource = Maui.Material.You.Source.Image.ImageSource;

namespace Maui.Material.You.Components.Image;

public class ImageViewDrawable : MaterialDrawable, IImage, IBitmapImage
{
    public static readonly BindableProperty ColorProperty = ImageElement.ColorProperty;
    public static readonly BindableProperty SourceProperty = ImageElement.SourceProperty;

    public static readonly BindableProperty CornerRadiusProperty = BitmapImageElement.CornerRadiusProperty;
    public static readonly BindableProperty ScaleProperty = BitmapImageElement.ScaleProperty;
    public static readonly BindableProperty ImageStretchProperty = BitmapImageElement.ImageStretchProperty;

    public static readonly BindableProperty
        HorizontalAlignmentProperty = BitmapImageElement.HorizontalAlignmentProperty;

    public static readonly BindableProperty VerticalAlignmentProperty = BitmapImageElement.VerticalAlignmentProperty;

    internal IImageSource source;

    public CornerRadius? CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public float Scale
    {
        get => (float)GetValue(ScaleProperty);
        set => SetValue(ScaleProperty, value);
    }

    public ImageStretch ImageStretch
    {
        get => (ImageStretch)GetValue(ImageStretchProperty);
        set => SetValue(ImageStretchProperty, value);
    }

    public ImageAlignment HorizontalAlignment
    {
        get => (ImageAlignment)GetValue(HorizontalAlignmentProperty);
        set => SetValue(HorizontalAlignmentProperty, value);
    }

    public ImageAlignment VerticalAlignment
    {
        get => (ImageAlignment)GetValue(VerticalAlignmentProperty);
        set => SetValue(VerticalAlignmentProperty, value);
    }

    public void OnImageChanged()
    {
        OnVisualPropertyChanged();
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

    public Color GetDefaultColor()
    {
        return Colors.White;
    }

    public override void Draw(DrawContext context)
    {
        var canvas = context.Canvas;

        if (source == null || Source == null)
            return;

        canvas.Save();

        if (CornerRadius is { })
            canvas.ClipPath(GetBounds().ToRoundedRect(CornerRadius.Value, context.Scale));

        var paint = new SKPaint();

        if (Color != null)
        {
            paint.Color = Color.WithAlpha(Opacity).ToSKColor();
            paint.ImageFilter = SKImageFilter.CreateColorFilter(Color
                .WithAlpha(Opacity)
                .CreateIconColorFilter());
        }

        if (source is ImageSource image)
        {
            var dest = new SKRect(0, 0, context.Info.Width, context.Info.Height);

            canvas.DrawBitmap(
                image.Image,
                dest,
                ImageStretch,
                HorizontalAlignment,
                VerticalAlignment,
                Color != null ? paint : null);
        }

        canvas.Restore();
    }

    private void LoadSource(string path)
    {
        var source = SourceManager.Instance?.GetSource(path);
        switch (source)
        {
            case null:
                throw new Exception($"Source ({path}) of the {nameof(VectorDrawable)} can not be found.");
            case IImageSource image:
                this.source = image;
                Width = image.Width;
                Height = image.Height;
                break;
        }
    }
}