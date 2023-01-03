using Maui.Material.You.Components.Shape;
using IBorder = Maui.Material.You.Components.Models.IBorder;

namespace Maui.Material.You.Components.Elements;

public class BorderElement
{
    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
        nameof(IBorder.BackgroundColor),
        typeof(Color),
        typeof(BorderElement),
        Colors.White,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(
        nameof(IBorder.BorderColor),
        typeof(Color),
        typeof(BorderElement),
        Colors.DimGray,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(
        nameof(IBorder.BorderWidth),
        typeof(float),
        typeof(BorderElement),
        defaultValueCreator: GetDefaultBorderWidth,
        propertyChanged: OnBorderChanged);

    public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(
        nameof(IBorder.CornerRadius),
        typeof(CornerRadius),
        typeof(BorderElement),
        new CornerRadius(4.0),
        propertyChanged: OnBorderChanged);

    public static readonly BindableProperty ShapeTypeProperty = BindableProperty.Create(
        nameof(IBorder.ShapeType),
        typeof(ShapeType),
        typeof(BorderElement),
        ShapeType.Rectangle,
        propertyChanged: OnBorderChanged);

    public static readonly BindableProperty IsFilledProperty = BindableProperty.Create(
        nameof(IBorder.IsFilled),
        typeof(bool),
        typeof(BorderElement),
        true,
        propertyChanged: OnBorderChanged);

    public static void OnBorderChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IBorder)bindable).OnBorderChanged();
    }

    private static object GetDefaultBorderWidth(BindableObject bindable)
    {
        return ((IBorder)bindable).GetDefaultBorderWidth();
    }
}