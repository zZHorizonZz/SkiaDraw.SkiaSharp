using System;
using Microsoft.Maui.Graphics;

namespace Maui.Material.You.Components.Internal;

public interface IContentDrawable : IDrawable
{
    TDrawable AddDrawable<TDrawable>(TDrawable drawable) where TDrawable : IDrawable;

    IDrawable[] GetDrawable(Type type);

    void RemoveDrawable(IDrawable drawable);

    void DrawComponent(ICanvas canvas, RectF rect);
}