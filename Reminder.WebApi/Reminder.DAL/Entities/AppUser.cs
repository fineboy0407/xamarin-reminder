using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Reminder.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public byte[] ImageContent { get; set; }

        public List<Note> Notes { get; set; }
        public List<AchievementModel> Achievements { get; set; }
        public List<BirthdayModel> Birthdays { get; set; }
        public List<ToDoModel> ToDoModels { get; set; }
    }
}