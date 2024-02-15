using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GraphQLPlayground.Services;
using GraphQLPlayground.Views;

namespace GraphQLPlayground
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();

            DependencyService.Register<MockDataStore>();
            DependencyService.Register<SpaceXService>();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}

