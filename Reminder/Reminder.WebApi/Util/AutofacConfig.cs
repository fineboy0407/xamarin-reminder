using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using Reminder.Data.Abstract;
using Reminder.Data.Concrete;
using Reminder.Data.Entities;
using Reminder.WebApi.Models;

namespace Reminder.WebApi.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            var config = GlobalConfiguration.Configuration;

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<Repository<Note>>()
                .WithParameter("dbContext", ApplicationDbContext.Create())
                .As<IRepository<Note>>();

            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}