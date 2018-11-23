using Microsoft.EntityFrameworkCore;

namespace Reminder.Migrations.Context
{
    public class BaseContext : DbContext
    {
        public BaseContext(DbContextOptions<BaseContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }
    }
}