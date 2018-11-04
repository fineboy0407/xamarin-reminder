using System;
using System.IO;
using System.Threading.Tasks;
using Foundation;
using MobileCoreServices;
using Photos;
using ReminderXamarin.iOS.Interfaces.FilePickerService;
using ReminderXamarin.Interfaces.FilePickerService;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PlatformDocumentPicker))]
namespace ReminderXamarin.iOS.Interfaces.FilePickerService
{
    /// <inheritdoc />
    /// <summary>
    /// Implementaion of <see cref="IPlatformDocumentPicker"/> for iOS. 
    /// <para>
    /// Copy PageExtensions and PageRenderer to your project to get PageRenderer (required for present view controller).
    /// </para> 
    /// </summary>
    public class PlatformDocumentPicker : IPlatformDocumentPicker
    {
        private static readonly string[] allUTTypes =
            { UTType.Item, UTType.Content, UTType.CompositeContent, UTType.Application,
            UTType.Message, UTType.Contact, UTType.Archive, UTType.DiskImage, UTType.Data };

        #region IPlatformDocumentPicker implementation

        public Task<PlatformDocument> DisplayImportAsync(Page page)
        {
            var taskCompletionSource = new TaskCompletionSource<PlatformDocument>();

            if (page == null)
            {
                throw new ArgumentException("Provided page doesn't inherit Xamarin.Forms.Page.");
            }
            PageRenderer renderer = page.GetRenderer();

            var docPicker = new UIDocumentPickerViewController(allUTTypes, UIDocumentPickerMode.Import);
            docPicker.DidPickDocument += (sender, e) =>
            {
                CompleteTaskUsing(taskCompletionSource, e.Url);
            };
            docPicker.DidPickDocumentAtUrls += (sender, e) =>
            {
                CompleteTaskUsing(taskCompletionSource, e?.Urls[0]);
            };
            docPicker.WasCancelled += (sender, e) =>
            {
                taskCompletionSource.SetResult(null);
            };

            renderer.PresentViewController(docPicker, true, null);
            var presentationPopover = docPicker.PopoverPresentationController;
            if (presentationPopover != null)
            {
                presentationPopover.SourceView = renderer.View;
                presentationPopover.PermittedArrowDirections = 0;
                presentationPopover.SourceRect = renderer.View.Frame;
            }

            return taskCompletionSource.Task;
        }

        #endregion

        private void CompleteTaskUsing(TaskCompletionSource<PlatformDocument> taskCompletionSource, UIImagePickerMediaPickedEventArgs args)
        {
            if (args.MediaUrl != null)
            {
                CompleteTaskUsing(taskCompletionSource, args);
                return;
            }
            try
            {
                string imageName = null;
                {
                    var url = args.ReferenceUrl;
                    if (url != null)
                    {
                        var assets = PHAsset.FetchAssets(new NSUrl[] { url }, null);
                        if (assets.Count >= 1)
                        {
                            var asset = assets.firstObject as PHAsset;
                            var dateFormatter = new NSDateFormatter()
                            {
                                DateFormat = "yyyy-MM-dd HH:mm:ss",
                            };
                            imageName = dateFormatter.ToString(asset.CreationDate);
                        }
                    }
                }
                imageName = imageName ?? DateTime.UtcNow.ToString();

                string path;
                using (var data = (args.OriginalImage as UIImage).AsJPEG())
                {
                    path = WriteToTemporaryFile(data);
                }
                taskCompletionSource.SetResult(new PlatformDocument(imageName + ".jpg", path));
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
        }

        private void CompleteTaskUsing(TaskCompletionSource<PlatformDocument> taskCompletionSource, NSUrl url)
        {
            try
            {
                string path;
                using (var data = NSData.FromFile(url.Path, NSDataReadingOptions.Mapped, out NSError error))
                {
                    if (error == null)
                    {
                        path = WriteToTemporaryFile(data);
                    }
                    else
                    {
                        taskCompletionSource.SetException(new IOException(error.LocalizedDescription));
                        return;
                    }
                }
                taskCompletionSource.SetResult(new PlatformDocument(url.LastPathComponent, path));
            }
            catch (Exception e)
            {
                taskCompletionSource.SetException(e);
            }
        }

        private string WriteToTemporaryFile(NSData data)
        {
            var path = Path.GetTempFileName();
            using (var stream = File.OpenWrite(path))
            {
                data.AsStream()
                    .CopyTo(stream);
            }
            return path;
        }
    }
}