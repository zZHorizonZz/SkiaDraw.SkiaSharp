using IView = Maui.Material.You.Components.Models.IView;

namespace Maui.Material.You.Components.Elements;

public static class ViewElement
{
    public static readonly BindableProperty ContentProperty = BindableProperty.Create(
        nameof(IView.Content),
        typeof(Microsoft.Maui.Controls.View),
        typeof(ViewElement),
        propertyChanged: OnContentChanged);

    public static readonly BindableProperty PaddingProperty = BindableProperty.Create(
        nameof(IView.Padding),
        typeof(Thickness),
        typeof(ViewElement),
        new Thickness(0),
        propertyChanged: OnPaddingChanged);

    public static readonly BindableProperty IsAnimatedProperty = BindableProperty.Create(
        nameof(IView.IsAnimated),
        typeof(bool),
        typeof(ViewElement),
        true,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty EnabledTouchEventsProperty = BindableProperty.Create(
        nameof(IView.EnableTouchEvents),
        typeof(bool),
        typeof(ViewElement),
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty RippleVisibilityProperty = BindableProperty.Create(
        nameof(IView.RippleVisibility),
        typeof(bool),
        typeof(ViewElement),
        false,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty UseIntrinsicHeightProperty = BindableProperty.Create(
        nameof(IView.UseIntrinsicHeight),
        typeof(bool),
        typeof(ViewElement),
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty UseIntrinsicWidthProperty = BindableProperty.Create(
        nameof(IView.UseIntrinsicWidth),
        typeof(bool),
        typeof(ViewElement),
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty BackgroundColorProperty = BindableProperty.Create(
        nameof(IView.BackgroundColor),
        typeof(Color),
        typeof(ViewElement),
        Colors.White,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static readonly BindableProperty RippleColorProperty = BindableProperty.Create(
        nameof(IView.RippleColor),
        typeof(Color),
        typeof(ViewElement),
        Colors.White,
        propertyChanged: VisualElement.OnVisualPropertyChanged);

    public static void OnContentChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        ((IView)bindable).OnContentChanged((Microsoft.Maui.Controls.View?)oldValue,
            (Microsoft.Maui.Controls.View?)newValue);
    }

    public static void OnPaddingChanged(BindableObject bindable, object? oldValue, object? newValue)
    {
        ((IView)bindable).OnPaddingChanged((Thickness?)oldValue, (Thickness?)newValue);
    }
}