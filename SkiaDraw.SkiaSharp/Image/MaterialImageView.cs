using CommunityToolkit.Maui.Markup;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.Models;
using Maui.Material.You.Components.View;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using IImage = Maui.Material.You.Components.Models.IImage;

namespace Maui.Material.You.Components.Image;

public class MaterialImageView : MaterialView, IImage, IBitmapImage
{
    public static readonly BindableProperty ColorProperty = ImageElement.ColorProperty;
    public static readonly BindableProperty SourceProperty = ImageElement.SourceProperty;

    public static readonly BindableProperty CornerRadiusProperty = BitmapImageElement.CornerRadiusProperty;
    public new static readonly BindableProperty ScaleProperty = BitmapImageElement.ScaleProperty;
    public static readonly BindableProperty ImageStretchProperty = BitmapImageElement.ImageStretchProperty;

    public static readonly BindableProperty
        HorizontalAlignmentProperty = BitmapImageElement.HorizontalAlignmentProperty;

    public static readonly BindableProperty VerticalAlignmentProperty = BitmapImageElement.VerticalAlignmentProperty;

    internal ImageViewDrawable mImageView;

    public MaterialImageView()
    {
        mImageView = AddDrawable(new ImageViewDrawable());

        HeightRequest = 128;
        WidthRequest = 256;

        mImageView.Bind(ColorProperty, nameof(Color), source: this);
        mImageView.Bind(SourceProperty, nameof(Source), source: this);
        mImageView.Bind(CornerRadiusProperty, nameof(CornerRadius), source: this);
        mImageView.Bind(ScaleProperty, nameof(Scale), source: this);
        mImageView.Bind(ImageStretchProperty, nameof(ImageStretch), source: this);
        mImageView.Bind(HorizontalAlignmentProperty, nameof(HorizontalAlignment), source: this);
        mImageView.Bind(VerticalAlignmentProperty, nameof(VerticalAlignment), source: this);
    }

    public CornerRadius? CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public new float Scale
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
        InvalidateView();
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
        InvalidateView();
    }

    public override double GetIntrinsicHeight()
    {
        return HeightRequest;
    }

    public override double GetIntrinsicWidth()
    {
        return WidthRequest;
    }
}