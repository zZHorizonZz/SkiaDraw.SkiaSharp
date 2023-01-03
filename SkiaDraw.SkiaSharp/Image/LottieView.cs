using System;
using System.Runtime.CompilerServices;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.Models;
using Maui.Material.You.Components.View;
using Microsoft.Maui;
using Microsoft.Maui.Controls;

namespace Maui.Material.You.Components.Image;

public class LottieView : DrawView, ILottieAnimator
{
    public static readonly BindableProperty SourceProperty = LottieAnimatorElement.SourceProperty;
    public static readonly BindableProperty AnimationProgressProperty = LottieAnimatorElement.AnimationProgressProperty;
    public static readonly BindableProperty RepeatCountProperty = LottieAnimatorElement.RepeatCountProperty;
    public static readonly BindableProperty RestartProperty = LottieAnimatorElement.RestartProperty;

    internal LottieViewDrawable mLottieDrawable;

    public LottieView()
    {
        mLottieDrawable = AddDrawable(new LottieViewDrawable());

        HeightRequest = 256;

        mLottieDrawable.SetBinding(LottieViewDrawable.SourceProperty, new Binding(nameof(Source), source: this));
        mLottieDrawable.SetBinding(LottieViewDrawable.AnimationProgressProperty,
            new Binding(nameof(AnimationProgress), source: this, mode: BindingMode.OneWayToSource));
        mLottieDrawable.SetBinding(LottieViewDrawable.RepeatCountProperty,
            new Binding(nameof(RepeatCount), source: this));
        mLottieDrawable.SetBinding(LottieViewDrawable.RestartProperty, new Binding(nameof(Restart), source: this));
        mLottieDrawable.SetBinding(Drawable.WidthProperty, new Binding(nameof(Width), source: this));
        mLottieDrawable.SetBinding(Drawable.HeightProperty, new Binding(nameof(Height), source: this));
    }

    public string Source
    {
        get => (string)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public double AnimationProgress
    {
        get => (double)GetValue(AnimationProgressProperty);
        set => SetValue(AnimationProgressProperty, value);
    }

    public int RepeatCount
    {
        get => (int)GetValue(RepeatCountProperty);
        set => SetValue(RepeatCountProperty, value);
    }

    public bool Restart
    {
        get => (bool)GetValue(RestartProperty);
        set => SetValue(RestartProperty, value);
    }

    public void OnAnimationSourceChanged()
    {
        InvalidateView();
    }

    public void OnAnimationProgressChanged(double progress)
    {
        InvalidateView();
    }

    protected override void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
        base.OnPropertyChanged(propertyName);

        if (propertyName == nameof(Window) && IsLoaded) mLottieDrawable.Dispose();
    }

    public void Commit(string name, uint rate = 16, uint duration = 250, Easing easing = null,
        Action<double, bool> finished = null)
    {
        mLottieDrawable.Animation.Commit(this, name, rate, duration, easing, finished);
    }

    public override double GetIntrinsicHeight()
    {
        return HeightRequest;
    }

    public override double GetIntrinsicWidth()
    {
        return WidthRequest;
    }
}