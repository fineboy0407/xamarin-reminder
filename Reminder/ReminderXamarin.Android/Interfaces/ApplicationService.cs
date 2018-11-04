using Plugin.CurrentActivity;
using ReminderXamarin.Droid.Interfaces;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(ApplicationService))]
namespace ReminderXamarin.Droid.Interfaces
{
    /// <summary>
    /// Implementation of <see cref="IApplicationService"/>.
    /// </summary>
    public class ApplicationService : IApplicationService
    {
        public void CloseApplication()
        {
            var activity = CrossCurrentActivity.Current.Activity;
            activity.Finish();
        }
    }
}