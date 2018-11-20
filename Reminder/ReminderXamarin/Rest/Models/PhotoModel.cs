using Newtonsoft.Json;

namespace ReminderXamarin.Rest.Models
{
    public class PhotoModel
    {
        [JsonProperty]
        public string Name { get; set; }

        [JsonProperty]
        public byte[] Image { get; set; }

        [JsonProperty]
        public int NoteId { get; set; }
    }
}