using System.Collections.Generic;
using Reminder.Data.Core;

namespace Reminder.Data.Entities
{
    public class AchievementModel : Entity
    {
        public AchievementModel()
        {
            AchievementNotes = new List<AchievementNote>();
        }

        public string ImageContent { get; set; }
        public string Title { get; set; }
        public string GeneralDescription { get; set; }
        public int GeneralTimeSpent { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }

        public ICollection<AchievementNote> AchievementNotes { get; set; }
    }
}