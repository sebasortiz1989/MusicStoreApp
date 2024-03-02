using System.Windows.Input;
using ReactiveUI;

namespace MusicStoreApp.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    public ICommand BuyMusicCommand { get; }

    public MainWindowViewModel()
    {
        BuyMusicCommand = ReactiveCommand.Create(() =>
        {
            // Code here will be executed when the button is clicked.
        });
    }
}