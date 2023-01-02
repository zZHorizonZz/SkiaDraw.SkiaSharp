using Microsoft.Maui.Controls;
using IVisual = Maui.Material.You.Components.Models.IVisual;

namespace Maui.Material.You.Components.Elements;

public static class VisualElement
{
    public static void OnVisualPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        ((IVisual)bindable).OnVisualPropertyChanged();
    }
}