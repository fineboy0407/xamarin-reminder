using System;
using ReminderXamarin.Models;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoCreatePage : ContentPage
    {
        private readonly ToDoPriority _priority;

        public ToDoCreatePage(ToDoPriority priority)
        {
            _priority = priority;
            InitializeComponent();
            TimePicker.Time = DateTime.Now.TimeOfDay;
        }

        private async void Save_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(DescriptionEditor.Text))
            {
                await Navigation.PopAsync();
                return;
            }

            var eventDate = DatePicker.Date;
            var eventTime = TimePicker.Time;

            var fullDate = eventDate.Add(eventTime);

            ViewModel.Priority = _priority;
            ViewModel.WhenHappens = fullDate;
            ViewModel.Description = DescriptionEditor.Text;
            ViewModel.CreateToDoCommand.Execute(null);

            await Navigation.PopAsync();
        }
    }
}