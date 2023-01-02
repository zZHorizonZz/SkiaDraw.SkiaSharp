namespace Maui.Material.You.Extension;

public static class NumericExtensions
{
    public static double Clamp(this double self, double min, double max)
    {
        if (max < min)
            return max;
        if (self < min)
            return min;
        if (self > max) return max;

        return self;
    }
}