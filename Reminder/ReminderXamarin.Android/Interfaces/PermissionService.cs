using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using ReminderXamarin.Droid.Interfaces;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(PermissionService))]
namespace ReminderXamarin.Droid.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="IPermissionService"/> for Android.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        private static readonly int SdkVersion = (int)Android.OS.Build.VERSION.SdkInt;

        public async Task<bool> AskPermission()
        {
            //Runtime permissions available only from API25+
            if (SdkVersion < 23)
            {
                return true;
            }

            try
            {
                //Configure required permissions here and include them into manifest
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Camera);
                await CrossPermissions.Current.RequestPermissionsAsync(Permission.Storage);

                var cameraStatusResult = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera) ==
                                         PermissionStatus.Granted;
                var storageStatusResult = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Storage) ==
                                          PermissionStatus.Granted;

                return cameraStatusResult && storageStatusResult;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}