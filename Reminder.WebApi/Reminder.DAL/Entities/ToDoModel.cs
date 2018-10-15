using System;

namespace Reminder.DAL.Entities
{
    public class ToDoModel : Entity
    {
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime WhenHappens { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}