using Avalonia;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Interactivity;
using Avalonia.Markup.Xaml;
using Avalonia.Media;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels;

namespace MusicStoreApp.Views;

public partial class TelaTrcControle : ReactiveWindow<TelaTrcControleViewModel>
{
    public TelaTrcControle()
    {
        InitializeComponent();
    }
}