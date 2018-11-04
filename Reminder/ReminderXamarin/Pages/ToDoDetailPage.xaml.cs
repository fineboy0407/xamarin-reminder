using System;
using ReminderXamarin.Helpers;
using ReminderXamarin.Models;
using ReminderXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ToDoDetailPage : ContentPage
    {
        private readonly ToDoViewModel _viewModel;

        public ToDoDetailPage(ToDoViewModel viewModel)
        {
            InitializeComponent();
            TimePicker.Time = viewModel.WhenHappens.TimeOfDay;
            BindingContext = viewModel;
            _viewModel = viewModel;

            Title = $"{viewModel.WhenHappens:d}";
            DescriptionEditor.Text = viewModel.Description;
        }

        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert
                (ConstantsHelper.Warning, ConstantsHelper.ToDoItemDeleteMessage, ConstantsHelper.Ok, ConstantsHelper.Cancel);
            if (result)
            {
                _viewModel.DeleteItemCommand.Execute(_viewModel);
                await Navigation.PopAsync();
            }
        }

        private async void Confirm_OnClicked(object sender, EventArgs e)
        {
            _viewModel.Description = DescriptionEditor.Text;

            var eventDate = DatePicker.Date;
            var eventTime = TimePicker.Time;

            var fullDate = eventDate.Add(eventTime);
            _viewModel.WhenHappens = fullDate;

            if (PriorityPicker.SelectedItem is ToDoPriority priority)
            {
                _viewModel.Priority = priority;
            }
            _viewModel.UpdateItemCommand.Execute(_viewModel);

            await Navigation.PopAsync();
        }
    }
}