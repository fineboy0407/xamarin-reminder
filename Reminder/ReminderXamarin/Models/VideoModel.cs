using ReminderXamarin.Helpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ReminderXamarin.Models
{
    /// <summary>
    /// Store filepath to videos.
    /// </summary>
    [Table(ConstantsHelper.Videos)]
    public class VideoModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Path { get; set; }

        [ForeignKey(typeof(Note))]
        public int NoteId { get; set; }
    }
}