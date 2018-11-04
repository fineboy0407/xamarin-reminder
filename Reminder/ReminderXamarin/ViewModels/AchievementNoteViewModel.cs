using System;

namespace ReminderXamarin.ViewModels
{
    public class AchievementNoteViewModel : BaseViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int HoursSpent { get; set; }
        public DateTime Date { get; set; }
        public int AchievementId { get; set; }
    }
}