
namespace Maui.Material.You.Components.Models;

/// <summary>
///     This interface is used in the <see cref="VectorDrawable" /> to provide a way to customize the
///     vector drawable's colors and source.
/// </summary>
public interface IImage
{
    /// <summary>
    ///     Gets or sets the source path to the vector image.
    /// </summary>
    string? Source { get; }

    /// <summary>
    ///     Color should be always synchronized with ColorTint
    ///     This color is usually used as foreground color of component.
    /// </summary>
    Color Color { get; }

    public void OnSourceChanged();
}