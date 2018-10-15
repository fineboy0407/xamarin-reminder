using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reminder.DAL.Entities;

namespace Reminder.DAL
{
    public class ApplicationContext : IdentityDbContext<AppUser>
    {
        public ApplicationContext(string connectionString) : base(connectionString)
        {
        }

        public DbSet<Note> Notes { get; set; }
        public DbSet<AchievementModel> Achievements { get; set; }
        public DbSet<AchievementNote> AchievementNotes { get; set; }
        public DbSet<BirthdayModel> Birthdays { get; set; }
        public DbSet<PhotoModel> Photos { get; set; }
        public DbSet<VideoModel> Videos { get; set; }
        public DbSet<ToDoModel> ToDoModels { get; set; }
    }
}