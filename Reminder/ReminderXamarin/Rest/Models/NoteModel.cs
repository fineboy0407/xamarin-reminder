using System;
using Newtonsoft.Json;

namespace ReminderXamarin.Rest.Models
{
    public class NoteModel
    {
        [JsonProperty]
        public int Id { get; set; }

        [JsonProperty]
        public string Description { get; set; }

        [JsonProperty]
        public DateTime CreationDate { get; set; }

        [JsonProperty]
        public DateTime EditDate { get; set; }

        [JsonProperty]
        public string UserId { get; set; }

        [JsonProperty]
        public PhotoModel[] Photos { get; set; }

        [JsonProperty]
        public VideoModel[] Videos { get; set; }
    }
}