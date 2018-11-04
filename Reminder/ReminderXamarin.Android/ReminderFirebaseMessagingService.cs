using System;
using System.Diagnostics;
using Android.App;
using Firebase.Messaging;
using Xamarin.Forms;

namespace ReminderXamarin.Droid
{
    [Service]
    [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
    public class ReminderFirebaseMessagingService : FirebaseMessagingService
    {
        public override void OnMessageReceived(RemoteMessage message)
        {
            base.OnMessageReceived(message);

            Debug.WriteLine("Received: " + message);

            try
            {
                var msg = message.GetNotification().Body;
                MessagingCenter.Send<object, string>(this, App.NotificationReceivedKey, msg);
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error extracting message: " + ex);
            }
        }
    }
}