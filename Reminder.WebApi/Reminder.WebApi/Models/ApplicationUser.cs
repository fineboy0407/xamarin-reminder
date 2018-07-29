using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Reminder.WebApi.Models.Entities;

namespace Reminder.WebApi.Models
{
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        {
            Achievements = new List<AchievementModel>();
            Birthdays = new List<BirthdayModel>();
            ToDoModels = new List<ToDoModel>();
        }

        public byte[] ImageContent { get; set; }
        public List<Note> Notes { get; set; }
        public List<AchievementModel> Achievements { get; set; }
        public List<BirthdayModel> Birthdays { get; set; }
        public List<ToDoModel> ToDoModels { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}