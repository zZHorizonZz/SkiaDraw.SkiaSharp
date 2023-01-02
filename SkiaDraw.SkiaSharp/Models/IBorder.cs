using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Maui.Material.You.Components.Models;

public interface IBorder
{
    Color BackgroundColor { get; set; }

    /// <summary>
    ///     Border color should be always synchronized with BorderColorTint
    ///     This color is usually used as border color of component.
    /// </summary>
    Color BorderColor { get; }

    /// <summary>
    ///     Border width is used to draw border of component. Determines the thickness of the border.
    /// </summary>
    float BorderWidth { get; }

    /// <summary>
    ///     Corner radius is used to draw border of component. Determines the radius of the border.
    /// </summary>
    CornerRadius CornerRadius { get; }

    bool HasBorder { get; }

    bool HasBackground { get; }

    public void OnBorderChanged();

    public float GetDefaultBorderWidth();
}