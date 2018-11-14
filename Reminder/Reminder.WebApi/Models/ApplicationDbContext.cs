using Reminder.Data;
using Reminder.WebApi.Helpers;

namespace Reminder.WebApi.Models
{
    public class ApplicationDbContext : ApplicationContext
    {
        #if DEBUG
        public ApplicationDbContext()
            : base(ConstantHelper.DefaultConnection)
        {
        }

#else
        public ApplicationDbContext()
            : base(ConstantHelper.ReleaseConnection)
        {
        }
#endif

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}