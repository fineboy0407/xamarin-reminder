using System;
using System.Linq;
using ReminderXamarin.Extensions;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces.FilePickerService;
using ReminderXamarin.ViewModels;
using ReminderXamarin.Views;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UserProfilePage : ContentPage
    {
        private static readonly IPlatformDocumentPicker DocumentPicker = DependencyService.Get<IPlatformDocumentPicker>();
        private bool _isTranslated;

        public UserProfilePage(string username)
        {
            InitializeComponent();
            var appUser = App.UserRepository.GetAll().FirstOrDefault(x => x.UserName == username);
            if (appUser != null)
            {
                var viewModel = appUser.ToUserProfileViewModel();
                BindingContext = viewModel;
            }
            BackgroundImage.Source = ImageSource.FromResource(ConstantsHelper.BackgroundImageSource);
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            var viewModel = BindingContext as UserProfileViewModel;
            viewModel?.OnAppearing();
        }

        private async void EditUserProfilePhoto_OnTapped(object sender, EventArgs e)
        {
            var document = await DocumentPicker.DisplayImportAsync(this);
            if (document == null)
            {
                return;
            }
            UpdateUserButton.IsVisible = true;
            var viewModel = BindingContext as UserProfileViewModel;
            viewModel?.ChangeUserProfileCommand.Execute(document);
        }

        private async void UserProfileImage_OnTapped(object sender, EventArgs e)
        {
            await Navigation.PushPopupAsync(new FullSizeImageView(UserProfileImage.Source));
        }

        private void UpdateUserButton_OnClicked(object sender, EventArgs e)
        {
            if (BindingContext is UserProfileViewModel viewModel)
            {
                UpdateUserButton.IsVisible = false;
                viewModel.UpdateUserCommand.Execute(null);
            }
        }

        private void BackgroundImage_OnTapped(object sender, EventArgs e)
        {
            if (_isTranslated)
            {
                BackgroundImage.LayoutTo(new Rectangle(0, 0, Width, 100), 250, Easing.SpringIn);
                UserProfileImage.TranslateTo(0, 0, 250, Easing.SpringIn);
                PickUserPhotoImage.TranslateTo(0, 0, 250, Easing.SpringIn);
                UserInfoLayout.TranslateTo(0, 0, 250, Easing.SpringIn);
            }
            else
            {
                BackgroundImage.LayoutTo(new Rectangle(0, 0, Width, 200), 250, Easing.SpringOut);
                UserProfileImage.TranslateTo(0, 100, 250, Easing.SpringOut);
                PickUserPhotoImage.TranslateTo(0, 100, 250, Easing.SpringOut);
                UserInfoLayout.TranslateTo(0, 100, 250, Easing.SpringOut);
            }
            _isTranslated = !_isTranslated;
        }
    }
}