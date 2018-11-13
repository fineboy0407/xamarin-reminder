namespace Reminder.Data.Entities
{
    public class PhotoModel : Entity
    {
        public string Name { get; set; }
        public byte[] Image { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}