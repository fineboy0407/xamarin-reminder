using Reminder.Data;

namespace Reminder.Migrations
{
    public class AppContext : ApplicationContext
    {
        public AppContext() : base("DefaultConnection")
        {
        }
    }
}