using System.Windows.Input;
using ReminderXamarin.Helpers;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class SettingsPageViewModel : BaseViewModel
    {
        public SettingsPageViewModel()
        {
            bool.TryParse(Settings.UsePin, out bool shouldUsePin);
            UsePin = shouldUsePin;
            Pin = Settings.UserPinCode;
            SaveSettingsCommand = new Command(SaveCommandExecute);
        }

        /// <summary>
        /// Use pin instead of username/password
        /// </summary>
        public bool UsePin { get; set; }
        public string Pin { get; set; }

        public ICommand SaveSettingsCommand { get; set; }

        private void SaveCommandExecute()
        {
            Settings.UserPinCode = int.TryParse(Pin, out var pin) ? Pin : "1111";
            Settings.UsePin = UsePin.ToString();
        }
    }
}