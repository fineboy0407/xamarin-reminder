using System.Threading.Tasks;
using Xamarin.Forms;

namespace ReminderXamarin.Interfaces.FilePickerService
{
    /// <summary>
    /// Allows pick a document available on the device.
    /// <para>
    /// Implement this interface on Android and iOS
    /// </para>
    /// </summary>
    public interface IPlatformDocumentPicker
    {
        /// <summary>
        /// Calling this method will open device's file explorer
        /// and allow pick a document.
        /// <para>
        /// If nothing picked return null.
        /// </para>
        /// </summary>
        /// <param name="page">Page from which opens explorer.</param>
        Task<PlatformDocument> DisplayImportAsync(Page page);
    }
}