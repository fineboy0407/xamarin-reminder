using System;

namespace Reminder.WebApi.Models.Entities
{
    public class ToDoModel : Entity
    {
        public string Priority { get; set; }
        public string Description { get; set; }
        public DateTime WhenHappens { get; set; }

        public string UserId { get; set; }
    }
}