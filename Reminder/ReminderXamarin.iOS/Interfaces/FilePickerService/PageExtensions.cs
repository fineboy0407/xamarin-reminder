using Xamarin.Forms;

namespace ReminderXamarin.iOS.Interfaces.FilePickerService
{
    /// <summary>
    /// Required for PlatformDocumentPicker for iOS.
    /// <para>
    /// Get Renderer for page.
    /// </para>
    /// </summary>
    public static class PageExtensions
    {
        /// <summary>
        /// Get renderer associated with this page, if any.
        /// </summary>
        public static PageRenderer GetRenderer(this Page page)
        {
            PageRenderer pageRenderer;
            if (PageRenderer.Renderers.TryGetValue(page, out pageRenderer))
            {
                return pageRenderer;
            }
            return null;
        }
    }
}