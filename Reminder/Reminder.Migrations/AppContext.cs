using Reminder.Data;

namespace Reminder.Migrations
{
    public class AppContext : ApplicationContext
    {
#if DEBUG
        public AppContext() : base("DefaultConnection")
        {
        }
#else
        public AppContext() : base("ReleaseConnection")
        {
        }
#endif
    }
}