namespace Maui.Material.You.Components.Models;

public interface ILottieAnimator
{
    string Source { get; }

    double AnimationProgress { get; }

    int RepeatCount { get; }

    bool Restart { get; }

    void OnAnimationSourceChanged();

    void OnAnimationProgressChanged(double progress);
}