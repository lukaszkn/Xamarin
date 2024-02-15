using System;
using System.Collections.Generic;

using Xamarin.Forms;
using GraphQLPlayground.ViewModels;

namespace GraphQLPlayground.Views;

public partial class SpaceXLaunchesPage : ContentPage
{
    SpaceXLaunchesViewModel viewModel;

    public SpaceXLaunchesPage()
    {
        InitializeComponent();

        BindingContext = viewModel = new SpaceXLaunchesViewModel();
    }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        viewModel.OnAppearing();
    }
}

