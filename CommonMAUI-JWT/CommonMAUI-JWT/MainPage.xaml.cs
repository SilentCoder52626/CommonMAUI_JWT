using CommonMAUI_JWT.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace CommonMAUI_JWT
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        private readonly IApiService _apiservice;
        public MainPage( IApiService apiservice)
        {
            InitializeComponent();
            _apiservice = apiservice;
        }

        private async void OnCounterClicked(object sender, EventArgs e)
        {
            count++;
            //For test
            await _apiservice.GetAccessToken();
            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }

}
