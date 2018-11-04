using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
        public SettingsPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ConfirmButton.IsVisible = false;
        }

        private void ConfirmButton_OnClicked(object sender, EventArgs e)
        {
            ViewModel.Pin = PinEntry.Text;
            ViewModel.SaveSettingsCommand.Execute(null);
            ConfirmButton.IsVisible = false;
        }

        private void UsePinSwitch_OnOnChanged(object sender, ToggledEventArgs e)
        {
            ConfirmButton.IsVisible = true;
        }
    }
}