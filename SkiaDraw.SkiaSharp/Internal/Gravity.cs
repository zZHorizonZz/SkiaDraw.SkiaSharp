namespace Maui.Material.You.Components.Internal;

public class Gravity
{
    public static readonly int BOTTOM = 0x02;
    public static readonly int BOTTOM_CENTER = BOTTOM | CENTER_HORIZONTAL;
    public static readonly int BOTTOM_LEFT = BOTTOM << LEFT;
    public static readonly int BOTTOM_RIGHT = BOTTOM << RIGHT;

    public static readonly int CENTER = CENTER_HORIZONTAL | CENTER_VERTICAL;

    public static readonly int CENTER_HORIZONTAL = 0x04;

    public static readonly int CENTER_VERTICAL = 0x08;

    //First bit alignment to left 0 alignment to right 1
    //Second bit alignment to top 0 alignment to bottom 0
    //Third bit center horizontal
    //Fourth bit center vertical
    public static readonly int LEFT = 0x00;

    public static readonly int LEFT_CENTER = LEFT | CENTER_VERTICAL;
    public static readonly int RIGHT = 0x01;
    public static readonly int RIGHT_CENTER = RIGHT | CENTER_VERTICAL;
    public static readonly int TOP = 0x00;
    public static readonly int TOP_CENTER = TOP | CENTER_HORIZONTAL;
    public static readonly int TOP_LEFT = TOP << LEFT;
    public static readonly int TOP_RIGHT = RIGHT << TOP;
}