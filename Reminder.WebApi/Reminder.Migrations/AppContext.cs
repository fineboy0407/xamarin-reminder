using Reminder.DAL;

namespace Reminder.Migrations
{
    public class AppContext : ApplicationContext
    {
        public AppContext() : base("DefaultConnection")
        {
        }
    }
}