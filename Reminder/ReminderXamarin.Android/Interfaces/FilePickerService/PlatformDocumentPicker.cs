using System;
using System.IO;
using System.Threading.Tasks;
using Android.Content;
using Android.Provider;
using ReminderXamarin.Droid.Interfaces.FilePickerService;
using ReminderXamarin.Interfaces.FilePickerService;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformDocumentPicker))]
namespace ReminderXamarin.Droid.Interfaces.FilePickerService
{
    /// <inheritdoc />
    /// <summary>
    /// Implement on Android. Copy Platform.cs class to your Android project.
    /// <para>
    /// In MainActivity: Add event of type "int,Result,Intent" named ActivityResult, override OnActivityResult where invoke this event.
    /// <para>
    /// Call Platform.Init() method in MainActivity class
    /// </para>
    /// </para> 
    /// </summary>
    public class PlatformDocumentPicker : IPlatformDocumentPicker
    {
        /// <inheritdoc />
        /// <summary>
        /// Start new activity to user
        /// </summary>
        /// <param name="page">Page from which user have come</param>
        public async Task<PlatformDocument> DisplayImportAsync(Page page)
        {
            var intent = await ShowPickerDialog();
            if (intent != null)
            {
                return await StartActivity(intent);
            }
            return null;
        }

        private static Task<Intent> ShowPickerDialog()
        {
            var taskCompletionSource = new TaskCompletionSource<Intent>();

            var intentFromLibrary = new Intent()
                .SetAction(Intent.ActionGetContent)
                .SetType("*/*")
                .AddCategory(Intent.CategoryOpenable);

            taskCompletionSource.SetResult(intentFromLibrary);
            return taskCompletionSource.Task;
        }

        private Task<PlatformDocument> StartActivity(Intent requestIntent)
        {
            var taskCompletionSource = new TaskCompletionSource<PlatformDocument>();
            Platform.StartActivityForResult(requestIntent, (result, responseIntent) =>
            {
                try
                {
                    if (result != Android.App.Result.Canceled)
                    {
                        var url = responseIntent.Data;
                        if (url != null)
                        {
                            var name = "";
                            var contentResolver = Platform.MainActivity.ContentResolver;
                            using (var cursor = contentResolver.Query(url, new string[] { OpenableColumns.DisplayName }, null, null, null))
                            {
                                if (cursor?.MoveToFirst() ?? false)
                                {
                                    var columnIndex = cursor.GetColumnIndex(OpenableColumns.DisplayName);
                                    name = cursor.IsNull(columnIndex) ? "" : cursor.GetString(columnIndex);
                                }
                            }
                            if (string.IsNullOrEmpty(name))
                            {
                                name = url.LastPathSegment;
                            }
                            var path = Path.GetTempFileName();
                            using (var dataStream = Platform.MainActivity.ContentResolver.OpenInputStream(url))
                            using (var fileStream = File.OpenWrite(path))
                            {
                                dataStream.CopyTo(fileStream);
                            }
                            taskCompletionSource.SetResult(new PlatformDocument(
                                name: name,
                                path: path
                            ));
                            return;
                        }
                    }
                    taskCompletionSource.SetResult(null);
                }
                catch (Exception e)
                {
                    taskCompletionSource.SetException(e);
                }
            });
            return taskCompletionSource.Task;
        }
    }
}