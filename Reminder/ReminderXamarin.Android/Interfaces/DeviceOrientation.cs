using Android.Runtime;
using Android.Views;
using Android.Content;
using ReminderXamarin.Droid.Interfaces;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientation))]
namespace ReminderXamarin.Droid.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="IDeviceOrientation"/> for Android.
    /// </summary>
    public class DeviceOrientation : IDeviceOrientation
    {
        public DeviceOrientations GetOrientation()
        {
            IWindowManager windowManager = Android.App.Application.Context.GetSystemService(Context.WindowService).JavaCast<IWindowManager>();

            var rotation = windowManager.DefaultDisplay.Rotation;
            bool isLandscape = rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270;
            return isLandscape ? DeviceOrientations.Landscape : DeviceOrientations.Portrait;
        }
    }
}