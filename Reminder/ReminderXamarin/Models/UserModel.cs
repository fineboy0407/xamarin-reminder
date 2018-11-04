using System.Collections.Generic;
using ReminderXamarin.Helpers;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace ReminderXamarin.Models
{
    [Table(ConstantsHelper.Users)]
    public class UserModel
    {
        [PrimaryKey]
        public string Id { get; set; }
        public string UserName { get; set; }
        public byte[] Password { get; set; }
        public byte[] ImageContent { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<Note> Notes { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<AchievementModel> Achievements { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<BirthdayModel> Birthdays { get; set; }

        [OneToMany(CascadeOperations = CascadeOperation.All)]
        public List<ToDoModel> ToDoModels { get; set; }
    }
}