using Maui.Material.You.Components.Models;
using IDrawable = Maui.Material.You.Components.Models.IDrawable;

namespace Maui.Material.You.Components.Elements;

public class DrawableElement
{
    public static readonly BindableProperty XProperty = BindableProperty.Create(
        nameof(IDrawable.X),
        typeof(double),
        typeof(DrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.MeasureChanged));

    public static readonly BindableProperty YProperty = BindableProperty.Create(
        nameof(IDrawable.Y),
        typeof(double),
        typeof(DrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.MeasureChanged));

    public static readonly BindableProperty WidthProperty = BindableProperty.Create(
        nameof(IDrawable.Width),
        typeof(double),
        typeof(DrawableElement),
        -1.0,
        propertyChanged: (bindable, _, _) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.SizeChanged));

    public static readonly BindableProperty HeightProperty = BindableProperty.Create(
        nameof(IDrawable.Height),
        typeof(double),
        typeof(DrawableElement),
        -1.0,
        propertyChanged: (bindable, _, _) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.SizeChanged));

    public static readonly BindableProperty TranslationXProperty = BindableProperty.Create(
        nameof(IDrawable.TranslationX),
        typeof(double),
        typeof(DrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.TranslationChanged));

    public static readonly BindableProperty TranslationYProperty = BindableProperty.Create(
        nameof(IDrawable.TranslationY),
        typeof(double),
        typeof(DrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.TranslationChanged));

    public static readonly BindableProperty HorizontalOptionsProperty = BindableProperty.Create(
        nameof(IDrawable.HorizontalOptions),
        typeof(LayoutOptions),
        typeof(DrawableElement),
        LayoutOptions.Start,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.HorizontalOptionsChanged));

    public static readonly BindableProperty VerticalOptionsProperty = BindableProperty.Create(
        nameof(IDrawable.VerticalOptions),
        typeof(LayoutOptions),
        typeof(DrawableElement),
        LayoutOptions.Start,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.VerticalOptionsChanged));

    public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
        nameof(IDrawable.IsVisible),
        typeof(bool),
        typeof(DrawableElement),
        true,
        propertyChanged: OnVisibilityChanged);

    public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(
        nameof(IDrawable.IsEnabled),
        typeof(bool),
        typeof(DrawableElement),
        true,
        propertyChanged: OnEnabledChanged);

    public static readonly BindableProperty ZIndexProperty = BindableProperty.Create(
        nameof(IDrawable.ZIndex),
        typeof(int),
        typeof(DrawableElement),
        0,
        propertyChanged: OnZIndexChanged);

    public static readonly BindableProperty OpacityProperty = BindableProperty.Create(
        nameof(IDrawable.Opacity),
        typeof(float),
        typeof(DrawableElement),
        1.0f,
        propertyChanged: (bindable, _, _) =>
            ((IDrawable)bindable)
            .OnInvalidationTriggered(IDrawable.InvalidationTrigger.OpacityChanged));

    public static readonly BindableProperty ParentProperty = BindableProperty.Create(
        nameof(IDrawable.Parent),
        typeof(Microsoft.Maui.Controls.View),
        typeof(DrawableElement),
        propertyChanged: OnParentChanged);

    public static void OnVisibilityChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IDrawable)bindable).OnVisibilityChanged((bool)newValue);
    }

    public static void OnEnabledChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IDrawable)bindable).OnEnabledChanged((bool)newValue);
    }

    public static void OnZIndexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IDrawable)bindable).OnZIndexChanged((int)newValue);
    }

    public static void OnParentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IDrawable)bindable).OnParentChanged((Microsoft.Maui.Controls.View)newValue);
    }
}