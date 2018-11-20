using Newtonsoft.Json;

namespace ReminderXamarin.Rest.Models
{
    public class VideoModel
    {
        [JsonProperty]
        public byte[] Content { get; set; }

        [JsonProperty]
        public int NoteId { get; set; }
    }
}