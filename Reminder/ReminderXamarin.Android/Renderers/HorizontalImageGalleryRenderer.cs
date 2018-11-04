using Android.Content;
using ReminderXamarin.Droid.Renderers;
using ReminderXamarin.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(HorizontalImageGallery), typeof(HorizontalImageGalleryRenderer))]
namespace ReminderXamarin.Droid.Renderers
{
    public class HorizontalImageGalleryRenderer : ScrollViewRenderer
    {
        public HorizontalImageGalleryRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var element = e.NewElement as HorizontalImageGallery;
            element?.Render();
        }
    }
}