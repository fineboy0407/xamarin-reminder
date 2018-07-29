using Microsoft.AspNet.Identity.EntityFramework;
using Reminder.WebApi.Helpers;

namespace Reminder.WebApi.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base(ConstantHelper.DefaultConnection, throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}