using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ReminderXamarin.Extensions;
using ReminderXamarin.Helpers;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class AchievementsPageViewModel : BaseViewModel
    {
        public AchievementsPageViewModel()
        {
            Achievements = new ObservableCollection<AchievementViewModel>();

            RefreshListCommand = new Command(RefreshCommandExecute);
            SelectAchievementCommand = new Command<int>(id => SelectAchievementCommandExecute(id));
        }

        public bool IsRefreshing { get; set; }
        public ObservableCollection<AchievementViewModel> Achievements { get; set; }

        public ICommand RefreshListCommand { get; set; }
        public ICommand SelectAchievementCommand { get; set; }

        public void OnAppearing()
        {
            LoadAchievementsFromDatabase();
        }

        private void RefreshCommandExecute()
        {
            IsRefreshing = true;
            LoadAchievementsFromDatabase();
            IsRefreshing = false;
        }

        private AchievementViewModel SelectAchievementCommandExecute(int id)
        {
            return App.AchievementRepository.GetAchievementAsync(id).ToAchievementViewModel();
        }

        private void LoadAchievementsFromDatabase()
        {
            Achievements = App.AchievementRepository
                .GetAll()
                .Where(x => x.UserId == Settings.CurrentUserId)
                .ToAchievementViewModels()
                .OrderByDescending(x => x.GeneralTimeSpent)
                .ToObservableCollection();
        }
    }
}