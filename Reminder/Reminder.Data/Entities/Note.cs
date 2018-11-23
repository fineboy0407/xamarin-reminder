using System;
using System.Collections.Generic;
using Reminder.Data.Core;

namespace Reminder.Data.Entities
{
    /// <summary>
    /// Note can contains photo, video and short description.
    /// </summary>
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
        public AppUser User { get; set; }
        public ICollection<PhotoModel> Photos { get; set; }
        public ICollection<VideoModel> Videos { get; set; }
    }
}