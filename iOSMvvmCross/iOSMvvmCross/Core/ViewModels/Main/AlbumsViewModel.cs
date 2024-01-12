using System;
using System.Collections.Generic;
using System.Text;
using Core.Models;
using Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace Core.ViewModels.Main;

public class AlbumsViewModel : BaseViewModel
{
    private readonly IAlbumService _albumService;
    private readonly IMvxNavigationService _navigationService;

    public AlbumsViewModel(IAlbumService albumService, IMvxNavigationService navigationService)
    {
        _albumService = albumService;
        _navigationService = navigationService;

        Albums = new MvxObservableCollection<Album>();

        AlbumSelectedCommand = new MvxAsyncCommand<Album>(AlbumSelected);
        FetchAlbumsCommand = new MvxCommand(() =>
        {
            FetchAlbumsTask = MvxNotifyTask.Create(LoadAlbums);
            RaisePropertyChanged(() => FetchAlbumsTask);
        });

        RefreshAlbumsCommand = new MvxCommand(RefreshAlbums);
    }

    // MvvmCross Lifecycle
    public override Task Initialize()
    {
        LoadAlbumsTask = MvxNotifyTask.Create(LoadAlbums);

        return base.Initialize();
    }

    // MVVM Properties
    public MvxNotifyTask LoadAlbumsTask { get; private set; }

    public MvxNotifyTask FetchAlbumsTask { get; private set; }

    private MvxObservableCollection<Album> _albums;
    public MvxObservableCollection<Album> Albums
    {
        get
        {
            return _albums;
        }
        set
        {
            _albums = value;
            RaisePropertyChanged(() => Albums);
        }
    }

    // MVVM Commands
    public IMvxCommand<Album> AlbumSelectedCommand { get; private set; }

    public IMvxCommand FetchAlbumsCommand { get; private set; }

    public IMvxCommand RefreshAlbumsCommand { get; private set; }

    private async Task LoadAlbums()
    {
        var result = await _albumService.GetAlbumsAsync();

        Albums.Clear();
        Albums.AddRange(result);
    }

    private async Task AlbumSelected(Album selectedAlbum)
    {
        _ = await _navigationService.Navigate<PhotosViewModel, AlbumDetailParameters>(new AlbumDetailParameters(selectedAlbum));
    }

    private void RefreshAlbums()
    {
        LoadAlbumsTask = MvxNotifyTask.Create(LoadAlbums);
        RaisePropertyChanged(() => LoadAlbumsTask);
    }
}
