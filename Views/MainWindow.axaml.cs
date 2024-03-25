using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.ReactiveUI;
using MusicStoreApp.ViewModels;
using MusicStoreApp.ViewModels.Embarcado;
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
}