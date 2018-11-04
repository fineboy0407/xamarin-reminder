namespace ReminderXamarin.Interfaces
{
    /// <summary>
    /// Interface for resizing images.
    /// </summary>
    public interface IImageService
    {
        /// <summary>
        /// Resizes the image at sourceFile with the requested width and height and stores it at the provided target.
        /// </summary>
        /// <param name="sourceFile">Source file.</param>
        /// <param name="targetFile">Target file.</param>
        /// <param name="requiredWidth">Required width.</param>
        /// <param name="requiredHeight">Required height.</param>
        void ResizeImage(string sourceFile, string targetFile, int requiredWidth, int requiredHeight);
    }
}