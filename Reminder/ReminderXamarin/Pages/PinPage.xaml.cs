using System;
using System.Text;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ImageSource = Xamarin.Forms.ImageSource;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PinPage : ContentPage
    {
        private static int _currentCount;
        private readonly StringBuilder _pinBuilder;

        public PinPage()
        {
            InitializeComponent();
            BackgroundImage.Source = ImageSource.FromResource(ConstantsHelper.BackgroundImageSource);
            _pinBuilder = new StringBuilder();
        }

        private void Button_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                _currentCount++;

                // Add selection effect
                button.BackgroundColor = Color.White;
                button.TextColor = Color.FromHex("#323232");
                Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                {
                    button.BackgroundColor = Color.Transparent;
                    button.TextColor = Color.White;
                    return false;
                });

                switch (_currentCount)
                {
                    case 1:
                        FirstNumber.Source = ConstantsHelper.FilledDotImage;
                        break;
                    case 2:
                        SecondNumber.Source = ConstantsHelper.FilledDotImage;
                        break;
                    case 3:
                        ThirdNumber.Source = ConstantsHelper.FilledDotImage;
                        break;
                    case 4:
                        FourthNumber.Source = ConstantsHelper.FilledDotImage;
                        break;
                }

                int.TryParse(button.Text, out var number);
                _pinBuilder.Append(number);

                if (_currentCount == 4)
                {
                    int.TryParse(_pinBuilder.ToString(), out int pin);
                    ViewModel.Pin = pin;
                    ResetImagesAndCount();
                    ViewModel.LoginCommand.Execute(null);
                }
            }
        }

        private void ResetImagesAndCount()
        {
            _pinBuilder.Length = 0;
            _currentCount = 0;

            FirstNumber.Source = ConstantsHelper.EmptyDotImage;
            SecondNumber.Source = ConstantsHelper.EmptyDotImage;
            ThirdNumber.Source = ConstantsHelper.EmptyDotImage;
            FourthNumber.Source = ConstantsHelper.EmptyDotImage;
        }

        private void RemoveNumber()
        {
            if (_pinBuilder.Length > 0)
            {
                _pinBuilder.Length--;
            }

            switch (_currentCount)
            {
                case 1:
                    FirstNumber.Source = ConstantsHelper.EmptyDotImage;
                    break;
                case 2:
                    SecondNumber.Source = ConstantsHelper.EmptyDotImage;
                    break;
                case 3:
                    ThirdNumber.Source = ConstantsHelper.EmptyDotImage;
                    break;
                case 4:
                    FourthNumber.Source = ConstantsHelper.EmptyDotImage;
                    break;
            }

            if (_currentCount > 0)
            {
                _currentCount--;
            }
        }

        private void Exit_OnTapped(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundColor = Color.White;
                button.TextColor = Color.FromHex("#323232");

                Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                {
                    button.BackgroundColor = Color.Transparent;
                    button.TextColor = Color.White;
                    var applicationService = DependencyService.Get<IApplicationService>();
                    applicationService.CloseApplication();
                    return false;
                });
            }
        }

        private void DeleteButton_OnClicked(object sender, EventArgs e)
        {
            if (sender is Button button)
            {
                button.BackgroundColor = Color.White;
                button.TextColor = Color.FromHex("#323232");
                Device.StartTimer(TimeSpan.FromSeconds(0.1), () =>
                {
                    button.BackgroundColor = Color.Transparent;
                    button.TextColor = Color.White;
                    return false;
                });
            }
            RemoveNumber();
        }
    }
}