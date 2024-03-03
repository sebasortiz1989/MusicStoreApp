using System.IO;
using System.Threading.Tasks;
using Avalonia.Media.Imaging;
using MusicStoreApp.Models;
using ReactiveUI;

namespace MusicStoreApp.ViewModels;

public class AlbumViewModel : ViewModelBase
{
    private readonly Album _album;
    private Bitmap? _cover;

    public AlbumViewModel(Album album)
    {
        _album = album;
    }

    public string Artist => _album.Artist;

    public string Title => _album.Title;

    public Bitmap? Cover
    {
        get => _cover;
        private set => this.RaiseAndSetIfChanged(ref _cover, value);
    }

    public async Task LoadCover()
    {
        var imageStream = await _album.LoadCoverBitmapAsync();
        StreamReader sr = new StreamReader(imageStream);
        
        if (imageStream is { CanRead: true, CanWrite: true })
        {
            Cover = await Task.Run(() => Bitmap.DecodeToWidth(sr.BaseStream, 400));
        }
    }
}