using System;
using System.IO;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces;
using ReminderXamarin.Interfaces.FilePickerService;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AchievementCreatePage : ContentPage
    {
        private static readonly IPlatformDocumentPicker DocumentPicker = DependencyService.Get<IPlatformDocumentPicker>();
        private static readonly IFileSystem FileService = DependencyService.Get<IFileSystem>();
        private static readonly IMediaService MediaService = DependencyService.Get<IMediaService>();

        public AchievementCreatePage()
        {
            InitializeComponent();
        }

        private async void Save_OnClicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TitleEntry.Text))
            {
                await Navigation.PopAsync();
                return;
            }
            ViewModel.Title = TitleEntry.Text;
            ViewModel.GeneralDescription = DescriptionEditor.Text;
            ViewModel.CreateAchievementCommand.Execute(null);
            await Navigation.PopAsync();
        }

        private async void PickImage_OnTapped(object sender, EventArgs e)
        {
            var document = await DocumentPicker.DisplayImportAsync(this);

            if (document == null)
            {
                return;
            }
            // Retrieve file content throught IFileService implementation.
            var imageContent = FileService.ReadAllBytes(document.Path);
            var resizedImage = MediaService.ResizeImage(imageContent, ConstantsHelper.AchievementImageWidth, ConstantsHelper.AchievementImageHeight);

            FileNameLabel.IsVisible = true;
            FileNameLabel.Text = document.Name;
            
            PreviewImage.IsVisible = true;
            PreviewImage.Source = ImageSource.FromStream(() => new MemoryStream(resizedImage));
            ViewModel.ImageContent = resizedImage;
        }
    }
}