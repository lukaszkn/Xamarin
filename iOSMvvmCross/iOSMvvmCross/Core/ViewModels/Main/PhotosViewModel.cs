using Core.Models;
using Core.Services;
using Core.ViewModels;
using MvvmCross.ViewModels;

namespace Core.ViewModels.Main;

public record AlbumDetailParameters(Album album);

public class PhotosViewModel : BaseViewModel<AlbumDetailParameters>
{
    private readonly IAlbumService _albumService;

    public PhotosViewModel(IAlbumService albumService)
	{
        _albumService = albumService;

        Photos = new MvxObservableCollection<Photo>();
    }

    public override void Prepare(AlbumDetailParameters parameter)
    {
        Album = parameter.album;
    }

    public override Task Initialize()
    {
        LoadPhotosTask = MvxNotifyTask.Create(LoadPhotos);

        return base.Initialize();
    }

    // MVVM Properties
    public MvxNotifyTask LoadPhotosTask { get; private set; }

    private Album _album;
    public Album Album
    {
        get
        {
            return _album;
        }
        set
        {
            _album = value;
            RaisePropertyChanged(() => Album);
        }
    }

    private MvxObservableCollection<Photo> _photos;
    public MvxObservableCollection<Photo> Photos
    {
        get
        {
            return _photos;
        }
        set
        {
            _photos = value;
            RaisePropertyChanged(() => Photos);
        }
    }

    private async Task LoadPhotos()
    {
        var result = await _albumService.GetPhotosAsync();

        Photos = new MvxObservableCollection<Photo>(result.Where(photo => photo.AlbumId == Album.Id));
        //Photos.Clear();
        //Photos.AddRange(result);
    }
}

