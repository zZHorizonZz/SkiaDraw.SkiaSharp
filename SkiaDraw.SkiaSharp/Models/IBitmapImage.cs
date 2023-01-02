using Maui.Material.You.Components.Image;
using Microsoft.Maui;

namespace Maui.Material.You.Components.Models;

public interface IBitmapImage
{
    CornerRadius? CornerRadius { get; }

    float Scale { get; }

    ImageStretch ImageStretch { get; }

    ImageAlignment HorizontalAlignment { get; }

    ImageAlignment VerticalAlignment { get; }

    void OnImageChanged();
}