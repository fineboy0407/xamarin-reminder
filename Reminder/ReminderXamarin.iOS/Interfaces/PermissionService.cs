using System;
using System.Threading.Tasks;
using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using ReminderXamarin.iOS.Interfaces;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(PermissionService))]
namespace ReminderXamarin.iOS.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="IPermissionService"/> for iOS.
    /// </summary>
    public class PermissionService : IPermissionService
    {
        public async Task<bool> AskPermission()
        {
            try
            {
                //Configure required permissions here and include them into info.plist
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