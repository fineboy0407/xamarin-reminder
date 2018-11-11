using Newtonsoft.Json;

namespace ReminderXamarin.Rest
{
    public class TokenResponse
    {
        [JsonProperty("access_token")]
        public string AccessToken { get; set; }
    }
}