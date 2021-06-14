using LocalXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LocalXamarin.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ForecastsPage : ContentPage
    {
        private readonly ForecastsViewModel _viewModel;

        public ForecastsPage()
        {
            InitializeComponent();

            BindingContext = _viewModel = new ForecastsViewModel();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}