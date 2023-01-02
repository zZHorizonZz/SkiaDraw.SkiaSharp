using System;
using System.Reflection;
using Maui.Material.You.Components.Image;
using Microsoft.Maui.Controls.Shapes;
using SkiaSharp;

namespace Maui.Material.You.Extension;

public static class BitmapExtensions
{
    public static SKBitmap LoadBitmapResource(Type type, string resourceID)
    {
        var assembly = type.GetTypeInfo().Assembly;

        using (var stream = assembly.GetManifestResourceStream(resourceID))
        {
            return SKBitmap.Decode(stream);
        }
    }

    public static uint RgbaMakePixel(byte red, byte green, byte blue, byte alpha = 255)
    {
        return (uint)((alpha << 24) | (blue << 16) | (green << 8) | red);
    }

    public static void RgbaGetBytes(this uint pixel, out byte red, out byte green, out byte blue, out byte alpha)
    {
        red = (byte)pixel;
        green = (byte)(pixel >> 8);
        blue = (byte)(pixel >> 16);
        alpha = (byte)(pixel >> 24);
    }

    public static uint BgraMakePixel(byte blue, byte green, byte red, byte alpha = 255)
    {
        return (uint)((alpha << 24) | (red << 16) | (green << 8) | blue);
    }

    public static void BgraGetBytes(this uint pixel, out byte blue, out byte green, out byte red, out byte alpha)
    {
        blue = (byte)pixel;
        green = (byte)(pixel >> 8);
        red = (byte)(pixel >> 16);
        alpha = (byte)(pixel >> 24);
    }

    public static void DrawBitmap(
        this SKCanvas canvas,
        SKBitmap bitmap,
        SKRect dest,
        ImageStretch stretch,
        ImageAlignment horizontal = ImageAlignment.Center,
        ImageAlignment vertical = ImageAlignment.Center,
        SKPaint? paint = null)
    {
        if (stretch == ImageStretch.Fill)
        {
            canvas.DrawBitmap(bitmap, dest, paint);
        }
        else
        {
            float scale = 1;

            switch (stretch)
            {
                case ImageStretch.None:
                    break;

                case ImageStretch.Uniform:
                    scale = Math.Min(dest.Width / bitmap.Width, dest.Height / bitmap.Height);
                    break;

                case ImageStretch.UniformToFill:
                    scale = Math.Max(dest.Width / bitmap.Width, dest.Height / bitmap.Height);
                    break;
            }

            var display = CalculateDisplayRect(
                dest,
                scale * bitmap.Width,
                scale * bitmap.Height,
                horizontal,
                vertical);

            canvas.DrawBitmap(bitmap, display, paint);
        }
    }

    public static void DrawBitmap(
        this SKCanvas canvas,
        SKBitmap bitmap,
        SKRect source,
        SKRect dest,
        ImageStretch stretch,
        ImageAlignment horizontal = ImageAlignment.Center,
        ImageAlignment vertical = ImageAlignment.Center,
        SKPaint? paint = null)
    {
        if (stretch == ImageStretch.Fill)
        {
            canvas.DrawBitmap(bitmap, source, dest, paint);
        }
        else
        {
            float scale = 1;

            switch (stretch)
            {
                case ImageStretch.None:
                    break;

                case ImageStretch.Uniform:
                    scale = Math.Min(dest.Width / source.Width, dest.Height / source.Height);
                    break;

                case ImageStretch.UniformToFill:
                    scale = Math.Max(dest.Width / source.Width, dest.Height / source.Height);
                    break;
            }

            var display = CalculateDisplayRect(
                dest,
                scale * source.Width,
                scale * source.Height,
                horizontal,
                vertical);

            canvas.DrawBitmap(bitmap, source, display, paint);
        }
    }

    public static void DrawImage(
        this SKCanvas canvas,
        SKPicture picture,
        SKRect dest,
        ScaleTransform scale,
        ImageStretch stretch,
        ImageAlignment horizontal = ImageAlignment.Center,
        ImageAlignment vertical = ImageAlignment.Center,
        SKPaint? paint = null)
    {
        var matrix = CalculateDisplayMatrix(dest, scale, stretch, picture.CullRect.Width, picture.CullRect.Height);

        if (stretch == ImageStretch.Fill)
        {
            canvas.DrawPicture(picture, ref matrix, paint);
        }
        else
        {
            var display = CalculateDisplayRect(
                dest,
                matrix.ScaleX * picture.CullRect.Width,
                matrix.ScaleY * picture.CullRect.Height,
                horizontal,
                vertical);

            canvas.Translate(display.Left, display.Top);
            canvas.DrawPicture(picture, ref matrix, paint);
        }
    }

    public static void DrawImage(
        this SKCanvas canvas,
        SKPicture picture,
        SKRect source,
        SKRect dest,
        ScaleTransform scale,
        ImageStretch stretch,
        ImageAlignment horizontal = ImageAlignment.Center,
        ImageAlignment vertical = ImageAlignment.Center,
        SKPaint? paint = null)
    {
        var matrix = CalculateDisplayMatrix(dest, scale, stretch, picture.CullRect.Width, picture.CullRect.Height);

        if (stretch == ImageStretch.Fill)
        {
            canvas.DrawPicture(picture, ref matrix, paint);
        }
        else
        {
            var display = CalculateDisplayRect(
                dest,
                matrix.ScaleX * picture.CullRect.Width,
                matrix.ScaleY * picture.CullRect.Height,
                horizontal,
                vertical);

            canvas.Translate(display.Left, display.Top);
            canvas.DrawPicture(picture, ref matrix, paint);
        }
    }

    private static SKMatrix CalculateDisplayMatrix(
        SKRect dest,
        ScaleTransform scale,
        ImageStretch stretch,
        float width,
        float height)
    {
        var x = (float)scale.ScaleX;
        var y = (float)scale.ScaleY;

        width *= (float)scale.ScaleX;
        height *= (float)scale.ScaleY;

        switch (stretch)
        {
            case ImageStretch.None:
            {
                break;
            }
            case ImageStretch.AspectFill:
            case ImageStretch.Fill:
            {
                x *= width / dest.Width;
                y *= height / dest.Height;

                break;
            }
            case ImageStretch.Uniform:
            {
                x *= Math.Min(dest.Width / width, dest.Height / height);
                y *= Math.Min(dest.Width / width, dest.Height / height);

                break;
            }
        }

        Console.WriteLine(
            $"Data: Scale X: {x} Scale Y: {y} Width: {width} Height: {height} Dest Width: {dest.Width} Dest Height: {dest.Height}");

        return SKMatrix.CreateScale(x, y);
    }

    private static SKRect CalculateDisplayRect(
        SKRect dest,
        float bmpWidth,
        float bmpHeight,
        ImageAlignment horizontal,
        ImageAlignment vertical)
    {
        float x = 0;
        float y = 0;

        switch (horizontal)
        {
            case ImageAlignment.Center:
                x = (dest.Width - bmpWidth) / 2;
                break;

            case ImageAlignment.Start:
                break;

            case ImageAlignment.End:
                x = dest.Width - bmpWidth;
                break;
        }

        switch (vertical)
        {
            case ImageAlignment.Center:
                y = (dest.Height - bmpHeight) / 2;
                break;

            case ImageAlignment.Start:
                break;

            case ImageAlignment.End:
                y = dest.Height - bmpHeight;
                break;
        }

        x += dest.Left;
        y += dest.Top;

        return new SKRect(x, y, x + bmpWidth, y + bmpHeight);
    }
}