using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ReminderXamarin.Extensions;
using ReminderXamarin.Helpers;
using ReminderXamarin.Models;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class ToDoPageViewModel : BaseViewModel
    {
        public ToDoPageViewModel()
        {
            HighPriorityModels = new ObservableCollection<ToDoViewModel>();
            MidPriorityModels = new ObservableCollection<ToDoViewModel>();
            LowPriorityModels = new ObservableCollection<ToDoViewModel>();

            RefreshListCommand = new Command(RefreshCommandExecute);
            SelectItemCommand = new Command<int>(id => SelectItemCommandExecute(id));
        }

        public void OnAppearing()
        {
            LoadModelsFromDatabase();
        }

        public bool IsLoading { get; set; }
        public bool IsRefreshing { get; set; }

        public ObservableCollection<ToDoViewModel> HighPriorityModels { get; set; }
        public ObservableCollection<ToDoViewModel> MidPriorityModels { get; set; }
        public ObservableCollection<ToDoViewModel> LowPriorityModels { get; set; }

        public ICommand RefreshListCommand { get; set; }
        public ICommand ShowDetailsCommand { get; set; }
        public ICommand SelectItemCommand { get; set; }

        private void RefreshCommandExecute()
        {
            IsRefreshing = true;
            LoadModelsFromDatabase();
            IsRefreshing = false;
        }

        private ToDoViewModel SelectItemCommandExecute(int id)
        {
            return App.ToDoRepository.GetToDoAsync(id).ToToDoViewModel();
        }

        private void LoadModelsFromDatabase()
        {
            var allModels = App.ToDoRepository
                .GetAll()
                .Where(x => x.UserId == Settings.CurrentUserId)
                .ToToDoViewModels();

            HighPriorityModels = allModels.Where(x => x.Priority == ToDoPriority.High)
                .OrderByDescending(x => x.WhenHappens)
                .ToObservableCollection();

            MidPriorityModels = allModels.Where(x => x.Priority == ToDoPriority.Medium)
                .OrderByDescending(x => x.WhenHappens)
                .ToObservableCollection();

            LowPriorityModels = allModels.Where(x => x.Priority == ToDoPriority.Low)
                .OrderByDescending(x => x.WhenHappens)
                .ToObservableCollection();
        }
    }
}