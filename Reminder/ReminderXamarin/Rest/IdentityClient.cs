using System;
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
                var content = JsonConvert.SerializeObject(model);
                var data = new StringContent(content, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync("192.168.56.1:XXXX/Token", data);

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