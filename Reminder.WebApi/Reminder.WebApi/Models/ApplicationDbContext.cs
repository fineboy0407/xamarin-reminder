using Reminder.DAL;
using Reminder.WebApi.Helpers;

namespace Reminder.WebApi.Models
{
    public class ApplicationDbContext : ApplicationContext
    {
        public ApplicationDbContext()
            : base(ConstantHelper.DefaultConnection)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}