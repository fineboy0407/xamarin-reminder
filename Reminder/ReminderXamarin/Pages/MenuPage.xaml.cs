using System;
using System.IO;
using System.Linq;
using ReminderXamarin.Helpers;
using ReminderXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MenuPage : MasterDetailPage, IDisposable
    {
        private readonly UserModel _appUser;

        public MenuPage(string userName)
        {
            InitializeComponent();
            var user = App.UserRepository.GetAll().FirstOrDefault(x => x.UserName == userName);
            if (user != null)
            {
                _appUser = user;
                Settings.CurrentUserId = user.Id;
            }
            BindingContext = _appUser;

            NavigationPage.SetHasNavigationBar(this, false);
            var pages = MenuHelper.GetMenu().Where(x => x.IsDisplayed).ToList();
            MenuList.ItemsSource = pages;

            BackgroundImage.Source = ImageSource.FromResource(ConstantsHelper.SideMenuBackground);

            MessagingCenter.Subscribe<NotesPage, MenuPageIndex>(this, ConstantsHelper.DetailPageChanged, (sender, pageIndex) =>
            {
                switch (pageIndex)
                {
                    case MenuPageIndex.NotesPage:
                        Navigation.PushAsync(new NotesPage());
                        break;
                    case MenuPageIndex.ToDoPage:
                        Navigation.PushAsync(new ToDoTabbedPage());
                        break;
                    case MenuPageIndex.BirthdaysPage:
                        Navigation.PushAsync(new BirthdaysPage());
                        break;
                    case MenuPageIndex.AchievementsPage:
                        Navigation.PushAsync(new AchievementsPage());
                        break;
                    case MenuPageIndex.SettingsPage:
                        Navigation.PushAsync(new SettingsPage());
                        break;
                    default:
                        break;
                }
            });
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            if (_appUser != null)
            {
                byte[] fileContent = _appUser.ImageContent;
                UserProfilePhoto.Source = ImageSource.FromStream(() => new MemoryStream(fileContent));
            }

            if (Navigation.NavigationStack.Count > 0)
            {
                var pages = Navigation.NavigationStack;
                for (int i = 0; i < pages.Count; i++)
                {
                    if (pages[i] != this)
                    {
                        Navigation.RemovePage(pages[i]);
                    }
                }
            }
        }

        private void MenuList_OnItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem is MasterPageItem item)
            {
                MenuList.SelectedItem = null;
                if (item.TargetType != typeof(string))
                {
                    var page = Activator.CreateInstance(item.TargetType) as Page;
                    NavigateTo(page);
                }
            }
        }

        public void NavigateTo(Page page)
        {
            Detail = new NavigationPage(page);
            IsPresented = false;
        }

        public void Dispose()
        {
            MessagingCenter.Unsubscribe<NotesPage, MenuPageIndex>(this, ConstantsHelper.DetailPageChanged);
            MessagingCenter.Unsubscribe<UserProfilePage>(this, ConstantsHelper.ProfileUpdated);
        }

        private void UserProfile_OnTapped(object sender, EventArgs e)
        {
            if (_appUser != null)
            {
                var userProfilePage = new UserProfilePage(_appUser.UserName);
                NavigateTo(userProfilePage);
            }
        }

        private void Logout_OnTapped(object sender, EventArgs e)
        {
            bool.TryParse(Settings.UsePin, out var result);
            if (result)
            {
                Application.Current.MainPage = new PinPage();
            }
            else
            {
                Application.Current.MainPage = new LoginPage();
            }
        }
    }
}