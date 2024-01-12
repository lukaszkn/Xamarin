using Cirrious.FluentLayouts.Touch;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace iOSMvvmCross.Views.Cells;

public class PhotoViewCell : MvxCollectionViewCell
{
    private static NSString classId = new NSString("PhotoViewCell");
    public static NSString ClassId { get { return classId; } }

    private string _thumbnailUrl;
    private UIImageView _imageView;

    public PhotoViewCell(IntPtr handle) : base(handle)
	{
        BackgroundColor = UIColor.Blue;

        _imageView = new UIImageView();

        this.AddSubview(_imageView);

        this.AddConstraints(
             _imageView.AtLeftOf(this),
             _imageView.AtTopOf(this),
             _imageView.AtBottomOf(this),
             _imageView.AtRightOf(this)
         );
        this.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
    }

    public string ThumbnailUrl
    {
        get { return _thumbnailUrl; }
        set
        {
            _thumbnailUrl = value;

            // this is very naive image loading but it will do for this example
            new Task(async () =>
            {
                var image = await LoadImage(_thumbnailUrl);
                if (image != null)
                {
                    InvokeOnMainThread(() =>
                    {
                        _imageView.Image = image;
                    });
                }
            }).Start();

        }
    }

    private async Task<UIImage> LoadImage(string imageUrl)
    {
        var httpClient = new HttpClient();

        Task<byte[]> contentsTask = httpClient.GetByteArrayAsync(imageUrl);

        // await! control returns to the caller and the task continues to run on another thread
        var contents = await contentsTask;

        // load from bytes
        return UIImage.LoadFromData(NSData.FromArray(contents));
    }
}
