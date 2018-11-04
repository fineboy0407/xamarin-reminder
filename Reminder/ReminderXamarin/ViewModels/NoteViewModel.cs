using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using ReminderXamarin.Extensions;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces;
using ReminderXamarin.Interfaces.FilePickerService;
using ReminderXamarin.Models;
using Xamarin.Forms;

namespace ReminderXamarin.ViewModels
{
    public class NoteViewModel : BaseViewModel
    {
        private readonly MediaHelper _mediaHelper;
        private readonly TransformHelper _transformHelper;
        private static readonly IPermissionService PermissionService = DependencyService.Get<IPermissionService>();

        public NoteViewModel()
        {
            _mediaHelper = new MediaHelper();
            _transformHelper = new TransformHelper();
            Photos = new ObservableCollection<PhotoViewModel>();
            Videos = new ObservableCollection<VideoModel>();

            TakePhotoCommand = new Command(async () => await TakePhotoCommandExecute());
            DeletePhotoCommand = new Command<int>(DeletePhotoCommandExecute);
            TakeVideoCommand = new Command(async () => await TakeVideoCommandExecute());
            PickPhotoCommand = new Command<PlatformDocument>(async document => await PickPhotoCommandExecute(document));
            CreateNoteCommand = new Command(CreateNoteCommandExecute);
            UpdateNoteCommand = new Command(UpdateNoteCommandExecute);
            DeleteNoteCommand = new Command(note => DeleteNoteCommandExecute());
        }

        public PhotoViewModel SelectedPhoto { get; set; }
        public ObservableCollection<PhotoViewModel> Photos { get; set; }
        public ObservableCollection<VideoModel> Videos { get; set; }

        public int Id { get; set; }
        public bool ShouldDisplayMessageWhenLeaving { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime EditDate { get; set; }
        public string FullDescription { get; set; }
        public bool IsLoading { get; set; }
        
        public ICommand DeletePhotoCommand { get; set; }
        public ICommand TakePhotoCommand { get; set; }
        public ICommand TakeVideoCommand { get; set; }
        public ICommand PickPhotoCommand { get; set; }
        public ICommand CreateNoteCommand { get; set; }
        public ICommand UpdateNoteCommand { get; set; }
        public ICommand DeleteNoteCommand { get; set; }

        /// <summary>
        /// Invokes when Photos collection changing.
        /// </summary>
        public event EventHandler PhotosCollectionChanged;

        private async Task TakePhotoCommandExecute()
        {
            bool permissionResult = await PermissionService.AskPermission();
            if (permissionResult)
            {
                IsLoading = true;
                var photoModel = await _mediaHelper.TakePhotoAsync();
                if (photoModel != null)
                {
                    Photos.Add(photoModel.ToPhotoViewModel());
                    PhotosCollectionChanged?.Invoke(this, EventArgs.Empty);
                }
                IsLoading = false;
            }
        }

        private async Task PickPhotoCommandExecute(PlatformDocument document)
        {
            if (document.Name.EndsWith(".png") || document.Name.EndsWith(".jpg"))
            {
                var photoModel = new PhotoModel
                {
                    NoteId = Id
                };

                var mediaService = DependencyService.Get<IMediaService>();
                var fileSystem = DependencyService.Get<IFileSystem>();
                var imageContent = fileSystem.ReadAllBytes(document.Path);

                var resizedImage = mediaService.ResizeImage(imageContent, ConstantsHelper.ResizedImageWidth, ConstantsHelper.ResizedImageHeight);
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
                string imagePath = Path.Combine(path, document.Name);

                File.WriteAllBytes(imagePath, resizedImage);
                photoModel.ResizedPath = imagePath;
                photoModel.Thumbnail = imagePath;

                await _transformHelper.ResizeAsync(imagePath, photoModel);

                Photos.Add(photoModel.ToPhotoViewModel());
                PhotosCollectionChanged?.Invoke(this, EventArgs.Empty);
            }
            IsLoading = false;
        }

        private void DeletePhotoCommandExecute(int position)
        {
            IsLoading = true;
            if (Photos.Any())
            {
                Photos.RemoveAt(position);
                PhotosCollectionChanged?.Invoke(this, EventArgs.Empty);
            }
            IsLoading = false;
        }

        //TODO: implement video player
        private async Task TakeVideoCommandExecute()
        {
            bool permissionResult = await PermissionService.AskPermission();

            if (permissionResult)
            {
                IsLoading = true;
                var videoModel = await _mediaHelper.TakeVideoAsync();
                if (videoModel != null)
                {
                    Videos.Add(videoModel);
                }
                IsLoading = false;
            }
        }

        private void CreateNoteCommandExecute()
        {
            App.NoteRepository.Save(this.ToNoteModel());
            IsLoading = false;
        }

        private void UpdateNoteCommandExecute()
        {
            IsLoading = true;
            // Update edit date since user pressed confirm
            EditDate = DateTime.Now;
            App.NoteRepository.Save(this.ToNoteModel());
            IsLoading = false;
        }

        private int DeleteNoteCommandExecute()
        {
            return App.NoteRepository.DeleteNote(this.ToNoteModel());
        }
    }
}