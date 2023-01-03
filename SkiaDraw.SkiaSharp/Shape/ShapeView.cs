using CommunityToolkit.Maui.Markup;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.Shape;
using IBorder = Maui.Material.You.Components.Models.IBorder;
using ShapeDrawable = Maui.Material.You.Components.Shape.ShapeDrawable;

namespace Maui.Material.You.Components.View;

public class ShapeView : DrawView, IBorder
{
    public static readonly BindableProperty BorderColorProperty = BorderElement.BorderColorProperty;
    public static readonly BindableProperty BorderWidthProperty = BorderElement.BorderWidthProperty;
    public static readonly BindableProperty CornerRadiusProperty = BorderElement.CornerRadiusProperty;
    public static readonly BindableProperty ShapeTypeProperty = BorderElement.ShapeTypeProperty;
    public static readonly BindableProperty IsFilledProperty = BorderElement.IsFilledProperty;

    internal readonly ShapeDrawable mMaterialShapeDrawable;

    public ShapeView()
    {
        mMaterialShapeDrawable = AddDrawable(new ShapeDrawable { ZIndex = 0 });
        mMaterialShapeDrawable.Bind(Drawable.WidthProperty, nameof(Width),
            source: mCanvasView, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(Drawable.HeightProperty, nameof(Height),
            source: mCanvasView, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(ShapeDrawable.BackgroundColorProperty, nameof(BackgroundColor),
            source: this, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(ShapeDrawable.BorderWidthProperty,
            nameof(BorderWidth),
            source: this, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(ShapeDrawable.CornerRadiusProperty,
            nameof(CornerRadius),
            source: this, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(ShapeDrawable.ShapeTypeProperty,
            nameof(ShapeType),
            source: this, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(ShapeDrawable.IsFilledProperty,
            nameof(IsFilled),
            source: this, mode: BindingMode.OneWay);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public float BorderWidth
    {
        get => (float)GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public ShapeType ShapeType
    {
        get => (ShapeType)GetValue(ShapeTypeProperty);
        set => SetValue(ShapeTypeProperty, value);
    }

    public bool IsFilled
    {
        get => (bool)GetValue(IsFilledProperty);
        set => SetValue(IsFilledProperty, value);
    }

    public bool HasBorder => BorderWidth > 0 && !Equals(BorderColor, Colors.Transparent);
    public bool HasBackground => !Equals(BackgroundColor, Colors.Transparent);

    public void OnBorderColorChanged(object oldColor, object newColor)
    {
    }

    public void OnBorderChanged()
    {
    }

    public float GetDefaultBorderWidth()
    {
        return 1.25f;
    }
}