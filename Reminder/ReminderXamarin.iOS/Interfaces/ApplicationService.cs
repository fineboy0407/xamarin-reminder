using System.Threading;
using ReminderXamarin.iOS.Interfaces;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ApplicationService))]
namespace ReminderXamarin.iOS.Interfaces
{
    /// <summary>
    /// Implementation of <see cref="IApplicationService"/>.
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        public void CloseApplication()
        {
            Thread.CurrentThread.Abort();
        }
    }
}