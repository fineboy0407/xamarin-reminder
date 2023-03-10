using System;
using Reminder.Data.Core;

namespace Reminder.Data.Entities
{
    public class BirthdayModel : Entity
    {
        public string ImageContent { get; set; }
        public string Name { get; set; }
        public DateTime BirthDayDate { get; set; }
        public string GiftDescription { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
    }
}