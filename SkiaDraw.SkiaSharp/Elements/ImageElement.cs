using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using IImage = Maui.Material.You.Components.Models.IImage;

namespace Maui.Material.You.Components.Elements;

public class ImageElement
{
    public static readonly BindableProperty ColorProperty = BindableProperty.Create(
        nameof(IImage.Color),
        typeof(Color),
        typeof(ImageElement),
        Colors.White,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty SourceProperty = BindableProperty.Create(
        nameof(IImage.Source),
        typeof(string),
        typeof(ImageElement),
        null,
        propertyChanged: OnSourceChanged);

    public static void OnSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IImage)bindable).OnSourceChanged();
    }
}