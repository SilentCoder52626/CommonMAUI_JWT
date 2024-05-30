using CommonMAUI_JWT.Services;
using Microsoft.Extensions.Configuration;
using System.Net.Http.Headers;

namespace CommonMAUI_JWT
{
    public partial class MainPage : ContentPage
    {

        private readonly IApiService _apiservice;
        public MainPage( IApiService apiservice)
        {
            InitializeComponent();
            _apiservice = apiservice;
        }

    }

}
