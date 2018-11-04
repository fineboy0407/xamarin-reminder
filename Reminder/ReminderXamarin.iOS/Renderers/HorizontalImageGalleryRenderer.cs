using ReminderXamarin.Elements;
using ReminderXamarin.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(HorizontalImageGallery), typeof(HorizontalImageGalleryRenderer))]
namespace ReminderXamarin.iOS.Renderers
{
    public class HorizontalImageGalleryRenderer : ScrollViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement as HorizontalImageGallery;
            element?.Render();
        }
    }
}