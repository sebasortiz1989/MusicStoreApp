using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels;
using MusicStoreApp.ViewModels.Controlador;
using MusicStoreApp.ViewModels.Embarcado;
using MusicStoreApp.ViewModels.Veiculo;
using MusicStoreApp.Views.Controlador;
using MusicStoreApp.Views.Veiculo;
using ReactiveUI;

namespace MusicStoreApp.Views;

public partial class MainWindow : ReactiveWindow<MainWindowViewModel>
{
    public MainWindow()
    {
        InitializeComponent();
        this.WhenActivated(action =>
        {
            action(ViewModel!.ShowDialog.RegisterHandler(DoShowDialogAsync));
            action(ViewModel!.ShowTest.RegisterHandler(DoShowTestAsync));
            action(ViewModel!.ShowTest2.RegisterHandler(DoShowTest2Async));
            action(ViewModel!.ShowTelaConfiguracao.RegisterHandler(DoShowTelaConfiguracao));
        });
    }

    private async Task DoShowDialogAsync(InteractionContext<MusicStoreViewModel, 
        AlbumViewModel?> interaction)
    {
        var dialog = new MusicStoreWindow();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<AlbumViewModel?>(this);
        interaction.SetOutput(result);
    }

    private async Task DoShowTestAsync(InteractionContext<ModeloApresentacaoConfiguracaoSensorProfundidade, int> interaction)
    {
        var dialog = new Embarcado.TelaConfiguracaoSensorProfundidade();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<int>(this);
        interaction.SetOutput(result);
    }
    
    private async Task DoShowTest2Async(InteractionContext<ControladorTestViewModel, int> interaction)
    {
        var dialog = new ControladorTesteView();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<int>(this);
        interaction.SetOutput(result);
    }    
    
    private async Task DoShowTelaConfiguracao(InteractionContext<ModeloApresentacaoConfiguracaoVeiculoGuia, int> interaction)
    {
        var dialog = new TelaConfiguracaoPrincipal();
        dialog.DataContext = interaction.Input;

        var result = await dialog.ShowDialog<int>(this);
        interaction.SetOutput(result);
    }
}