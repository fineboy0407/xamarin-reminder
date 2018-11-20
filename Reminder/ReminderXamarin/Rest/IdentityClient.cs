using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReminderXamarin.Interfaces;
using Xamarin.Forms;

namespace ReminderXamarin.Rest
{
    public class IdentityClient : IIdentityClient
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "http://10.132.34.144:8300/Token";

        public IdentityClient()
        {
            _httpClient = new HttpClient();
        }

        public async Task<TokenResponse> GetToken(LoginModel model)
        {
            try
            {
                var parameters = new Dictionary<string, string>
                {
                    { "grant_type", "password" },
                    { "username", model.UserName },
                    { "password", model.Password }
                };

                var data = new FormUrlEncodedContent(parameters);
                var response = await _httpClient.PostAsync(BaseUrl, data);

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    return JsonConvert.DeserializeObject<TokenResponse>(await response.Content.ReadAsStringAsync());
                }
                var alertService = DependencyService.Get<IAlertService>();
                alertService.ShowOkAlert("Error during response", "Ok");
                return new TokenResponse();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" --- Note creation error: " + ex);
            }
            return new TokenResponse();
        }
    }
}