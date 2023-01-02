using System.Collections.ObjectModel;
using Maui.Material.You.Components.Elements;
using Maui.Material.You.Components.Internal;
using SkiaSharp;
using SkiaSharp.Views.Maui;
using SkiaSharp.Views.Maui.Controls;
using IView = Maui.Material.You.Components.Models.IView;
using IVisual = Maui.Material.You.Components.Models.IVisual;

namespace Maui.Material.You.Components.View;

/// <summary>
///     This class is foundation of all views used by this library. It provides basic properties such as Color of the
///     container or color of the content. Also this view is interactable with variety of interactive events like
///     <see
///         cref="PressedHandler" />
///     , <see cref="ReleasedHandler" /> or <see cref="HoldHandler" />.
///     If we want to assign content to this view we can do it trough <see cref="Content" /> property.
/// </summary>
/// <remarks>
///     <para>
///         Example code showcase hot to create new MaterialView with Test label inside.
///     </para>
///     <example>
///         <code lang="csharp lang-csharp"><![CDATA[
/// class TestView : MaterialView 
/// {
///     public TestView() 
///     {
///         Content = new StackLayout() { Children = new Label() { Text = "Test" } }
///     }
/// }]]>
/// </code>
///     </example>
/// </remarks>
public abstract class MaterialView : ContentView, IView, IVisual
{
    public new static readonly BindableProperty BackgroundColorProperty = ViewElement.BackgroundColorProperty;
    public static readonly BindableProperty RippleColorProperty = ViewElement.RippleColorProperty;

    public new static readonly BindableProperty ContentProperty = ViewElement.ContentProperty;
    public static readonly BindableProperty EnabledTouchEventsProperty = ViewElement.EnabledTouchEventsProperty;

    public static readonly BindableProperty IsAnimatedProperty = ViewElement.IsAnimatedProperty;
    public new static readonly BindableProperty PaddingProperty = ViewElement.PaddingProperty;
    public static readonly BindableProperty RippleVisibilityProperty = ViewElement.RippleVisibilityProperty;

    public static readonly BindableProperty UseIntrinsicHeightProperty = ViewElement.UseIntrinsicHeightProperty;
    public static readonly BindableProperty UseIntrinsicWidthProperty = ViewElement.UseIntrinsicWidthProperty;

    internal SKCanvasView mCanvasView;
    internal readonly Grid mRoot;

    private readonly IList<MaterialDrawable> mViewDrawable;

    private readonly ObservableCollection<IGestureRecognizer> mGestureRecognizers = new();
    private int mTapCount;
    private long mLastTapTime;
    private long mLastPressTime;

    protected MaterialView()
    {
        mCanvasView = new SKCanvasView { VerticalOptions = LayoutOptions.Fill, HorizontalOptions = LayoutOptions.Fill };

        mRoot = new Grid
        {
            Children = { mCanvasView },
            VerticalOptions = LayoutOptions.Fill,
            HorizontalOptions = LayoutOptions.Fill,
            Margin = new Thickness(0)
        };

        mViewDrawable = new List<MaterialDrawable>();
        mCanvasView.EnableTouchEvents = true;
        mCanvasView.Loaded += OnLoaded;

        base.Content = mRoot;
    }

    public SKCanvas Canvas { get; private set; }

    private bool CanRelease { get; set; }
    private long HoldingStartTime { get; set; }
    private bool IsHolding { get; set; }

    public new Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public new Microsoft.Maui.Controls.View Content
    {
        get => (Microsoft.Maui.Controls.View)GetValue(ContentProperty);
        set => SetValue(ContentProperty, value);
    }

    public bool EnableTouchEvents
    {
        get => (bool)GetValue(EnabledTouchEventsProperty);
        set => SetValue(EnabledTouchEventsProperty, value);
    }

    public bool IsAnimated
    {
        get => (bool)GetValue(IsAnimatedProperty);
        set => SetValue(IsAnimatedProperty, value);
    }

    public new Thickness Padding
    {
        get => (Thickness)GetValue(PaddingProperty);
        set => SetValue(PaddingProperty, value);
    }

    public bool RippleVisibility
    {
        get => (bool)GetValue(RippleVisibilityProperty);
        set => SetValue(RippleVisibilityProperty, value);
    }

    public bool UseIntrinsicHeight
    {
        get => (bool)GetValue(UseIntrinsicHeightProperty);
        set => SetValue(UseIntrinsicHeightProperty, value);
    }

    public bool UseIntrinsicWidth
    {
        get => (bool)GetValue(UseIntrinsicWidthProperty);
        set => SetValue(UseIntrinsicWidthProperty, value);
    }

    public Color RippleColor
    {
        get => (Color)GetValue(RippleColorProperty);
        set => SetValue(RippleColorProperty, value);
    }

    public new IList<IGestureRecognizer> GestureRecognizers => mGestureRecognizers;

    public void OnContentChanged(Microsoft.Maui.Controls.View? oldValue, Microsoft.Maui.Controls.View? newValue)
    {
        if (newValue == null) return;
        if (base.Content is not Grid root) return;
        if (newValue is Layout layout) layout.Padding = Padding;

        if (oldValue != null)
            root.Children.Remove(oldValue);
        root.Children.Add(newValue);
    }

    public void OnPaddingChanged(Thickness? oldValue, Thickness? newValue)
    {
        if (Content is not Layout layout) return;
        base.Padding = 0;
        layout.Padding = newValue ?? new Thickness();
        mCanvasView.InvalidateSurface();
    }

    public void OnVisualPropertyChanged()
    {
        InvalidateSurface(mCanvasView);
    }

    /// <summary>
    ///     Hold handler is called after 1000 milliseconds after <see cref="PressedHandler"></see> is called.
    ///     This handler is mutually exclusive with <see cref="ReleasedHandler" /> which means that this or that event
    ///     will be called.
    /// </summary>
    public event EventHandler<InteractionEventArgs>? HoldHandler;

    /// <summary>
    ///     Pressed handler is called immediately after user touches the screen or presses the mouse
    ///     over current view.
    /// </summary>
    public event EventHandler<InteractionEventArgs>? PressedHandler;

    /// <summary>
    ///     Released handler is called when user releases his press on the screen but if <see cref="HoldHandler" />
    ///     has been called then this event is not called. Basically they are mutually exclusive.
    /// </summary>
    public event EventHandler<InteractionEventArgs>? ReleasedHandler;

    /// <summary>
    ///     > This function is called before the object is drawn
    /// </summary>
    /// <param name="DrawContext">
    ///     This is the context that this view is currently in. It contains
    ///     information about the current canvas state, such as canvas itself, Information about dimensions
    ///     and what scale is currently being used.
    /// </param>
    protected virtual void BeforeDraw(DrawContext context)
    {
        if (!mViewDrawable.Any()) return;

        DrawDrawable(context);
    }

    protected void Draw(DrawContext context)
    {
    }

    protected void DrawDrawable(DrawContext context)
    {
        foreach (var drawable in mViewDrawable.OrderBy(drawable => drawable.ZIndex))
        {
            if (!drawable.IsVisible) continue;
            drawable.Context = context;
            drawable.Draw(context);
        }
    }

    protected void OnCanvasViewPaintSurface(object? sender, SKPaintSurfaceEventArgs args)
    {
        var surface = args.Surface;
        var canvas = surface.Canvas;
        var scale = Math.Min(args.Info.Width / mCanvasView.Width, args.Info.Height / mCanvasView.Height);

        using var paint = new SKPaint();

        paint.IsAntialias = true;

        Canvas = canvas;
        var context = new DrawContext(canvas, args.Info, (float)scale);

        BeforeDraw(context);
        Draw(context);

        if (UseIntrinsicHeight)
        {
            var height = GetIntrinsicHeight();
            if (height > 0 && Height != height) HeightRequest = height;
        }

        if (UseIntrinsicWidth)
        {
            var width = GetIntrinsicWidth();
            if (width > 0 && Width != width) WidthRequest = width;
        }
    }

    protected virtual void OnTouch(object? sender, SKTouchEventArgs args)
    {
        args.Handled = true;
        switch (args.ActionType)
        {
            case SKTouchAction.Pressed:
            {
                Pressed(args.Location);
                break;
            }
            case SKTouchAction.Released:
            {
                Released(args.Location);
                break;
            }
            case SKTouchAction.Moved:
            {
                if (IsHolding && HoldingStartTime + 1000 < DateTimeOffset.Now.ToUnixTimeMilliseconds())
                {
                    CanRelease = false;
                    Hold(args.Location);
                }

                break;
            }
            default:
            {
                IsHolding = false;
                break;
            }
        }
    }

    internal void OnLoaded(object? sender, EventArgs e)
    {
        if (mCanvasView == null) return;

        mCanvasView.PaintSurface += OnCanvasViewPaintSurface;
        mCanvasView.Touch += OnTouch;
        mCanvasView.Unloaded += OnUnloaded;
        mCanvasView.Loaded -= OnLoaded;

        mCanvasView.InvalidateSurface();
    }

    internal void OnUnloaded(object? sender, EventArgs e)
    {
        if (mCanvasView == null) return;

        mCanvasView.PaintSurface -= OnCanvasViewPaintSurface;
        mCanvasView.Touch -= OnTouch;
        mCanvasView.Unloaded -= OnUnloaded;
        mCanvasView.Loaded += OnLoaded;
    }

    public TDrawable AddDrawable<TDrawable>(TDrawable drawable) where TDrawable : MaterialDrawable
    {
        drawable.InvalidationHandler += OnDrawableInvalidate;
        drawable.Parent = mCanvasView;
        mViewDrawable.Add(drawable);
        return drawable;
    }

    public IEnumerable<MaterialDrawable> GetDrawable(Type type)
    {
        return mViewDrawable
            .Where(drawable => drawable.GetType() == type)
            .ToArray();
    }

    public virtual double GetIntrinsicHeight()
    {
        return -1;
    }

    public virtual double GetIntrinsicWidth()
    {
        return -1;
    }

    public virtual void Hold(SKPoint point)
    {
        HoldHandler?.Invoke(this, new InteractionEventArgs(point));
    }

    public virtual void Pressed(SKPoint point)
    {
        PressedHandler?.Invoke(this, new InteractionEventArgs(point));
    }

    public virtual void Released(SKPoint point)
    {
        ReleasedHandler?.Invoke(this, new InteractionEventArgs(point));
    }

    public void RemoveDrawable(MaterialDrawable drawable)
    {
        drawable.InvalidationHandler -= OnDrawableInvalidate;
        drawable.Parent = null;
        mViewDrawable.Remove(drawable);
    }

    protected static void OnVisualPropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var view = (MaterialView)bindable;
        InvalidateSurface(view.mCanvasView);
    }

    private void OnDrawableInvalidate(object? sender, EventArgs args)
    {
        InvalidateSurface(mCanvasView);
    }

    public void InvalidateView()
    {
        InvalidateSurface(mCanvasView);
    }

    private static void InvalidateSurface(ISKCanvasView canvas)
    {
        canvas.InvalidateSurface();
    }
}