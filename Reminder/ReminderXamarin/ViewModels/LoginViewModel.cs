using System.Threading.Tasks;
using System.Windows.Input;
using ReminderXamarin.Helpers;
using ReminderXamarin.Pages;
using ReminderXamarin.Rest;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private readonly IIdentityClient _identityClient = new IdentityClient();

        public LoginViewModel()
        {
            LoginCommand = new Command(LoginCommandExecute);
            OAuthLoginCommand = new Command(async() => await OAuthLoginCommandExecute());
        }

        public string UserName { get; set; }
        public string Password { get; set; }

        // Set this field to true to hide error message at LoginPage.
        // When user will press "Login" button and get error change this property
        // will show error at LoginPage.
        public bool IsValid { get; set; } = true;

        public ICommand LoginCommand { get; set; }
        public ICommand OAuthLoginCommand { get; set; }

        private void LoginCommandExecute()
        {
            if (AuthenticationManager.Authenticate(UserName, Password))
            {
                Settings.ApplicationUser = UserName;
                Application.Current.MainPage = new NavigationPage(new MenuPage(UserName));
                IsValid = true;
            }
            else
            {
                IsValid = false;
            }
        }

        private async Task OAuthLoginCommandExecute()
        {
            var loginModel = new LoginModel
            {
                UserName = UserName,
                Password = Password
            };
            var result = await _identityClient.GetToken(loginModel);
            if (result.AccessToken != null)
            {
                var accessToken = result.AccessToken;
                Settings.AccessToken = accessToken;
            }
        }
    }
}