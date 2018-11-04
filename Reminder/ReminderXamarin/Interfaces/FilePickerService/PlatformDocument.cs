namespace ReminderXamarin.Interfaces.FilePickerService
{
    /// <summary>
    /// A picked document.
    /// </summary>
    public class PlatformDocument
    {
        /// <summary>
        /// Document name.
        /// </summary>
        public readonly string Name;
        /// <summary>
        /// Full path to a document.
        /// </summary>
        public readonly string Path;

        public PlatformDocument(string name, string path)
        {
            Name = name;
            Path = path;
        }
    }
}