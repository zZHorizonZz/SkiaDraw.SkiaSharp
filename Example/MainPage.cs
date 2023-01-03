using CommunityToolkit.Maui.Markup;
using Maui.Material.You.Components.Image;
using Maui.Material.You.Components.Shape;
using Maui.Material.You.Components.View;

namespace Example;

public class MainPage : ContentPage
{
    public MainPage()
    {
        var shapes = new HorizontalStackLayout();
        for (var i = 0; i < Enum.GetValues<ShapeType>().Length; i++)
        {
            shapes.Add(new VerticalStackLayout()
            {
                new ShapeView
                {
                    ShapeType = (ShapeType)i,
                    BackgroundColor = Color.FromHex("#FF4081"),
                    BorderColor = Color.FromHex("#FF5081"),
                    BorderWidth = 5,
                    HeightRequest = 100,
                    WidthRequest = 100,
                    IsFilled = false,
                    CornerRadius = 10,
                    Margin = new Thickness(10)
                },
                new Label() { Text = ((ShapeType)i).ToString() }.TextCenter()
            });

            shapes.Add(new VerticalStackLayout()
            {
                new ShapeView
                {
                    ShapeType = (ShapeType)i,
                    BackgroundColor = Color.FromHex("#FF4081"),
                    BorderColor = Color.FromHex("#FF5081"),
                    BorderWidth = 5,
                    HeightRequest = 100,
                    WidthRequest = 100,
                    IsFilled = true,
                    CornerRadius = 10,
                    Margin = new Thickness(10)
                },
                new Label() { Text = (ShapeType)i + " Filled" }.TextCenter()
            });
        }

        var grid = new Grid()
        {
            RowDefinitions = GridRowsColumns.Rows.Define(GridLength.Star, GridLength.Star, GridLength.Star)
        };

        grid.Add(new ScrollView()
        {
            Orientation = ScrollOrientation.Horizontal,
            Content = shapes
        }.Row(0));

        grid.Add(new ImageView() { Source = "dotnet_bot.svg", WidthRequest = 256, HeightRequest = 256 }.Row(1));
        grid.Add(new VectorView()
            { Source = "favorite_border.svg", WidthRequest = 24, HeightRequest = 24 }.Row(2));

        Content = grid;
    }
}