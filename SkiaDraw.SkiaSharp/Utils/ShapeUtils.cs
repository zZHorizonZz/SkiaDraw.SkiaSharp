using System;
using System.Globalization;
using Microsoft.Maui;
using SkiaSharp;

namespace Maui.Material.You.Utils;

public static class ShapeUtils
{
    public static SKPath CreateTriangle(this SKRect rect)
    {
        return CreateTriangle(rect.Width, rect.Height);
    }

    public static SKPath CreateTriangle(float width, float height)
    {
        var path = new SKPath();
        path.MoveTo(0, 0);
        path.LineTo(width, 0);
        path.LineTo(width / 2, height);
        path.Close();
        return path;
    }

    public static SKPath CreateOval(this SKRect rect)
    {
        return CreateOval(rect.Width, rect.Height);
    }

    public static SKPath CreateOval(float width, float height)
    {
        var path = new SKPath();
        path.AddOval(new SKRect(0, 0, width, height));
        return path;
    }

    public static SKPath CreateCircle(this SKRect rect)
    {
        var radius = Math.Min(rect.Width, rect.Height) / 2;
        return CreateCircle(radius);
    }

    public static SKPath CreateCircle(float radius)
    {
        var path = new SKPath();
        path.AddCircle(radius, radius, radius);
        return path;
    }

    public static SKPath CreateRectangle(this SKRect rect)
    {
        return CreateRectangle(rect.Width, rect.Height);
    }

    public static SKPath CreateRectangle(float width, float height)
    {
        var path = new SKPath();
        path.AddRect(new SKRect(0, 0, width, height));
        return path;
    }

    public static SKPath CreateRoundedRectangle(this SKRect rect, CornerRadius corner)
    {
        return CreateRoundedRectangle(rect.Width, rect.Height, corner);
    }

    public static SKPath CreateRoundedRectangle(float width, float height, CornerRadius corner)
    {
        var path = new SKPath();

        var fTopLeftRadius = Convert.ToSingle(corner.TopLeft, CultureInfo.InvariantCulture);
        var fTopRightRadius = Convert.ToSingle(corner.TopRight, CultureInfo.InvariantCulture);
        var fBottomLeftRadius = Convert.ToSingle(corner.BottomLeft, CultureInfo.InvariantCulture);
        var fBottomRightRadius = Convert.ToSingle(corner.BottomRight, CultureInfo.InvariantCulture);

        const int startY = 0;
        path.MoveTo(fTopLeftRadius, startY);
        path.LineTo(width - fTopRightRadius, startY);

        if (fTopRightRadius > 0)
            path.ArcTo(fTopRightRadius, new SKPoint(width, fTopRightRadius));

        path.LineTo(width, height - fBottomRightRadius);

        if (fBottomRightRadius > 0)
            path.ArcTo(fBottomRightRadius, new SKPoint(width - fBottomRightRadius, height));

        path.LineTo(fBottomLeftRadius, height);

        if (fBottomLeftRadius > 0)
            path.ArcTo(fBottomLeftRadius, new SKPoint(0, height - fBottomLeftRadius));

        path.LineTo(0, fTopLeftRadius);

        if (fTopLeftRadius > 0)
            path.ArcTo(fTopLeftRadius, new SKPoint(fTopLeftRadius, startY));

        path.Close();

        return path;
    }

    public static SKPath CreateCutCornerRectangle(this SKRect rect, CornerRadius corner)
    {
        return CreateCutCornerRectangle(rect.Width, rect.Height, corner);
    }

    public static SKPath CreateCutCornerRectangle(float width, float height, CornerRadius corner)
    {
        var path = new SKPath();

        var fTopLeftRadius = Convert.ToSingle(corner.TopLeft, CultureInfo.InvariantCulture);
        var fTopRightRadius = Convert.ToSingle(corner.TopRight, CultureInfo.InvariantCulture);
        var fBottomLeftRadius = Convert.ToSingle(corner.BottomLeft, CultureInfo.InvariantCulture);
        var fBottomRightRadius = Convert.ToSingle(corner.BottomRight, CultureInfo.InvariantCulture);

        path.MoveTo(fTopLeftRadius, 0);
        path.LineTo(width - fTopRightRadius, 0);
        path.LineTo(width, fTopRightRadius);
        path.LineTo(width, height - fBottomRightRadius);
        path.LineTo(width - fBottomRightRadius, height);
        path.LineTo(fBottomLeftRadius, height);
        path.LineTo(0, height - fBottomLeftRadius);
        path.LineTo(0, fTopLeftRadius);
        path.Close();

        return path;
    }

    public static SKPath CreateDiamond(this SKRect rect)
    {
        return CreateDiamond(rect.Width, rect.Height);
    }

    public static SKPath CreateDiamond(float width, float height)
    {
        var path = new SKPath();
        path.MoveTo(width / 2, 0);
        path.LineTo(width, height / 2);
        path.LineTo(width / 2, height);
        path.LineTo(0, height / 2);
        path.Close();
        return path;
    }

    public static SKPath CreatePentagon(this SKRect rect)
    {
        return CreatePentagon(rect.Width, rect.Height);
    }

    public static SKPath CreatePentagon(float width, float height)
    {
        var path = new SKPath();
        path.MoveTo(width / 2, 0);
        path.LineTo(width, height / 2);
        path.LineTo(width * 0.75f, height);
        path.LineTo(width * 0.25f, height);
        path.LineTo(0, height / 2);
        path.Close();
        return path;
    }

    public static SKPath CreateHexagon(this SKRect rect)
    {
        return CreateHexagon(rect.Width, rect.Height);
    }

    public static SKPath CreateHexagon(float width, float height)
    {
        var path = new SKPath();
        path.MoveTo(width / 2, 0);
        path.LineTo(width, height / 4);
        path.LineTo(width, height * 0.75f);
        path.LineTo(width / 2, height);
        path.LineTo(0, height * 0.75f);
        path.LineTo(0, height / 4);
        path.Close();
        return path;
    }

    public static SKPath CreateStar(this SKRect rect)
    {
        return CreateStar(rect.Width, rect.Height);
    }

    public static SKPath CreateStar(float width, float height)
    {
        var path = new SKPath();
        path.MoveTo(width / 2, 0);
        path.LineTo(width * 0.6f, height * 0.4f);
        path.LineTo(width, height * 0.4f);
        path.LineTo(width * 0.7f, height * 0.6f);
        path.LineTo(width * 0.8f, height);
        path.LineTo(width / 2, height * 0.8f);
        path.LineTo(width * 0.2f, height);
        path.LineTo(width * 0.3f, height * 0.6f);
        path.LineTo(0, height * 0.4f);
        path.LineTo(width * 0.4f, height * 0.4f);
        path.Close();
        return path;
    }

    private static SKPath ArcTo(this SKPath path, float radius, SKPoint finalPoint)
    {
        path.ArcTo(
            new SKPoint(radius, radius),
            0,
            SKPathArcSize.Small,
            SKPathDirection.Clockwise,
            finalPoint);

        return path;
    }
}