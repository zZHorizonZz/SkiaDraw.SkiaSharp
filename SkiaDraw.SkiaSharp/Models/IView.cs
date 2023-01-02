using Microsoft.Maui;
using Microsoft.Maui.Graphics;

namespace Maui.Material.You.Components.Models;

public interface IView
{
    public Microsoft.Maui.Controls.View Content { get; set; }

    public bool EnableTouchEvents { get; set; }

    public bool RippleVisibility { get; set; }

    public bool IsAnimated { get; set; }

    Thickness Padding { get; set; }

    bool UseIntrinsicHeight { get; set; }

    bool UseIntrinsicWidth { get; set; }

    Color BackgroundColor { get; set; }
    
    Color RippleColor { get; set; }

    public void OnContentChanged(Microsoft.Maui.Controls.View? oldValue, Microsoft.Maui.Controls.View? newValue);

    public void OnPaddingChanged(Thickness? oldValue, Thickness? newValue);
}