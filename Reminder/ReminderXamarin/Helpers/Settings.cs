using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ReminderXamarin.Helpers
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings => CrossSettings.Current;

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private const string CurrentUserIdKey = "0";
        private const string UsePinKey = "True";
        private const string UserPinCodeKey = "0000";
        private const string ApplicationUserKey = "";
        private const string AccessTokenKey = "access_token";

        private static readonly string SettingsDefault = string.Empty;

        #endregion

        public static string CurrentUserId
        {
            get => AppSettings.GetValueOrDefault(CurrentUserIdKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(CurrentUserIdKey, value);
        }

        public static string UsePin
        {
            get => AppSettings.GetValueOrDefault(UsePinKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(UsePinKey, value);
        }

        public static string UserPinCode
        {
            get => AppSettings.GetValueOrDefault(UserPinCodeKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(UserPinCodeKey, value);
        }

        public static string ApplicationUser
        {
            get => AppSettings.GetValueOrDefault(ApplicationUserKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(ApplicationUserKey, value);
        }

        public static string AccessToken
        {
            get => AppSettings.GetValueOrDefault(AccessTokenKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(AccessTokenKey, value);
        }

        public static string GeneralSettings
        {
            get => AppSettings.GetValueOrDefault(SettingsKey, SettingsDefault);
            set => AppSettings.AddOrUpdateValue(SettingsKey, value);
        }

        public static void Clear()
        {
            AppSettings.Clear();
        }
    }
}