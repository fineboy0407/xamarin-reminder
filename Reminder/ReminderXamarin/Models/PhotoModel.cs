using ReminderXamarin.Helpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ReminderXamarin.Models
{
    /// <summary>
    /// Store filepath to pictures.
    /// </summary>
    [Table(ConstantsHelper.Photos)]
    public class PhotoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string ResizedPath { get; set; }
        public string Thumbnail { get; set; }
        public bool Landscape { get; set; }

        [ForeignKey(typeof(Note))]
        public int NoteId { get; set; }
    }
}