using System;
using System.Collections.Generic;

namespace Reminder.WebApi.Models.Entities
{
    public class Note : Entity
    {
        public Note()
        {
            Photos = new List<PhotoModel>();
            Videos = new List<VideoModel>();
        }

        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public string UserId { get; set; }

        public List<PhotoModel> Photos { get; set; }

        public List<VideoModel> Videos { get; set; }
    }
}