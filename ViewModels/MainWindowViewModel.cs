using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Concurrency;
using System.Reactive.Linq;
using System.Windows.Input;
using MusicStoreApp.Models;
using ReactiveUI;

namespace MusicStoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand BuyMusicCommand { get; }

    public ICommand OpenTestWindow { get; }

    public MainWindowViewModel()
    {
        ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();
        ShowTest = new Interaction<TelaTrcControleViewModel, int>();

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
            var test = new TelaTrcControleViewModel();
            var result = await ShowTest.Handle(test);
        });


        RxApp.MainThreadScheduler.Schedule(LoadAlbums);
    }
    
    public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }

    public Interaction<TelaTrcControleViewModel, int> ShowTest { get; }

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