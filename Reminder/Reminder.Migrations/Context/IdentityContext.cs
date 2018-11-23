using Microsoft.EntityFrameworkCore;
using Reminder.Data.EF;
using Reminder.Helpers;

namespace Reminder.Migrations.Context
{
    public class IdentityContext : AppIdentityDbContext
    {
        public IdentityContext(DbContextOptions dbContextOptions)
            : base(dbContextOptions, ConstantsHelper.ContextShemaName)
        {
        }
    }
}