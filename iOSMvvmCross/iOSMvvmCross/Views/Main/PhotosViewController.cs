using System;
using Cirrious.FluentLayouts.Touch;
using Core.ViewModels.Main;
using iOS.Views;
using iOS.Views.Main;
using iOSMvvmCross.Sources;
using iOSMvvmCross.Views.Cells;
using MvvmCross.Binding.BindingContext;
using UIKit;

namespace iOSMvvmCross.Views.Main;

public class PhotosViewController : BaseViewController<PhotosViewModel>
{
    private UICollectionView _collectionView;
    private PhotosCollectionViewSource _source;

    protected override void CreateView()
    {
        Title = "Album photos";

        var layout = new UICollectionViewFlowLayout();
        layout.ItemSize = new CGSize(100, 100);

        _collectionView = new UICollectionView(CGRect.Empty, layout);
        _collectionView.RegisterClassForCell(typeof(PhotoViewCell), PhotoViewCell.ClassId);

        _source = new PhotosCollectionViewSource(_collectionView);
        _collectionView.Source = _source;

        View.AddSubview(_collectionView);
        View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
    }

    protected override void LayoutView()
    {
        View.AddConstraints(
             _collectionView.AtLeftOf(View),
             _collectionView.AtTopOf(View),
             _collectionView.AtBottomOf(View),
             _collectionView.AtRightOf(View)
         );

        View.BringSubviewToFront(_collectionView);
    }

    protected override void BindView()
    {
        var set = this.CreateBindingSet<PhotosViewController, PhotosViewModel>();

        set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Photos);

        set.Apply();
    }
}