using System;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Models;
using Maui.Material.You.Components.View;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using SkiaSharp;
using SkiaSharp.Views.Maui.Controls;
using IAnimatable = Microsoft.Maui.Controls.IAnimatable;
using IDrawable = Maui.Material.You.Components.Models.IDrawable;
using IView = Microsoft.Maui.IView;
using IVisual = Maui.Material.You.Components.Models.IVisual;

namespace Maui.Material.You.Components.Internal;

public abstract class Drawable : BindableObject, IDrawable, IVisual
{
    public static readonly BindableProperty XProperty = DrawableElement.XProperty;
    public static readonly BindableProperty YProperty = DrawableElement.YProperty;
    public static readonly BindableProperty WidthProperty = DrawableElement.WidthProperty;
    public static readonly BindableProperty HeightProperty = DrawableElement.HeightProperty;
    public static readonly BindableProperty TranslationXProperty = DrawableElement.TranslationXProperty;
    public static readonly BindableProperty TranslationYProperty = DrawableElement.TranslationYProperty;

    public static readonly BindableProperty HorizontalOptionsProperty =
        DrawableElement.HorizontalOptionsProperty;

    public static readonly BindableProperty VerticalOptionsProperty = DrawableElement.VerticalOptionsProperty;
    public static readonly BindableProperty IsVisibleProperty = DrawableElement.IsVisibleProperty;
    public static readonly BindableProperty IsEnabledProperty = DrawableElement.IsEnabledProperty;
    public static readonly BindableProperty ZIndexProperty = DrawableElement.ZIndexProperty;
    public static readonly BindableProperty OpacityProperty = DrawableElement.OpacityProperty;
    public static readonly BindableProperty ParentProperty = DrawableElement.ParentProperty;

    public DrawContext Context { get; set; }

    public double X
    {
        get => (double)GetValue(XProperty);
        set => SetValue(XProperty, value);
    }

    public double Y
    {
        get => (double)GetValue(YProperty);
        set => SetValue(YProperty, value);
    }

    public double Width
    {
        get => (double)GetValue(WidthProperty);
        set => SetValue(WidthProperty, value);
    }

    public double Height
    {
        get => (double)GetValue(HeightProperty);
        set => SetValue(HeightProperty, value);
    }

    public double TranslationX
    {
        get => (double)GetValue(TranslationXProperty);
        set => SetValue(TranslationXProperty, value);
    }

    public double TranslationY
    {
        get => (double)GetValue(TranslationYProperty);
        set => SetValue(TranslationYProperty, value);
    }

    public LayoutOptions HorizontalOptions
    {
        get => (LayoutOptions)GetValue(HorizontalOptionsProperty);
        set => SetValue(HorizontalOptionsProperty, value);
    }

    public LayoutOptions VerticalOptions
    {
        get => (LayoutOptions)GetValue(VerticalOptionsProperty);
        set => SetValue(VerticalOptionsProperty, value);
    }

    public bool IsVisible
    {
        get => (bool)GetValue(IsVisibleProperty);
        set => SetValue(IsVisibleProperty, value);
    }

    public bool IsEnabled
    {
        get => (bool)GetValue(IsEnabledProperty);
        set => SetValue(IsEnabledProperty, value);
    }

    public int ZIndex
    {
        get => (int)GetValue(ZIndexProperty);
        set => SetValue(ZIndexProperty, value);
    }

    public float Opacity
    {
        get => (float)GetValue(OpacityProperty);
        set => SetValue(OpacityProperty, value);
    }

    public Microsoft.Maui.Controls.View Parent
    {
        get => (Microsoft.Maui.Controls.View)GetValue(ParentProperty);
        set => SetValue(ParentProperty, value);
    }

    public event EventHandler? InvalidationHandler;

    public void OnInvalidationTriggered(IDrawable.InvalidationTrigger trigger)
    {
        InvalidationHandler?.Invoke(this, EventArgs.Empty);
    }

    public void OnVisibilityChanged(bool isVisible)
    {
        InvalidationHandler?.Invoke(this, EventArgs.Empty);
    }

    public void OnEnabledChanged(bool isEnabled)
    {
        InvalidationHandler?.Invoke(this, EventArgs.Empty);
    }

    public void OnZIndexChanged(int zIndex)
    {
        InvalidationHandler?.Invoke(this, EventArgs.Empty);
    }

    public void OnParentChanged(Microsoft.Maui.Controls.View parent)
    {
        InvalidationHandler?.Invoke(this, EventArgs.Empty);
    }

    public float GetX()
    {
        return GetX(Parent);
    }

    public float GetX(Microsoft.Maui.Controls.View? parent)
    {
        var x = X;
        var width = Width;

        if (parent != null) width = parent.Width;

        switch (HorizontalOptions.Alignment)
        {
            case LayoutAlignment.Center:
                x += width / 2 - Width / 2;
                break;
            case LayoutAlignment.End:
                x += width - Width;
                break;
        }

        return (float)(x + TranslationX);
    }

    public float GetY()
    {
        return GetY(Parent);
    }

    public float GetY(Microsoft.Maui.Controls.View? parent)
    {
        var y = Y;
        var height = Height;

        if (parent != null) height = parent.Height;

        switch (VerticalOptions.Alignment)
        {
            case LayoutAlignment.Center:
                y += height / 2 - Height / 2;
                break;
            case LayoutAlignment.End:
                y += height - Height;
                break;
        }

        return (float)(y + TranslationY);
    }

    public SKRect GetBounds()
    {
        return GetBounds(Parent);
    }

    public SKRect GetBounds(Microsoft.Maui.Controls.View? parent)
    {
        var x = GetX(parent);
        var y = GetY(parent);

        return new SKRect(x, y, x + (float)Width, y + (float)Height);
    }

    public void OnVisualPropertyChanged()
    {
        InvalidationHandler?.Invoke(this, EventArgs.Empty);
    }

    public abstract void Draw(DrawContext context);
}