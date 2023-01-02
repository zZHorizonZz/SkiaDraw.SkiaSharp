using CommunityToolkit.Maui.Markup;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.View;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;
using IImage = Maui.Material.You.Components.Models.IImage;

namespace Maui.Material.You.Components.Image;

public class MaterialVectorView : MaterialView, IImage
{
    public static readonly BindableProperty ColorProperty = ImageElement.ColorProperty;
    public static readonly BindableProperty SourceProperty = ImageElement.SourceProperty;

    internal readonly VectorDrawable mVectorDrawable;

    public MaterialVectorView()
    {
        mVectorDrawable = AddDrawable(new VectorDrawable
            { HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center });

        HeightRequest = 128;
        WidthRequest = 256;

        mVectorDrawable.Bind(ColorProperty, nameof(Color), source: this);
        mVectorDrawable.Bind(SourceProperty, nameof(Source), source: this);
    }

    public string? Source
    {
        get => (string?)GetValue(SourceProperty);
        set => SetValue(SourceProperty, value);
    }

    public Color Color
    {
        get => (Color)GetValue(ColorProperty);
        set => SetValue(ColorProperty, value);
    }

    public void OnSourceChanged()
    {
        InvalidateView();
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