using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

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

        // TODO: handle other codes (400,500)
        // TODO: deploy web api to local IIS
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
            }
            catch (Exception ex)
            {
                Debug.WriteLine(" --- Note creation error: " + ex);
            }
            return new TokenResponse();
        }
    }
}