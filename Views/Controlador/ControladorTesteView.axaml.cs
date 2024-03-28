using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels.Controlador;
using MusicStoreApp.ViewModels.Embarcado;

namespace MusicStoreApp.Views.Controlador;

public partial class ControladorTesteView : ReactiveWindow<ControladorTestViewModel>
{
    public ControladorTesteView()
    {
        InitializeComponent();
    }
}