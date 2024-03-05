using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
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