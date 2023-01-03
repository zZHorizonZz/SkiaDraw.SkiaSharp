using Maui.Material.You.Components.View;

namespace Maui.Material.You.Components.Internal;

public abstract class VirtualDrawable<TVirtual> : Drawable where TVirtual : DrawView
{
    public VirtualDrawable(TVirtual virtualElement)
    {
        VirtualElement = virtualElement;
    }

    public TVirtual VirtualElement { get; }
}