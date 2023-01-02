namespace Maui.Material.You.Source.Image;

public interface IImageSource : ISource
{
    public float Width { get; }

    public float Height { get; }

    public float Scale { get; set; }
}