using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reminder.Helpers;
using Reminder.Migrations.Context;

namespace Reminder.Migrations
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public virtual void ConfigureServices(IServiceCollection services)
        {
            string connectionString;
#if DEBUG
            connectionString = Configuration.GetConnectionString(ConstantsHelper.DefaultConnection);
#else
            connectionString = Configuration.GetConnectionString(ConstantsHelper.ReleaseVersionConnection);
#endif

            services.AddDbContext<BaseContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddDbContext<IdentityContext>(options =>
                options.UseSqlServer(connectionString));
        }

        public void Configure()
        {
        }
    }
}