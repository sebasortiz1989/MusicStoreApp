using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Data.Converters;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Media;

namespace MusicStoreApp.Views.CustomControls;

public class InformationFrame : TemplatedControl
{
    public static readonly DirectProperty<InformationFrame, string> TextoTituloProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, string>(
            nameof(TextoTitulo),
            o => o.TextoTitulo,
            (o, v) => o.TextoTitulo = v);

    public static readonly DirectProperty<InformationFrame, int> DadoProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, int>(
            nameof(Dado),
            o => o._dado,
            (o, v) => o._dado = v);

    public static readonly DirectProperty<InformationFrame, string> TextoUnidadeProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, string>(
            nameof(TextoUnidade),
            o => o._textoUnidade,
            (o, v) => o._textoUnidade = v);

    public static readonly DirectProperty<InformationFrame, string> SvgStringProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, string>(
            nameof(SvgString),
            o => o._svgString,
            (o, v) => o._svgString = v);

    public static readonly DirectProperty<InformationFrame, Geometry> SvgIconProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, Geometry>(
            nameof(SvgIcon),
            o => o._svgIcon,
            (o, v) => o._svgIcon = v);

    public static readonly DirectProperty<InformationFrame, bool> IsExpandedProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, bool>(
            nameof(IsExpanded),
            o => o._isExpanded,
            (o, v) => o._isExpanded = v);

    public static readonly DirectProperty<InformationFrame, bool> MostrarFrameUnidadeProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, bool>(
            nameof(MostrarFrameUnidade),
            o => o._mostrarFrameUnidade,
            (o, v) => o._mostrarFrameUnidade = v);

    public static readonly DirectProperty<InformationFrame, int> ColumnSpanDadoProperty =
        AvaloniaProperty.RegisterDirect<InformationFrame, int>(
            nameof(ColumnSpanDado),
            o => o._columnSpanDado,
            (o, v) => o._columnSpanDado = v);

    private string _textoTitulo = "Test1";

    private int _dado = 410;

    private string _textoUnidade;

    private string _svgString;

    private Geometry _svgIcon;

    private bool _isExpanded = true;

    private bool _mostrarFrameUnidade;

    private int _columnSpanDado = 2;

    public InformationFrame()
    {
        TextoUnidadeProperty.Changed.AddClassHandler<InformationFrame>((_, e) => OnTextoUnidadePropertyChanged(e));
        SvgStringProperty.Changed.AddClassHandler<InformationFrame>((_, e) => SvgStringPropertyChanged(e));
        Tapped += OnTapped;

        SvgString =
            "M7 12C7.55228 12 8 11.5523 8 11C8 10.4477 7.55228 10 7 10C6.44772 10 6 10.4477 6 11C6 11.5523 6.44772 12 7 12Z M11 11C11 11.5523 10.5523 12 10 12C9.44772 12 9 11.5523 9 11C9 10.4477 9.44772 10 10 10C10.5523 10 11 10.4477 11 11Z M13 12C13.5523 12 14 11.5523 14 11C14 10.4477 13.5523 10 13 10C12.4477 10 12 10.4477 12 11C12 11.5523 12.4477 12 13 12Z M3 5.5C3 4.11929 4.11929 3 5.5 3H14.5C15.8807 3 17 4.11929 17 5.5V14.5C17 15.8807 15.8807 17 14.5 17H5.5C4.11929 17 3 15.8807 3 14.5V5.5ZM5.5 4C4.67157 4 4 4.67157 4 5.5V14.5C4 15.3284 4.67157 16 5.5 16H14.5C15.3284 16 16 15.3284 16 14.5V7H9.5C8.67157 7 8 6.32843 8 5.5V4H5.5ZM16 5.5C16 4.67157 15.3284 4 14.5 4H9V5.5C9 5.77614 9.22386 6 9.5 6H16V5.5Z";
    }

    public string TextoTitulo
    {
        get => _textoTitulo;
        set => SetAndRaise(TextoTituloProperty, ref _textoTitulo, value);
    }

    public int Dado
    {
        get => _dado;
        set => SetAndRaise(DadoProperty, ref _dado, value);
    }

    public string TextoUnidade
    {
        get => _textoUnidade;
        set => SetAndRaise(TextoUnidadeProperty, ref _textoUnidade, value);
    }
   
    public string SvgString
    {
        get => _svgString;
        set => SetAndRaise(SvgStringProperty, ref _svgString, value);
    }

    public Geometry SvgIcon
    {
        get => _svgIcon;
        set => SetAndRaise(SvgIconProperty, ref _svgIcon, value);
    }

    public bool IsExpanded
    {
        get => _isExpanded;
        set => SetAndRaise(IsExpandedProperty, ref _isExpanded, value);
    }

    public bool MostrarFrameUnidade
    {
        get => _mostrarFrameUnidade;
        private set => SetAndRaise(MostrarFrameUnidadeProperty, ref _mostrarFrameUnidade, value);
    }

    public int ColumnSpanDado
    {
        get => _columnSpanDado;
        private set => SetAndRaise(ColumnSpanDadoProperty, ref _columnSpanDado, value);
    }

    private void OnTextoUnidadePropertyChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.NewValue is string newString)
        {
            if (newString == string.Empty)
            {
                MostrarFrameUnidade = false;
                ColumnSpanDado = 2;
            }
            else
            {
                MostrarFrameUnidade = true;
                ColumnSpanDado = 1;
            }
        }
    }

    private void SvgStringPropertyChanged(AvaloniaPropertyChangedEventArgs e)
    {
        if (e.NewValue is string newStringSvg)
        {
            SvgIcon = PathGeometry.Parse(newStringSvg);
        }
    }

    private void OnTapped(object? sender, TappedEventArgs e)
    {
        IsExpanded = !IsExpanded;
    }
}

public static class Converters
{
    public static FuncValueConverter<int?, string?> IntToStringConverter { get; } = new(num => num.ToString());
}