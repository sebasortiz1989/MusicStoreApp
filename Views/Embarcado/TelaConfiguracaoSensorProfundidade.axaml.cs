using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels.Embarcado;

namespace MusicStoreApp.Views.Embarcado;

public partial class TelaConfiguracaoSensorProfundidade : ReactiveWindow<ModeloApresentacaoConfiguracaoSensorProfundidade>
{
    public TelaConfiguracaoSensorProfundidade()
    {
        InitializeComponent();
    }
}