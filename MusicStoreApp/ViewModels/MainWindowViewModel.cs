using System.Reactive.Linq;
using System.Windows.Input;
using ReactiveUI;

namespace MusicStoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand BuyMusicCommand { get; }

    public MainWindowViewModel()
    {
        ShowDialog = new Interaction<MusicStoreViewModel, AlbumViewModel?>();

        BuyMusicCommand = ReactiveCommand.CreateFromTask(async () =>
        {
            var store = new MusicStoreViewModel();

            var result = await ShowDialog.Handle(store);
        });
    }
    
    public Interaction<MusicStoreViewModel, AlbumViewModel?> ShowDialog { get; }
}