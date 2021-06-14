using LocalXamarin.Models;
using Newtonsoft.Json;
using System;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace LocalXamarin.ViewModels
{
    public class ForecastsViewModel : BaseViewModel
    {
        public ObservableCollection<WeatherForecast> Items { get; set; }
        public Command LoadItemsCommand { get; }

        public ForecastsViewModel()
        {
            Title = "ForecastsPage";
            Items = new ObservableCollection<WeatherForecast>();
            LoadItemsCommand = new Command(async () => await ExecuteLoadItemsCommand());
        }

        private async Task ExecuteLoadItemsCommand()
        {
            IsBusy = true;
            try
            {
                Items.Clear();
                WeatherForecast[] items = await GetForecasts();

                foreach (WeatherForecast item in items)
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

        private async Task<WeatherForecast[]> GetForecasts()
        {
            // TODO: Replace by your own Port Address
            // TODO: Getting this to work will require an update in your appSettings. Reach out for more information or see:
            // https://stackoverflow.com/questions/31131658/xamarin-connect-to-locally-hosted-web-service

            var url = "https://10.0.2.2:44372/WeatherForecast";

            // WARNING: This is unsecured communication. Do NOT use this in production code!
            var handler = new HttpClientHandler();
            handler.ServerCertificateCustomValidationCallback
                += (sender, certificate, chain, errors) => true;

            using (var client = new HttpClient(handler))
            {
                try
                {
                    HttpResponseMessage message = await client.GetAsync(url);

                    if (message.IsSuccessStatusCode)
                    {
                        string json = await message.Content.ReadAsStringAsync();
                        WeatherForecast[] result = JsonConvert.DeserializeObject<WeatherForecast[]>(json);
                        return result;
                    }
                    else
                    {
                        return new[] { new WeatherForecast { Summary = "No data" } };
                    }
                }
                catch (Exception exception)
                {
                    Console.WriteLine(exception);
                    throw;
                }
            }
        }

        public void OnAppearing()
        {
            IsBusy = true;
        }
    }
}