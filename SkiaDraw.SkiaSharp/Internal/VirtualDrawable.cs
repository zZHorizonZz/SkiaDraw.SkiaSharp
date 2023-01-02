using Maui.Material.You.Components.View;

namespace Maui.Material.You.Components.Internal;

public abstract class VirtualDrawable<TVirtual> : MaterialDrawable where TVirtual : MaterialView
{
    public VirtualDrawable(TVirtual virtualElement)
    {
        VirtualElement = virtualElement;
    }

    public TVirtual VirtualElement { get; }
}