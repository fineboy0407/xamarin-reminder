
using System.Threading.Tasks;
using Android.App;
using Android.Support.V4.Content;
using Android.Widget;
using Plugin.CurrentActivity;
using ReminderXamarin.Droid.Interfaces;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(AlertService))]
namespace ReminderXamarin.Droid.Interfaces
{
    /// <summary>
    /// Implementation of <see cref="IAlertService"/>
    /// </summary>
    public class AlertService : IAlertService
    {
        public Task<bool> ShowYesNoAlert(string message, string yesButtonText, string noButtonText)
        {
            var tcs = new TaskCompletionSource<bool>();
            var dialog = new Dialog(CrossCurrentActivity.Current.Activity);
            dialog.Window.SetBackgroundDrawable(ContextCompat.GetDrawable(CrossCurrentActivity.Current.Activity, Android.Resource.Color.Transparent));
            dialog.SetContentView(Resource.Layout.CustomAlertYesNo);
            TextView text = (TextView)dialog.FindViewById(Resource.Id.yesNoText);
            text.SetText(message, TextView.BufferType.Normal);

            Button acceptButton = (Button)dialog.FindViewById(Resource.Id.yesNoApplyButton);
            acceptButton.SetText(yesButtonText, TextView.BufferType.Normal);

            dialog.DismissEvent += (sender, e) =>
            {
                tcs.TrySetResult(false);
            };

            acceptButton.Click += (sender, e) =>
            {
                tcs.TrySetResult(true);
                dialog.Dismiss();
            };

            Button rejectButton = (Button)dialog.FindViewById(Resource.Id.yesNoRejectButton);
            rejectButton.SetText(noButtonText, TextView.BufferType.Normal);
            rejectButton.Click += (sender, e) =>
            {
                tcs.TrySetResult(false);
                dialog.Dismiss();
            };

            dialog.Show();

            return tcs.Task;
        }

        public void ShowOkAlert(string message, string okButtonText)
        {
            var dialog = new Dialog(CrossCurrentActivity.Current.Activity);
            dialog.Window.SetBackgroundDrawable(ContextCompat.GetDrawable(CrossCurrentActivity.Current.Activity, Android.Resource.Color.Transparent));
            dialog.SetContentView(Resource.Layout.CustomAlert);
            TextView text = (TextView)dialog.FindViewById(Resource.Id.alertText);
            text.SetText(message, TextView.BufferType.Normal);

            Button button = (Button)dialog.FindViewById(Resource.Id.alertApplyButton);
            button.SetText(okButtonText, TextView.BufferType.Normal);
            button.Click += (sender, args) =>
            {
                dialog.Dismiss();
            };

            dialog.Show();
        }
    }
}