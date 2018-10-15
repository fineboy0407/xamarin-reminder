﻿using System;
using System.Collections.Generic;

namespace Reminder.DAL.Entities
{
    public class Note : Entity
    {
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
        public List<PhotoModel> Photos { get; set; }
        public List<VideoModel> Videos { get; set; }
    }
}