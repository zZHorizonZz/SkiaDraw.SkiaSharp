using Maui.Material.You.Components.Models;
using Microsoft.Maui.Controls;

namespace Maui.Material.You.Components.Elements;

public class LottieAnimatorElement
{
    public static readonly BindableProperty SourceProperty = BindableProperty.Create(
        nameof(ILottieAnimator.Source),
        typeof(string),
        typeof(LottieAnimatorElement),
        null,
        propertyChanged: OnAnimationSourceChanged);

    public static readonly BindableProperty AnimationProgressProperty = BindableProperty.Create(
        nameof(ILottieAnimator.AnimationProgress),
        typeof(double),
        typeof(LottieAnimatorElement),
        null,
        propertyChanged: OnAnimationProgressChanged);

    public static readonly BindableProperty RepeatCountProperty = BindableProperty.Create(
        nameof(ILottieAnimator.RepeatCount),
        typeof(int),
        typeof(LottieAnimatorElement),
        -1);

    public static readonly BindableProperty RestartProperty = BindableProperty.Create(
        nameof(ILottieAnimator.Restart),
        typeof(bool),
        typeof(LottieAnimatorElement),
        true);

    public static void OnAnimationSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((ILottieAnimator)bindable).OnAnimationSourceChanged();
    }

    public static void OnAnimationProgressChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((ILottieAnimator)bindable).OnAnimationProgressChanged((double)newValue);
    }
}