namespace Reminder.DAL.Entities
{
    /// <summary>
    /// Store filepath to pictures.
    /// </summary>
    public class PhotoModel : Entity
    {
        public string ResizedPath { get; set; }
        public string Thumbnail { get; set; }
        public bool Landscape { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}