using System.Collections.Generic;

namespace Reminder.Helpers
{
    public static class ConstantsHelper
    {
        public const string ContextShemaName = "dbo";
        public const string DefaultConnection = "DefaultConnection";
        public const string ReleaseVersionConnection = "ReleaseVersionConnection";

        public const string EmailIsEmpty = "Email is empty";
        public const string PasswordIsEmpty = "Password is empty";
        public const string PasswordIncorrect = "Password incorrect";
        public const string PasswordErrorMessage = "Enter correct password";

        public const string ApiUrl = "https://localhost:44342/api/notes";
        public const string ApiName = "Reminder.CoreApi";
        public const string AuthenticationType = "Bearer";
        public const string CorsPolicy = "CorsPolicy";
        public const string IdentityServerUrl = "https://identityserver20181030042351.azurewebsites.net/";

        // Angular client constants
        public const string AngularClientId = "Angular_client";
        public const string AngularClientName = "Angular_Client";
        public static List<string> AngularClientAllowedScopes = new List<string> { "openid", "profile", ApiName, "custom.profile" };
        public static List<string> AngularClientRedirectUris = new List<string> { "http://localhost:4200/auth-callback" };
        public static List<string> AngularClientPostLogoutRedirectUris = new List<string> { "http://localhost:4200/logout-callback" };
        public static List<string> AngularClientAllowedCorsOrigins = new List<string> { "http://localhost:4200" };

        // Xamarin client constants
        public const string XamarinClientId = "XamarinClient";
    }
}
