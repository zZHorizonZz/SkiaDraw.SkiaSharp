using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.Models;
using Maui.Material.You.Components.View;
using Maui.Material.You.Source;
using Maui.Material.You.Source.Animation;
using Microsoft.Maui.Controls;
using SkiaSharp;

namespace Maui.Material.You.Components.Image;

public class LottieViewDrawable : MaterialDrawable, ILottieAnimator, IDisposable
{
    public static readonly BindableProperty SourceProperty = LottieAnimatorElement.SourceProperty;
    public static readonly BindableProperty AnimationProgressProperty = LottieAnimatorElement.AnimationProgressProperty;
    public static readonly BindableProperty RepeatCountProperty = LottieAnimatorElement.RepeatCountProperty;
    public static readonly BindableProperty RestartProperty = LottieAnimatorElement.RestartProperty;

    public readonly Animation Animation;

    internal LottieSource mSource;

    public LottieViewDrawable()
    {
        Animation = new Animation(progress => { AnimationProgress = progress * 100; });
    }

    public void Dispose()
    {
        Animation.Dispose();
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
        LoadSource(Source);
    }

    public void OnAnimationProgressChanged(double progress)
    {
    }

    public override void Draw(DrawContext context)
    {
        var canvas = context.Canvas;

        if (mSource == null || Source == null)
            return;

        canvas.Save();
        canvas.Clear();
        //canvas.Scale(5);
        canvas.Translate(GetX() * context.Scale, GetY() * context.Scale);

        var totalFrames = mSource.Animation.Fps * mSource.Animation.Duration.TotalSeconds;
        var bound = GetBounds();

        mSource.Animation.SeekFrame(totalFrames / AnimationProgress);
        mSource.Animation
            .Render(canvas,
                new SKRect(bound.Left, bound.Top, bound.Width * context.Scale, bound.Height * context.Scale));

        canvas.Restore();
    }

    private void LoadSource(string path)
    {
        var source = SourceManager.Instance?.GetSource(path);
        switch (source)
        {
            case null:
                throw new Exception($"Source ({path}) of the {nameof(LottieViewDrawable)} can not be found.");
            case LottieSource lottie:
                mSource = lottie;
                mSource.Animation.Seek(0);

                Width = lottie.Width;
                Height = lottie.Height;
                OnVisualPropertyChanged();
                break;
        }
    }
}