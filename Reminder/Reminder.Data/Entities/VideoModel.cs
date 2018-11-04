namespace Reminder.Data.Entities
{
    public class VideoModel : Entity
    {
        public string Path { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}