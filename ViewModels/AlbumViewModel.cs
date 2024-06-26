﻿using Avalonia.Media.Imaging;
using MusicStoreApp.Models;
using ReactiveUI;
using System.Threading.Tasks;

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
        // var imageStream = await _album.LoadCoverBitmapAsync();
        // StreamReader sr = new StreamReader(imageStream);
        //
        // if (imageStream is { CanRead: true, CanWrite: true })
        // {
        //     Cover = await Task.Run(() => Bitmap.DecodeToWidth(sr.BaseStream, 400));
        // }
        await using (var imageStream = await _album.LoadCoverBitmapAsync())
        {
            Cover = await Task.Run(() => Bitmap.DecodeToWidth(imageStream, 400));
        }
    }

    public async Task SaveToDiskAsync()
    {
        await _album.SaveAsync();

        if (Cover != null)
        {
            var bitmap = Cover;

            await Task.Run(() =>
            {
                using (var fs = _album.SaveCoverBitmapStream())
                {
                    bitmap.Save(fs);
                }
            });
        }
    }
}