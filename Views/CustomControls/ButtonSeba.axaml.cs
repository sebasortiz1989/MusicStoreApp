using Avalonia;
using Avalonia.Controls;
using Avalonia.Media;

namespace MusicStoreApp.Views.CustomControls;

public class ButtonSeba : Button
{
    public static readonly DirectProperty<ButtonSeba, string> TextProperty =
        AvaloniaProperty.RegisterDirect<ButtonSeba, string>(
            nameof(Text),
            o => o.Text,
            (o, v) => o.Text = v);

    public static readonly DirectProperty<ButtonSeba, double> TextSizeProperty =
        AvaloniaProperty.RegisterDirect<ButtonSeba, double>(
            nameof(TextSize),
            o => o.TextSize,
            (o, v) => o.TextSize = v);

    public static readonly DirectProperty<ButtonSeba, bool> IsTextVisibleProperty =
        AvaloniaProperty.RegisterDirect<ButtonSeba, bool>(
            nameof(IsTextVisible),
            o => o.IsTextVisible,
            (o, v) => o.IsTextVisible = v);

    public static readonly DirectProperty<ButtonSeba, Geometry> GeometryProperty =
        AvaloniaProperty.RegisterDirect<ButtonSeba, Geometry>(
            nameof(Geometry),
            o => o.Geometry,
            (o, v) => o.Geometry = v);

    private string _text = string.Empty;
    private double _textSize;
    private bool _isTextVisible = true;
    private Geometry _geometry = new PathGeometry();

    public ButtonSeba()
    {
        Text = "New Button";
        TextSize = 11;
        Background = new SolidColorBrush(new Color(byte.MaxValue, 217, 217, 217));
        Margin = new Thickness(0);
        BorderBrush = new SolidColorBrush(new Color(byte.MaxValue, 0, 0, 0));
        CornerRadius = new CornerRadius(8);
        Geometry = new RectangleGeometry(new Rect(0, 0, 10, 10));
    }

    public string Text
    {
        get => _text;
        set => SetAndRaise(TextProperty, ref _text, value);
    }

    public double TextSize
    {
        get => _textSize;
        set => SetAndRaise(TextSizeProperty, ref _textSize, value);
    }
    
    public bool IsTextVisible
    {
        get => _isTextVisible;
        set => SetAndRaise(IsTextVisibleProperty, ref _isTextVisible, value);
    }

    public Geometry Geometry
    {
        get => _geometry;
        set => SetAndRaise(GeometryProperty, ref _geometry, value);
    } 
}