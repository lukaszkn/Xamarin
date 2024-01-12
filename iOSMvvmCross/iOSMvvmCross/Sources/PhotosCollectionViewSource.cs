using System;
using MvvmCross.Platforms.Ios.Binding.Views;
using UIKit;
using iOSMvvmCross.Views.Cells;
using MvvmCross.Binding.Extensions;
using System.Windows.Input;
using Core.Models;

public class PhotosCollectionViewSource : MvxCollectionViewSource
{
	public PhotosCollectionViewSource(UICollectionView collectionView)
		: base(collectionView )
	{
	}

    [Export("collectionView:numberOfItemsInSection:")]
    public nint GetItemsCount(UICollectionView collectionView, nint section)
    {
        return ItemsSource.Count();
    }

    public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
    {
        var photoCell = (PhotoViewCell)collectionView.DequeueReusableCell(PhotoViewCell.ClassId, indexPath);

        photoCell.ThumbnailUrl = ((Photo)ItemsSource.ElementAt(indexPath.Row)).ThumbnailUrl;

        return photoCell;
    }

}


