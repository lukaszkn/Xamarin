using System;
using GraphQLPlayground.Models;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using GraphQLPlayground.Services;
using System.Collections.ObjectModel;

namespace GraphQLPlayground.ViewModels;

public class SpaceXLaunchesViewModel : BaseViewModel
{
    private ISpaceXService service => DependencyService.Get<ISpaceXService>();

    public ObservableCollection<SpaceXLaunch> Items { get; }

    public Command LoadItemsCommand { get; }

    public SpaceXLaunchesViewModel()
    {
        Title = "Space X launches";

        Items = new ObservableCollection<SpaceXLaunch>();

        LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
    }

    async Task ExecuteLoadItemsCommand()
    {
        IsBusy = true;

        try
        {
            Items.Clear();
            var items = await service.GetSpaceXLaunchesAsync();
            foreach (var item in items)
            {
                Items.Add(item);
            }
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex);
        }
        finally
        {
            IsBusy = false;
        }
    }

    public void OnAppearing()
    {
        IsBusy = true;
    }

}

