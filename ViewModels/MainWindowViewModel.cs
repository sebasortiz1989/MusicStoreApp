using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using MusicStoreApp.Models;
using MusicStoreApp.ViewModels.Controlador;
using MusicStoreApp.ViewModels.Embarcado;
using MusicStoreApp.ViewModels.Veiculo;
using MusicStoreApp.Views.Controlador;
using ReactiveUI;

namespace MusicStoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand BuyMusicCommand { get; }

    public ICommand OpenTestWindow { get; }

    public ICommand OpenTestWindow2 { get; }

    public ICommand OpenConfiguracaoWindow { get; }

    public ICommand OpenVelocimetroWindow { get; }

    public MainWindowViewModel()
    {
        ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();
        ShowTest = new Interaction<ModeloApresentacaoConfiguracaoSensorProfundidade, int>();
        ShowTest2 = new Interaction<ControladorTestViewModel, int>();
        ShowTelaConfiguracao = new Interaction<ModeloApresentacaoConfiguracaoVeiculoGuia, int>();
        ShowTelaVelocimetro = new Interaction<ModeloApresentacaoVelocimetro, int>();

        BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var store = new MusicStoreViewModel();
            var result = await ShowDialog.Handle(store);
            if (result != null)
            {
                Albums.Add(result);
                await result.SaveToDiskAsync();
            }
        });

        OpenTestWindow = ReactiveCommand.CreateFromTask(async () =>
        {
            var test = new ModeloApresentacaoConfiguracaoSensorProfundidade();
            var result = await ShowTest.Handle(test);
        });

        OpenTestWindow2 = ReactiveCommand.CreateFromTask(async () =>
        {
            var test = new ControladorTestViewModel();
            var result = await ShowTest2.Handle(test);
        });

        OpenConfiguracaoWindow = ReactiveCommand.CreateFromTask(async () =>
        {
            var test = new ModeloApresentacaoConfiguracaoVeiculoGuia();
            var result = await ShowTelaConfiguracao.Handle(test);
        });

        OpenVelocimetroWindow = ReactiveCommand.CreateFromTask(async () =>
        {
            var test = new ModeloApresentacaoVelocimetro();
            var result = await ShowTelaVelocimetro.Handle(test);
        });

        RxApp.MainThreadScheduler.Schedule(LoadAlbums);
    }

    public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }

    public Interaction<ModeloApresentacaoConfiguracaoSensorProfundidade, int> ShowTest { get; }

    public Interaction<ControladorTestViewModel, int> ShowTest2 { get; }

    public Interaction<ModeloApresentacaoConfiguracaoVeiculoGuia, int> ShowTelaConfiguracao { get; }

    public Interaction<ModeloApresentacaoVelocimetro, int> ShowTelaVelocimetro { get; }

    public ObservableCollection<AlbumViewModel> Albums { get; } = new();

    private async void LoadAlbums()
    {
        var albums = (await Album.LoadCachedAsync()).Select(x => new AlbumViewModel(x));

        foreach (var album in albums)
        {
            Albums.Add(album);
        }

        foreach (var album in Albums.ToList())
        {
            await album.LoadCover();
        }
    }
}