using System.Collections.Generic;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Reminder.DAL.Entities
{
    public class AppUser : IdentityUser
    {
        public AppUser()
        {
            Notes = new List<Note>();
            Achievements = new List<AchievementModel>();
            Birthdays = new List<BirthdayModel>();
            ToDoModels = new List<ToDoModel>();
        }

        public byte[] ImageContent { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<AchievementModel> Achievements { get; set; }
        public ICollection<BirthdayModel> Birthdays { get; set; }
        public ICollection<ToDoModel> ToDoModels { get; set; }
    }
}