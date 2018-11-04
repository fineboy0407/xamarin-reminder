using System;
using ReminderXamarin.Helpers;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            BackgroundImage.Source = ImageSource.FromResource(ConstantsHelper.BackgroundImageSource);
        }

        private void UserNameEntry_OnCompleted(object sender, EventArgs e)
        {
            PasswordEntry.Focus();
        }

        private void PasswordEntry_OnCompleted(object sender, EventArgs e)
        {
            ConfirmPasswordEntry.Focus();
        }

        private void TogglePasswordVisibilityButton_OnTapped(object sender, EventArgs e)
        {
            PasswordEntry.IsPassword = !PasswordEntry.IsPassword;
        }

        private void ToggleConfirmPassword_OnTapped(object sender, EventArgs e)
        {
            ConfirmPasswordEntry.IsPassword = !ConfirmPasswordEntry.IsPassword;
        }

        private void SubmitButton_OnClicked(object sender, EventArgs e)
        {
            ViewModel.UserName = UserNameEntry.Text;
            ViewModel.Password = PasswordEntry.Text;
            ViewModel.ConfirmPassword = ConfirmPasswordEntry.Text;

            ViewModel.RegisterCommand.Execute(null);
        }

        private void Login_OnTapped(object sender, EventArgs e)
        {
            Application.Current.MainPage = new LoginPage();
        }
    }
}