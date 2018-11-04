using System;

namespace Reminder.Data.Entities
{
    public class AchievementNote : Entity
    {
        public string Description { get; set; }
        public int HoursSpent { get; set; }
        public DateTime Date { get; set; }

        public int AchievementId { get; set; }
        public AchievementModel Achievement { get; set; }
    }
}