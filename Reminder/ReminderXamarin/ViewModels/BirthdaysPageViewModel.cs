using ReminderXamarin.Extensions;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ReminderXamarin.Helpers;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class BirthdaysPageViewModel : BaseViewModel
    {
        public BirthdaysPageViewModel()
        {
            BirthdayViewModels = new ObservableCollection<BirthdayViewModel>();
            RefreshListCommand = new Command(RefreshCommandExecute);
        }

        public bool IsRefreshing { get; set; }
        public ObservableCollection<BirthdayViewModel> BirthdayViewModels { get; set; }

        public ICommand RefreshListCommand { get; set; }

        public void OnAppearing()
        {
            LoadFriendsFromDatabase();
        }

        private void RefreshCommandExecute()
        {
            IsRefreshing = true;
            LoadFriendsFromDatabase();
            IsRefreshing = false;
        }

        private void LoadFriendsFromDatabase()
        {
            BirthdayViewModels = App.BirthdaysRepository
                .GetAll()
                .Where(x => x.UserId == Settings.CurrentUserId)
                .ToFriendViewModels()
                .OrderByDescending(x => x.BirthDayDate)
                .ToObservableCollection();
        }
    }
}