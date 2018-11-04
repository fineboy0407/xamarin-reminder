using System;
using ReminderXamarin.Helpers;
using ReminderXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchievementNoteEditPage : ContentPage
    {
        private readonly AchievementViewModel _achievementViewModel;
        private readonly AchievementNoteViewModel _achievementNoteViewModel;

        public AchievementNoteEditPage(AchievementViewModel achievementViewModel, AchievementNoteViewModel achievementNoteViewModel)
        {
            InitializeComponent();
            _achievementViewModel = achievementViewModel;
            _achievementNoteViewModel = achievementNoteViewModel;
            BindingContext = achievementNoteViewModel;
        }

        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert
                (ConstantsHelper.Warning, ConstantsHelper.AchievementNoteDeleteMessage, ConstantsHelper.Ok, ConstantsHelper.Cancel);
            if (result)
            {
                _achievementViewModel.DeleteAchievementNoteCommand.Execute(_achievementNoteViewModel);
                await Navigation.PopAsync();
            }
        }

        private async void SubmitButton_OnClicked(object sender, EventArgs e)
        {
            bool result = int.TryParse(TimeSpentEditor.Text, out var timeSpent);

            if (result)
            {
                _achievementNoteViewModel.Date = DatePicker.Date;
                _achievementNoteViewModel.HoursSpent = timeSpent;
                _achievementNoteViewModel.Description = DescriptionEditor.Text;

                _achievementViewModel.UpdateAchievementNoteCommand.Execute(_achievementNoteViewModel);
                await Navigation.PopAsync();
            }
            else
            {
                await DisplayAlert(ConstantsHelper.Warning, ConstantsHelper.TimeParsingError, ConstantsHelper.Ok);
            }
        }

        private async void CancelButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
    }
}