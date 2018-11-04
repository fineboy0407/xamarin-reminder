using System;
using System.Diagnostics;
using System.Threading.Tasks;
using PCLStorage;
using Plugin.Media;
using Plugin.Media.Abstractions;
using ReminderXamarin.Models;
using PhotoModel = ReminderXamarin.Models.PhotoModel;

namespace ReminderXamarin.Helpers
{
    /// <summary>
    /// Provide helper methods for taking photos and videos.
    /// </summary>
    public class MediaHelper
    {
        private readonly TransformHelper _transformHelper;

        public MediaHelper()
        {
            _transformHelper = new TransformHelper();
        }

        /// <summary>
        /// Launches the camera using Plugin.Media and lets the user take one photo.
        /// Store photo data in PhotoModel.
        /// </summary>
        public async Task<PhotoModel> TakePhotoAsync()
        {
            bool b = await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakePhotoSupported)
            {
                return null;
            }

            var dt = DateTime.Now;
            var file = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions
            {
                PhotoSize = PhotoSize.Medium,
                Directory = "Photos",
                Name = $"{dt:yyyyMMdd}_{dt:HHmmss}.jpg",
                SaveToAlbum = true
            });

            if (file != null)
            {
                var pm = new PhotoModel();

                await _transformHelper.ResizeAsync(file.Path, pm);
                await DeleteFileAsync(file.Path);

                return pm;
            }
            return null;
        }

        /// <summary>
        /// Launches the camera using Plugin.Media and lets the user take video.
        /// Returns VideoModel that contains path to the video.
        /// </summary>
        /// <returns></returns>
        public async Task<VideoModel> TakeVideoAsync()
        {
            bool b = await CrossMedia.Current.Initialize();

            if (!CrossMedia.Current.IsCameraAvailable || !CrossMedia.Current.IsTakeVideoSupported)
            {
                return null;
            }

            var dt = DateTime.Now;
            var file = await CrossMedia.Current.TakeVideoAsync(new Plugin.Media.Abstractions.StoreVideoOptions
            {
                Quality = VideoQuality.High,
                Directory = "Videos",
                Name = $"{dt:yyyyMMdd}_{dt:HHmmss}.mp4",
                SaveToAlbum = true
            });

            if (file != null)
            {
                var vm = new VideoModel
                {
                    Path = file.Path
                };
                return vm;
            }
            return null;
        }

        /// <summary>
        /// Deletes the PhotoModel and its pictures using PCLStorage.
        /// </summary>
        /// <param name="pm">The PhotoModel to be deleted</param>
        public async Task DeletePhotoModelAsync(PhotoModel pm)
        {
            await DeleteFileAsync(pm.ResizedPath);
            await DeleteFileAsync(pm.Thumbnail);
        }

        /// <summary>
        /// Deletes the file at the provided filepath using PCLStorage.
        /// </summary>
        /// <param name="filepath">The filepath to the file for deletion.</param>
        public async Task DeleteFileAsync(string filepath)
        {
            var file = await FileSystem.Current.GetFileFromPathAsync(filepath);
            try
            {
                await file.DeleteAsync();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}