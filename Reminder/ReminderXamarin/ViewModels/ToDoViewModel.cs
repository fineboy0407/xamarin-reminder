using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Input;
using ReminderXamarin.Extensions;
using ReminderXamarin.Models;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class ToDoViewModel : BaseViewModel
    {
        public ToDoViewModel()
        {
            CreateToDoCommand = new Command(CreateToDoCommandExecute);
            UpdateItemCommand = new Command(UpdateItemCommandExecute);
            DeleteItemCommand = new Command(result => DeleteItemCommandExecute());
        }

        public int Id { get; set; }
        public IList<string> AvailablePriorities => 
            Enum.GetNames(typeof(ToDoPriority)).Select(x => x.ToString()).ToList();

        public ToDoPriority Priority { get; set; } = ToDoPriority.High;
        public string Description { get; set; }
        public DateTime WhenHappens { get; set; }

        public ICommand CreateToDoCommand { get; set; }
        public ICommand UpdateItemCommand { get; set; }
        public ICommand DeleteItemCommand { get; set; }

        private void CreateToDoCommandExecute()
        {
            App.ToDoRepository.Save(this.ToToDoModel());
        }

        private void UpdateItemCommandExecute()
        {
            // Update edit date since user pressed confirm
            App.ToDoRepository.Save(this.ToToDoModel());
        }

        private int DeleteItemCommandExecute()
        {
            return App.ToDoRepository.DeleteModel(this.ToToDoModel());
        }
    }
}