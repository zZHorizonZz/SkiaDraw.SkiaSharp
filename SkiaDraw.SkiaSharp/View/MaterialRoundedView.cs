using CommunityToolkit.Maui.Markup;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.Shape;
using IBorder = Maui.Material.You.Components.Models.IBorder;

namespace Maui.Material.You.Components.View;

public class MaterialRoundedView : MaterialView, IBorder
{
    public static readonly BindableProperty BorderColorProperty = BorderElement.BorderColorProperty;
    public static readonly BindableProperty BorderWidthProperty = BorderElement.BorderWidthProperty;
    public static readonly BindableProperty CornerRadiusProperty = BorderElement.CornerRadiusProperty;

    internal readonly MaterialShapeDrawable mMaterialShapeDrawable;

    public MaterialRoundedView()
    {
        mMaterialShapeDrawable = AddDrawable(new MaterialShapeDrawable { ZIndex = 0 });
        mMaterialShapeDrawable.Bind(MaterialDrawable.WidthProperty, nameof(Width),
            source: mCanvasView, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(MaterialDrawable.HeightProperty, nameof(Height),
            source: mCanvasView, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(MaterialShapeDrawable.BackgroundColorProperty, nameof(BackgroundColor),
            source: this, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(MaterialShapeDrawable.BorderWidthProperty,
            nameof(BorderWidth),
            source: this, mode: BindingMode.OneWay);
        mMaterialShapeDrawable.Bind(MaterialShapeDrawable.CornerRadiusProperty,
            nameof(CornerRadius),
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