namespace ReminderXamarin.Interfaces
{
    /// <summary>
    /// Interface for retrieving files.
    /// </summary>
    public interface IFileHelper
    {
        /// <summary>
        /// Gets the file path with included filename.
        /// </summary>
        /// <returns>The file path.</returns>
        /// <param name="filename">Filename.</param>
        string GetLocalFilePath(string filename);
    }
}