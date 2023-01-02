using Maui.Material.You.Components.Image;
using Maui.Material.You.Components.Models;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Material.You.Components.Elements;

public class BitmapImageElement
{
    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(IBitmapImage.CornerRadius),
        typeof(CornerRadius),
        typeof(BitmapImageElement),
        new CornerRadius(0),
        propertyChanged: OnImageChanged);

    public static readonly BindableProperty ScaleProperty = BindableProperty.Create(
        nameof(IBitmapImage.Scale),
        typeof(float),
        typeof(BitmapImageElement),
        1.0f,
        propertyChanged: OnImageChanged);

    public static readonly BindableProperty ImageStretchProperty = BindableProperty.Create(
        nameof(IBitmapImage.ImageStretch),
        typeof(ImageStretch),
        typeof(BitmapImageElement),
        ImageStretch.Uniform,
        propertyChanged: OnImageChanged);

    public static readonly BindableProperty HorizontalAlignmentProperty = BindableProperty.Create(
        nameof(IBitmapImage.HorizontalAlignment),
        typeof(ImageAlignment),
        typeof(BitmapImageElement),
        ImageAlignment.Center,
        propertyChanged: OnImageChanged);

    public static readonly BindableProperty VerticalAlignmentProperty = BindableProperty.Create(
        nameof(IBitmapImage.VerticalAlignment),
        typeof(ImageAlignment),
        typeof(BitmapImageElement),
        ImageAlignment.Center,
        propertyChanged: OnImageChanged);

    public static void OnImageChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IBitmapImage)bindable).OnImageChanged();
    }
}