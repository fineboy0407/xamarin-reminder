using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows.Input;
using ReminderXamarin.Extensions;
using ReminderXamarin.Helpers;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class NotesGroup : ObservableCollection<NoteViewModel>
    {
        public string Title { get; set; }
    }

    public class NotesPageViewModel : BaseViewModel
    {
        private List<NoteViewModel> _allNotes;
        private string _currentSearchText = string.Empty;

        public NotesPageViewModel()
        {
            NotesGroups = new ObservableCollection<NotesGroup>();
            Notes = new ObservableCollection<NoteViewModel>();

            RefreshListCommand = new Command(RefreshCommandExecute);
            SelectNoteCommand = new Command<int>(id => SelectNoteCommandExecute(id));
            SearchCommand = new Command<string>(SearchNotesByDescription);
        }

        public bool IsRefreshing { get; set; }
        public ObservableCollection<NotesGroup> NotesGroups { get; set; }
        public ObservableCollection<NoteViewModel> Notes { get; set; }
        public ICommand RefreshListCommand { get; set; }
        public ICommand SelectNoteCommand { get; set; }
        public ICommand SearchCommand { get; set; }
        public ICommand FilterNotesByDateCommand { get; set; }

        public void OnAppearing()
        {
            LoadNoteFromDatabase();
        }

        private void RefreshCommandExecute()
        {
            IsRefreshing = true;
            LoadNoteFromDatabase();
            IsRefreshing = false;
        }

        private void SearchNotesByDescription(string text)
        {
            _currentSearchText = text;
            Notes = _allNotes
                .Where(x => x.FullDescription.Contains(text))
                .ToObservableCollection();
            DivideNotesIntoGroups();
        }

        private void LoadNoteFromDatabase()
        {
            // Fetch all note models from database.
            _allNotes = App.NoteRepository
                .GetAll()
                .Where(x => x.UserId == Settings.CurrentUserId)
                .ToNoteViewModels()
                .OrderByDescending(x => x.EditDate)
                .ToList();
            // Show recently edited notes at the top of the list.
            Notes = _allNotes.ToObservableCollection();
            // Save filtering.
            SearchNotesByDescription(_currentSearchText);
        }
        
        private void DivideNotesIntoGroups()
        {
            NotesGroups = new ObservableCollection<NotesGroup>();
            var noteGroups = Notes.GroupBy(g => g.CreationDate.ToString("d"));

            foreach (var noteGroup in noteGroups)
            {
                var noteGroupObj = new NotesGroup
                {
                    Title = noteGroup.Key
                };
                foreach (var model in noteGroup)
                {
                    noteGroupObj.Add(model);
                }
                NotesGroups.Add(noteGroupObj);
            }
        }

        private NoteViewModel SelectNoteCommandExecute(int id)
        {
            return App.NoteRepository.GetNoteAsync(id).ToNoteViewModel();
        }
    }
}