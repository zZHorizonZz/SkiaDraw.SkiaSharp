using System;
using System.Globalization;
using Microsoft.Maui;
using SkiaSharp;

namespace Maui.Material.You.Utils;

public static class ShapeUtils
{
    private const int DEFAULT_XAXISROTATE = 0;

    public static SKPath ArcTo(this SKPath path, float radius, SKPoint finalPoint)
    {
        path.ArcTo(
            new SKPoint(radius, radius),
            DEFAULT_XAXISROTATE,
            SKPathArcSize.Small,
            SKPathDirection.Clockwise,
            finalPoint);

        return path;
    }

    public static SKPath ToRoundedRect(this SKRect rect, CornerRadius corner, float scale)
    {
        var path = new SKPath();

        var rectangleWidth = rect.Width * scale;
        var rectangleHeight = rect.Height * scale;

        var fTopLeftRadius = Convert.ToSingle(corner.TopLeft * scale, CultureInfo.InvariantCulture);
        var fTopRightRadius = Convert.ToSingle(corner.TopRight * scale, CultureInfo.InvariantCulture);
        var fBottomLeftRadius = Convert.ToSingle(corner.BottomLeft * scale, CultureInfo.InvariantCulture);
        var fBottomRightRadius = Convert.ToSingle(corner.BottomRight * scale, CultureInfo.InvariantCulture);

        var startX = fTopLeftRadius;
        var startY = 0;

        path.MoveTo(startX, startY);

        path.LineTo(rectangleWidth - fTopRightRadius, startY);

        if (fTopRightRadius > 0)
            path.ArcTo(fTopRightRadius, new SKPoint(rectangleWidth, fTopRightRadius));

        path.LineTo(rectangleWidth, rectangleHeight - fBottomRightRadius);

        if (fBottomRightRadius > 0)
            path.ArcTo(fBottomRightRadius, new SKPoint(rectangleWidth - fBottomRightRadius, rectangleHeight));

        path.LineTo(fBottomLeftRadius, rectangleHeight);

        if (fBottomLeftRadius > 0)
            path.ArcTo(fBottomLeftRadius, new SKPoint(0, rectangleHeight - fBottomLeftRadius));

        path.LineTo(0, fTopLeftRadius);

        if (fTopLeftRadius > 0)
            path.ArcTo(fTopLeftRadius, new SKPoint(startX, startY));

        path.Close();

        return path;
    }

    public static bool IsEmpty(this CornerRadius corner)
    {
        return corner.TopLeft > 0
            ? false
            : corner.TopRight > 0
                ? false
                : corner.BottomLeft > 0
                    ? false
                    : corner.BottomRight <= 0;
    }
}