using System;
using SkiaSharp;

namespace Maui.Material.You.Components.View;

public class InteractionEventArgs : EventArgs
{
    public InteractionEventArgs(SKPoint point)
    {
        Point = point;
    }

    public SKPoint Point { get; init; }
}