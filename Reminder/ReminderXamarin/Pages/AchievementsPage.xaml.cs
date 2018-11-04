using System;
using System.IO;
using System.Linq;
using ReminderXamarin.Helpers;
using ReminderXamarin.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ImageCircle.Forms.Plugin.Abstractions;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchievementsPage : ContentPage
    {
        public AchievementsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ViewModel.OnAppearing();
        }

        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert
                (ConstantsHelper.Warning, ConstantsHelper.AchievementDeleteMessage, ConstantsHelper.Ok, ConstantsHelper.Cancel);
            if (result)
            {
                var menuItem = sender as MenuItem;
                var viewModel = menuItem?.CommandParameter as AchievementViewModel;
                viewModel?.DeleteAchievementCommand.Execute(viewModel);
                ViewModel.OnAppearing();
            }
        }

        private async void CreateAchievementButton_OnClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new AchievementCreatePage());
        }

        private async void AchievementsList_OnItemSelected(object sender, EventArgs e)
        {
            var container = sender as AbsoluteLayout;
            var hiddenIdLabel = container?.Children.FirstOrDefault(x => x.GetType() == typeof(Label)) as Label;
            if (hiddenIdLabel == null)
            {
                return;
            }
               
            int.TryParse(hiddenIdLabel.Text, out int id);

            var viewModel = ViewModel.Achievements.FirstOrDefault(x => x.Id == id);
            if (viewModel != null)
            {
                var achievementDetailPage = new AchievementDetailPage(viewModel);
                await Navigation.PushAsync(achievementDetailPage);
            }
        }
    }
}