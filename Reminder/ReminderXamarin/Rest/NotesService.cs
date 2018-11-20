using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using ReminderXamarin.Helpers;
using ReminderXamarin.Rest.Models;

namespace ReminderXamarin.Rest
{
    public class NotesService : INotesService
    {
        private readonly HttpClient _httpClient;
        private readonly string BaseUrl = "http://10.132.34.144:8300//api/notes";

        public NotesService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<IEnumerable<NoteModel>> GetAllNotes()
        {
            var token = Settings.AccessToken;
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer " + token);
            var response = await _httpClient.GetAsync(BaseUrl);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                return JsonConvert.DeserializeObject<IEnumerable<NoteModel>>(await response.Content.ReadAsStringAsync());
            }
            return null;
        }
    }
}