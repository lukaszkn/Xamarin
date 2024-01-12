using iOSMvvmCross.Views.Cells;
using MvvmCross.Binding.Extensions;
using System.Windows.Input;
using MvvmCross.Platforms.Ios.Binding.Views;

namespace iOSMvvmCross.Sources;

public class AlbumsTableViewSource : MvxSimpleTableViewSource
{
    public ICommand FetchCommand { get; set; }

    public AlbumsTableViewSource(UITableView tableView) : base(tableView, typeof(NameTableViewCell))
    {
        DeselectAutomatically = true;
    }

    protected override UITableViewCell GetOrCreateCellFor(UITableView tableView, Foundation.NSIndexPath indexPath, object item)
    {
        var cell = base.GetOrCreateCellFor(tableView, indexPath, item);

        if (indexPath.Item == ItemsSource.Count())
            FetchCommand?.Execute(null);

        return cell;
    }
}

