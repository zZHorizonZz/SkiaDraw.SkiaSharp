using Maui.Material.You.Components.Models;
using Maui.Material.You.Components.View;
using Microsoft.Maui.Controls;
using SkiaSharp.Views.Maui.Controls;

namespace Maui.Material.You.Components.Elements;

public class MaterialDrawableElement
{
    public static readonly BindableProperty XProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.X),
        typeof(double),
        typeof(MaterialDrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.MeasureChanged));

    public static readonly BindableProperty YProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.Y),
        typeof(double),
        typeof(MaterialDrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.MeasureChanged));

    public static readonly BindableProperty WidthProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.Width),
        typeof(double),
        typeof(MaterialDrawableElement),
        -1.0,
        propertyChanged: (bindable, _, _) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.SizeChanged));

    public static readonly BindableProperty HeightProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.Height),
        typeof(double),
        typeof(MaterialDrawableElement),
        -1.0,
        propertyChanged: (bindable, _, _) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.SizeChanged));

    public static readonly BindableProperty TranslationXProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.TranslationX),
        typeof(double),
        typeof(MaterialDrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.TranslationChanged));

    public static readonly BindableProperty TranslationYProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.TranslationY),
        typeof(double),
        typeof(MaterialDrawableElement),
        0.0,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.TranslationChanged));

    public static readonly BindableProperty HorizontalOptionsProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.HorizontalOptions),
        typeof(LayoutOptions),
        typeof(MaterialDrawableElement),
        LayoutOptions.Start,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.HorizontalOptionsChanged));

    public static readonly BindableProperty VerticalOptionsProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.VerticalOptions),
        typeof(LayoutOptions),
        typeof(MaterialDrawableElement),
        LayoutOptions.Start,
        propertyChanged: (bindable, oldvalue, newvalue) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.VerticalOptionsChanged));

    public static readonly BindableProperty IsVisibleProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.IsVisible),
        typeof(bool),
        typeof(MaterialDrawableElement),
        true,
        propertyChanged: OnVisibilityChanged);

    public static readonly BindableProperty IsEnabledProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.IsEnabled),
        typeof(bool),
        typeof(MaterialDrawableElement),
        true,
        propertyChanged: OnEnabledChanged);

    public static readonly BindableProperty ZIndexProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.ZIndex),
        typeof(int),
        typeof(MaterialDrawableElement),
        0,
        propertyChanged: OnZIndexChanged);

    public static readonly BindableProperty OpacityProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.Opacity),
        typeof(float),
        typeof(MaterialDrawableElement),
        1.0f,
        propertyChanged: (bindable, _, _) =>
            ((IMaterialDrawable)bindable)
            .OnInvalidationTriggered(IMaterialDrawable.InvalidationTrigger.OpacityChanged));

    public static readonly BindableProperty ParentProperty = BindableProperty.Create(
        nameof(IMaterialDrawable.Parent),
        typeof(Microsoft.Maui.Controls.View),
        typeof(MaterialDrawableElement),
        null,
        propertyChanged: OnParentChanged);

    public static void OnVisibilityChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IMaterialDrawable)bindable).OnVisibilityChanged((bool)newValue);
    }

    public static void OnEnabledChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IMaterialDrawable)bindable).OnEnabledChanged((bool)newValue);
    }

    public static void OnZIndexChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IMaterialDrawable)bindable).OnZIndexChanged((int)newValue);
    }

    public static void OnParentChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IMaterialDrawable)bindable).OnParentChanged((Microsoft.Maui.Controls.View)newValue);
    }
}