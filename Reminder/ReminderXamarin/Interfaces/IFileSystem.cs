namespace ReminderXamarin.Interfaces
{
    /// <summary>
    /// Provide access to files in file system.
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// Read all bytes from file.
        /// </summary>
        /// <param name="path">Path to file.</param>
        byte[] ReadAllBytes(string path);
    }
}