using System;

namespace Reminder.WebApi.Models.Entities
{
    public class BirthdayModel : Entity
    {
        public byte[] ImageContent { get; set; }
        public string Name { get; set; }
        public DateTime BirthDayDate { get; set; }
        public string GiftDescription { get; set; }

        public string UserId { get; set; }
    }
}