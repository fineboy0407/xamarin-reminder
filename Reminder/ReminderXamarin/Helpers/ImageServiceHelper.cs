using ReminderXamarin.Interfaces;
using Xamarin.Forms;

namespace ReminderXamarin.Helpers
{
    /// <summary>
    /// Helper class, calling implementaion of the <see cref="T:MyDiary.Interfaces.IImageService"/>.
    /// </summary>
    public static class ImageServiceHelper
    {
        private static readonly IImageService ImageService = DependencyService.Get<IImageService>();

        /// <summary>
        /// Resizes the image at source file with the requested width and height and stores it at the provided target.
        /// </summary>
        /// <param name="sourceFile">Source file.</param>
        /// <param name="targetFile">Target file.</param>
        /// <param name="requiredWidth">Required width.</param>
        /// <param name="requiredHeight">Required height.</param>
        public static void ResizeImage(string sourceFile, string targetFile, int requiredWidth, int requiredHeight)
        {
            ImageService.ResizeImage(sourceFile, targetFile, requiredWidth, requiredHeight);
        }
    }
}