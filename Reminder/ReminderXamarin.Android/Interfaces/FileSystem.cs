using System;
using System.IO;
using ReminderXamarin.Droid.Interfaces;
using ReminderXamarin.Interfaces;
using Xamarin.Forms;

[assembly: Dependency(typeof(FileSystem))]
namespace ReminderXamarin.Droid.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="IFileSystem"/> for Android.
    /// </summary>
    public class FileSystem : IFileSystem
    {
        public byte[] ReadAllBytes(string path)
        {
            try
            {
                return File.ReadAllBytes(path);
            }

            catch (Exception e)
            {
                Console.WriteLine(e);
                return new byte[0];
            }
        }
    }
}