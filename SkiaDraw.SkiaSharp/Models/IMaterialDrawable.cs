using System;
using Maui.Material.You.Components.View;
using Microsoft.Maui.Controls;
using SkiaSharp.Views.Maui.Controls;

namespace Maui.Material.You.Components.Models;

public interface IMaterialDrawable
{
    public enum InvalidationTrigger
    {
        Undefined = 0,
        TranslationChanged = 1 << 0,
        MeasureChanged = 1 << 1,
        HorizontalOptionsChanged = 1 << 2,
        VerticalOptionsChanged = 1 << 3,
        OpacityChanged = 1 << 4,
        SizeChanged = 1 << 5
    }

    double X { get; }

    double Y { get; }

    double Width { get; }

    double Height { get; }

    double TranslationX { get; }

    double TranslationY { get; }

    LayoutOptions HorizontalOptions { get; }

    LayoutOptions VerticalOptions { get; }

    bool IsVisible { get; }

    bool IsEnabled { get; }

    int ZIndex { get; }

    float Opacity { get; }

    Microsoft.Maui.Controls.View Parent { get; }

    event EventHandler InvalidationHandler;

    void OnInvalidationTriggered(InvalidationTrigger trigger);

    void OnVisibilityChanged(bool isVisible);

    void OnEnabledChanged(bool isEnabled);

    void OnZIndexChanged(int zIndex);

    void OnParentChanged(Microsoft.Maui.Controls.View parent);
}