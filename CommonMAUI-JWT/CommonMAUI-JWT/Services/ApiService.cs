using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CommonMAUI_JWT.Services
{
    public interface IApiService
    {
        Task GetAccessToken();
    }
    public class ApiService : IApiService
    {
        private readonly HttpClient _client;

        public ApiService(IHttpClientFactory factory)
        {
            _client = factory.CreateClient("JWT_Client");
        }

        public async Task GetAccessToken()
        {
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var loginModel = new
            {
                Email = "admin@gmail.com",
                Password = "admin"
            };

            // Serialize the login model to JSON
            var jsonContent = new StringContent(JsonSerializer.Serialize(loginModel), Encoding.UTF8, "application/json");


            // Send the POST request
            HttpResponseMessage response = await _client.PostAsync("account/login", jsonContent);
            if (response.IsSuccessStatusCode)
            {
                // Read the response content as a string
                result = await response.Content.ReadAsStringAsync();

                await SecureStorage.SetAsync("Token", result);
            }
           
        }
    }
}
