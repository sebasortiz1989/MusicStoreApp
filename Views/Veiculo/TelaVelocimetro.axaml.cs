using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels.Veiculo;

namespace MusicStoreApp.Views.Veiculo;

public partial class TelaVelocimetro : ReactiveWindow<ModeloApresentacaoConfiguracaoVeiculoGuia>
{
    public TelaVelocimetro()
    {
        InitializeComponent();
    }
}