using LocalXamarin.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace LocalXamarin.Views
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