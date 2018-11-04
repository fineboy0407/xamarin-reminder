namespace ReminderXamarin.ViewModels
{
    public class PhotoViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string ResizedPath { get; set; }
        public string Thumbnail { get; set; }
        public bool Landscape { get; set; }
        public int NoteId { get; set; }
    }
}