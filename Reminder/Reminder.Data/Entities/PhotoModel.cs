using Reminder.Data.Core;

namespace Reminder.Data.Entities
{
    public class PhotoModel : Entity
    {
        public string Name { get; set; }
        public string Image { get; set; }

        public int NoteId { get; set; }
        public Note Note { get; set; }
    }
}