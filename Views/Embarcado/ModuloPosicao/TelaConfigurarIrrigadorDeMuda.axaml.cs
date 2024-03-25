using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels.Embarcado.ModuloPosicao;

namespace MusicStoreApp.Views.Embarcado.ModuloPosicao;

public partial class TelaConfigurarIrrigadorDeMuda : ReactiveWindow<ModeloApresentacaoConfigurarIrrigadorDeMuda>
{
    public TelaConfigurarIrrigadorDeMuda()
    {
        InitializeComponent();
    }
}