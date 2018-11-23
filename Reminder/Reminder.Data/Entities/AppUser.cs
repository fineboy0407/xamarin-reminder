using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Reminder.Data.Core;

namespace Reminder.Data.Entities
{
    public class AppUser : IdentityUser, IEntity<string>
    {
        public AppUser()
        {
            Notes = new List<Note>();
            Achievements = new List<AchievementModel>();
            Birthdays = new List<BirthdayModel>();
            ToDoModels = new List<ToDoModel>();
        }

        public string ImageContent { get; set; }

        public ICollection<Note> Notes { get; set; }
        public ICollection<AchievementModel> Achievements { get; set; }
        public ICollection<BirthdayModel> Birthdays { get; set; }
        public ICollection<ToDoModel> ToDoModels { get; set; }
    }
}