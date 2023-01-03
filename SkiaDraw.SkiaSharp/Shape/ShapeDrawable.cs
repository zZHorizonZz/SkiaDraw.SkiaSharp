using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using Maui.Material.You.Components.View;
using Maui.Material.You.Utils;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using IBorder = Maui.Material.You.Components.Models.IBorder;

namespace Maui.Material.You.Components.Shape;

public class ShapeDrawable : Drawable, IBorder
{
    public static readonly BindableProperty BackgroundColorProperty = BorderElement.BackgroundColorProperty;
    public static readonly BindableProperty BorderColorProperty = BorderElement.BorderColorProperty;
    public static readonly BindableProperty BorderWidthProperty = BorderElement.BorderWidthProperty;
    public static readonly BindableProperty CornerRadiusProperty = BorderElement.CornerRadiusProperty;
    public static readonly BindableProperty ShapeTypeProperty = BorderElement.ShapeTypeProperty;
    public static readonly BindableProperty IsFilledProperty = BorderElement.IsFilledProperty;

    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public float BorderWidth
    {
        get => (float)GetValue(BorderWidthProperty);
        set => SetValue(BorderWidthProperty, value);
    }

    public CornerRadius CornerRadius
    {
        get => (CornerRadius)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public ShapeType ShapeType
    {
        get => (ShapeType)GetValue(ShapeTypeProperty);
        set => SetValue(ShapeTypeProperty, value);
    }

    public bool IsFilled
    {
        get => (bool)GetValue(IsFilledProperty);
        set => SetValue(IsFilledProperty, value);
    }

    public bool HasBorder => BorderWidth > 0 && BorderColor != null && BorderColor.Alpha != 0;
    public bool HasBackground => BackgroundColor != null && BackgroundColor.Alpha != 0;

    public void OnBorderChanged()
    {
        OnVisualPropertyChanged();
    }

    public float GetDefaultBorderWidth()
    {
        return 1.5f;
    }

    public override void Draw(DrawContext context)
    {
        var canvas = context.Canvas;

        if (ZIndex == 0)
        {
            canvas.Save();
            canvas.Clear();
            canvas.Restore();
        }

        if (HasBackground && IsFilled)
        {
            canvas.Save();

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = BackgroundColor.WithAlpha(Opacity).ToSKColor()
            };

            var bounds = new SKRect(0, 0,
                (float)(Width - (HasBorder ? BorderWidth : 0)),
                (float)(Height - (HasBorder
                    ? BorderWidth
                    : 0)));

            var path = GetPath(bounds);
            path.Transform(SKMatrix.CreateScale(context.Scale, context.Scale));

            canvas.Translate((GetX() + (HasBorder ? BorderWidth / 2 : 0)) * Context.Scale,
                (GetY() + (HasBorder ? BorderWidth / 2 : 0)) * Context.Scale);
            canvas.DrawPath(path, paint);
            canvas.Restore();
        }

        if (HasBorder)
        {
            if (!HasBackground)
                canvas.Clear();

            canvas.Save();

            var paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = BorderColor.WithAlpha(Opacity).ToSKColor(),
                StrokeWidth = BorderWidth * context.Scale
            };

            var bounds = new SKRect(0, 0,
                (float)(Width - (GetX() + BorderWidth)),
                (float)(Height - (GetY() + BorderWidth)));

            var path = GetPath(bounds);
            path.Transform(SKMatrix.CreateScale(context.Scale, context.Scale));

            canvas.Translate((GetX() + BorderWidth / 2) * context.Scale, (GetY() + BorderWidth / 2) * context.Scale);
            canvas.DrawPath(path, paint);
            canvas.Restore();
        }
    }

    private SKPath GetPath(SKRect bounds)
    {
        var path = ShapeType switch
        {
            ShapeType.Rectangle => bounds.CreateRectangle(),
            ShapeType.CutCornerRectangle => bounds.CreateCutCornerRectangle(CornerRadius),
            ShapeType.RoundedRectangle => bounds.CreateRoundedRectangle(CornerRadius),
            ShapeType.Circle => bounds.CreateCircle(),
            ShapeType.Oval => bounds.CreateOval(),
            ShapeType.Triangle => bounds.CreateTriangle(),
            ShapeType.Diamond => bounds.CreateDiamond(),
            ShapeType.Pentagon => bounds.CreatePentagon(),
            ShapeType.Hexagon => bounds.CreateHexagon(),
            ShapeType.Star => bounds.CreateStar(),
            _ => throw new ArgumentOutOfRangeException(nameof(Shape.ShapeType))
        };

        return path;
    }
}