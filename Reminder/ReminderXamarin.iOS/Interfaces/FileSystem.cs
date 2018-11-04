using System.IO;
using ReminderXamarin.iOS.Interfaces;
using ReminderXamarin.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileSystem))]
namespace ReminderXamarin.iOS.Interfaces
{
    /// <summary>
    /// Implementation of <see cref="IFileSystem"/> for iOS.
    /// </summary>
    public class FileSystem : IFileSystem
    {
        public byte[] ReadAllBytes(string path)
        {
            return File.ReadAllBytes(path);
        }
    }
}