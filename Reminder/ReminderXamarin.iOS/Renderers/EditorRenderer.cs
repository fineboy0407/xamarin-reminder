using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using EditorRenderer = ReminderXamarin.iOS.Renderers.EditorRenderer;

[assembly: ExportRenderer(typeof(Editor), typeof(EditorRenderer))]
namespace ReminderXamarin.iOS.Renderers
{
    public class EditorRenderer : Xamarin.Forms.Platform.iOS.EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
        {
            base.OnElementChanged(e);
            Control.AutocapitalizationType = UITextAutocapitalizationType.Sentences;
        }
    }
}