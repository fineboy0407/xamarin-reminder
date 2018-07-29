namespace Reminder.WebApi.Models.Entities
{
    public class PhotoModel : Entity
    {
        public string ResizedPath { get; set; }
        public string Thumbnail { get; set; }
        public bool Landscape { get; set; }

        public int NoteId { get; set; }
    }
}