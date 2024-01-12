using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Cirrious.FluentLayouts.Touch;
using Foundation;
using MvvmCross.Platforms.Ios.Presenters.Attributes;
using Core.ViewModels.Main;
using UIKit;
using MvvmCross.Platforms.Ios.Views;
using iOSMvvmCross.Sources;
using Microsoft.VisualBasic;
using MvvmCross.Binding.BindingContext;

namespace iOS.Views.Main;

[MvxRootPresentation(WrapInNavigationController = true)]
public class AlbumsViewController : BaseViewController<AlbumsViewModel>
{
    private MvxUIRefreshControl _refreshControl;
    private UITableView _tableView;
    private AlbumsTableViewSource _source;

    protected override void CreateView()
    {
        Title = "Albums";

        _refreshControl = new MvxUIRefreshControl();

        _tableView = new UITableView();
        _tableView.BackgroundColor = UIColor.Clear;
        _tableView.RowHeight = UITableView.AutomaticDimension;
        _tableView.EstimatedRowHeight = 44f;
        _tableView.AddSubview(_refreshControl);

        _source = new AlbumsTableViewSource(_tableView);
        _tableView.Source = _source;

        View.AddSubviews(_tableView);
        View.SubviewsDoNotTranslateAutoresizingMaskIntoConstraints();
    }

    protected override void LayoutView()
    {
        View.AddConstraints(
             _tableView.AtLeftOf(View),
             _tableView.AtTopOf(View),
             _tableView.AtBottomOf(View),
             _tableView.AtRightOf(View)
         );

        View.BringSubviewToFront(_tableView);
    }

    protected override void BindView()
    {
        var set = this.CreateBindingSet<AlbumsViewController, AlbumsViewModel>();
        set.Bind(this).For("NetworkIndicator").To(vm => vm.FetchAlbumsTask.IsNotCompleted).WithFallback(false);
        set.Bind(_refreshControl).For(r => r.IsRefreshing).To(vm => vm.LoadAlbumsTask.IsNotCompleted).WithFallback(false);
        set.Bind(_refreshControl).For(r => r.RefreshCommand).To(vm => vm.RefreshAlbumsCommand);


        set.Bind(_source).For(v => v.ItemsSource).To(vm => vm.Albums);
        set.Bind(_source).For(v => v.SelectionChangedCommand).To(vm => vm.AlbumSelectedCommand);
        set.Bind(_source).For(v => v.FetchCommand).To(vm => vm.FetchAlbumsCommand);

        set.Apply();
    }
}
