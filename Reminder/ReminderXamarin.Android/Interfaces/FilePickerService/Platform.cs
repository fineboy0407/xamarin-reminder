using Android.App;
using Android.Content;

namespace ReminderXamarin.Droid.Interfaces.FilePickerService
{
    /// <summary>
    /// Android platform management. Required for PlatformDocumentPicker class.
    /// <para>
    /// Before use this class add event of type "int,Result,Intent" named ActivityResult in MainActivity class
    /// and override OnActivityResult method where invoke this event
    /// </para>
    /// </summary>
    public class Platform
    {
        static MainActivity _mainActivity;
        static int _requestCounter = 1;

        /// <summary>
        /// Application main activity. All Xamarin pages are shown as fragments inside this activity.
        /// </summary>
        public static Activity MainActivity => _mainActivity;

        /// <summary>
        /// Initializes platform for subsequent use. Call this method in MainActivity OnCreate() method.
        /// </summary>
        /// <remarks>
        /// This method needs to be invoked prior to the App object being created.
        /// </remarks>
        public static void Init(MainActivity mainActivity)
        {
            Platform._mainActivity = mainActivity;
        }

        /// <summary>
        /// Starts new activity, described by given intent, to receive some result via given callback.
        /// </summary>
        public static void StartActivityForResult(Intent intent, System.Action<Result, Intent> onResult)
        {
            int originalRequestCode;
            unchecked
            {
                if (_requestCounter < 0)
                {
                    _requestCounter = 1;
                }
                originalRequestCode = _requestCounter++;
            }
            System.Action<int, Result, Intent> listener = null;
            listener = (requestCode, resultCode, data) =>
            {
                if (originalRequestCode != requestCode)
                {
                    return;
                }
                onResult?.Invoke(resultCode, data);
                _mainActivity.ActivityResult -= listener;
            };
            _mainActivity.ActivityResult += listener;
            MainActivity.StartActivityForResult(intent, originalRequestCode);
        }
    }
}