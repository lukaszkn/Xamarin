using System.ComponentModel;
using Xamarin.Forms;
using GraphQLPlayground.ViewModels;

namespace GraphQLPlayground.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}
