using Newtonsoft.Json;

namespace ReminderXamarin.Rest
{
    public class LoginModel
    {
        [JsonProperty("grant_type")]
        public string GrantType { get; set; } = "password";

        [JsonProperty("username")]
        public string UserName { get; set; }

        [JsonProperty("password")]
        public string Password { get; set; }
    }
}