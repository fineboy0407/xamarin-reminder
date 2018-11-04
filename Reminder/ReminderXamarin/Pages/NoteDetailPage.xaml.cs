using System;
using System.Linq;
using ReminderXamarin.Elements;
using ReminderXamarin.Extensions;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces.FilePickerService;
using ReminderXamarin.ViewModels;
using ReminderXamarin.Views;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteDetailPage : ContentPage
    {
        private static readonly IPlatformDocumentPicker DocumentPicker = DependencyService.Get<IPlatformDocumentPicker>();
        private readonly NoteViewModel _noteViewModel;

        public NoteDetailPage(NoteViewModel noteViewModel)
        {
            InitializeComponent();
            BindingContext = noteViewModel;
            _noteViewModel = noteViewModel;

            Title = $"{noteViewModel.EditDate:d}";
            DescriptionEditor.Text = noteViewModel.Description;
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            _noteViewModel.PhotosCollectionChanged += NoteViewModelOnPhotosCollectionChanged;
            MessagingCenter.Subscribe<ImageGallery, int>(this, ConstantsHelper.ImageDeleted, (gallery, i) =>
            {
                _noteViewModel.DeletePhotoCommand.Execute(i);
            });
        }

        private void NoteViewModelOnPhotosCollectionChanged(object sender, EventArgs eventArgs)
        {
            ImageGallery.IsVisible = true;
            ImageGallery.Render();

            if (!ConfirmButton.IsVisible)
            {
                ConfirmButton.IsVisible = true;
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
            _noteViewModel.PhotosCollectionChanged -= NoteViewModelOnPhotosCollectionChanged;
            MessagingCenter.Unsubscribe<ImageGallery, int>(this, ConstantsHelper.ImageDeleted);
        }

        private async void Delete_OnClicked(object sender, EventArgs e)
        {
            bool result = await DisplayAlert
                (ConstantsHelper.Warning, ConstantsHelper.NoteDeleteMessage, ConstantsHelper.Ok, ConstantsHelper.Cancel);
            if (result)
            {
                _noteViewModel.DeleteNoteCommand.Execute(null);
                await Navigation.PopAsync();
            }
        }

        private void Confirm_OnClicked(object sender, EventArgs e)
        {
            _noteViewModel.Description = DescriptionEditor.Text;
            _noteViewModel.UpdateNoteCommand.Execute(null);

            if (ConfirmButton.IsVisible)
            {
                ConfirmButton.IsVisible = false;
            }
        }

        private void DescriptionEditor_OnTextChanged(object sender, TextChangedEventArgs e)
        {
            if (!ConfirmButton.IsVisible)
            {
                ConfirmButton.IsVisible = true;
            }
        }

        private async void HorizontalImageGallery_OnItemTapped(object sender, EventArgs e)
        {
            //if (sender is Image tappedImage)
            //{
            //    FileImageSource fileImageSource = (FileImageSource)tappedImage.Source;
            //    string filePath = fileImageSource.File;
            //    _noteViewModel.SelectedPhoto = _noteViewModel.Photos.FirstOrDefault(x => x.ResizedPath == filePath);
            //    var images = _noteViewModel.Photos.ToImages();
            //    var currentImage = _noteViewModel.SelectedPhoto.ToImage();

            //    await Navigation.PushPopupAsync(new FullSizeImageGallery(images, currentImage));
            //}
            if (sender is Image tappedImage)
            {
                await Navigation.PushPopupAsync(new FullSizeImageView(tappedImage.Source));
            }
        }

        private void AddButton_OnClicked(object sender, EventArgs e)
        {
            AddItemsToNoteContentView.IsVisible = true;
        }

        private async void AddItemsToNoteContentView_OnPickPhotoButtonClicked(object sender, EventArgs e)
        {
            _noteViewModel.IsLoading = true;

            var document = await DocumentPicker.DisplayImportAsync(this);
            if (document == null)
            {
                _noteViewModel.IsLoading = false;
                return;
            }
            _noteViewModel.PickPhotoCommand.Execute(document);
        }

        private void AddItemsToNoteContentView_OnTakePhotoButtonClicked(object sender, EventArgs e)
        {
            _noteViewModel.TakePhotoCommand.Execute(null);
        }
    }
}