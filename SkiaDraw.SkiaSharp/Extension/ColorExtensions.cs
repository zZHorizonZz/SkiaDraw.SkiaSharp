using Microsoft.Maui.ApplicationModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace Maui.Material.You.Extension;

public static class ColorExtensions
{
    private const float LighterFactor = 1.1f;
    private const float DarkerFactor = 0.9f;

    public static Color WithDefault(this Color color, string defaultColor)
    {
        if (color != null && !color.IsDefault())
            return color;
        return Color.FromArgb(defaultColor);
    }

    public static Color WithDefault(this Color color, string defaultLightColor, string defaultDarkColor)
    {
        if (!color.IsDefault()) return color;

        if (Application.Current?.RequestedTheme == AppTheme.Light)
            return Color.FromArgb(defaultLightColor);
        return Color.FromArgb(defaultDarkColor);
    }

    public static Color ToColor(this string hex)
    {
        return Color.FromArgb(hex);
    }

    public static Color Lighter(this Color color)
    {
        return new Color(
            color.Red * LighterFactor,
            color.Green * LighterFactor,
            color.Blue * LighterFactor,
            color.Alpha);
    }

    public static Color Darker(this Color color)
    {
        return new Color(
            color.Red * DarkerFactor,
            color.Green * DarkerFactor,
            color.Blue * DarkerFactor,
            color.Alpha);
    }

    public static Color ContrastColor(this Color color)
    {
        // Calculate the perceptive luminance (aka luma) - human eye favors green color
        var luma = (0.299 * color.Red + 0.587 * color.Green + 0.114 * color.Blue) / 255;

        // Return black for bright colors, white for dark colors
        return luma > 0.5 ? Colors.Black : Colors.White;
    }
}