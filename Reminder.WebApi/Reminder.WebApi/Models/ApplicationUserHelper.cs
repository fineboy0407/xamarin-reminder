using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Reminder.DAL.Entities;

namespace Reminder.WebApi.Models
{
    public static class ApplicationUserHelper
    {
        public static async Task<ClaimsIdentity> GenerateUserIdentityAsync(AppUser user, UserManager<AppUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(user, authenticationType);
            // Add custom user claims here
            return userIdentity;
        }
    }
}