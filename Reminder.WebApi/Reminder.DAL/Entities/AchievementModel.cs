using System.Collections.Generic;

namespace Reminder.DAL.Entities
{
    public class AchievementModel : Entity
    {
        public byte[] ImageContent { get; set; }
        public string Title { get; set; }
        public string GeneralDescription { get; set; }
        public int GeneralTimeSpent { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public List<AchievementNote> AchievementNotes { get; set; }
    }
}