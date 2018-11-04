using Foundation;
using ReminderXamarin.Elements;
using ReminderXamarin.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomPickerWithIcon), typeof(CustomPickerWithIconRenderer))]
namespace ReminderXamarin.iOS.Renderers
{
    /// <summary>
    /// Renderer for <see cref="CustomPickerWithIcon" />
    /// </summary>
    public class CustomPickerWithIconRenderer : PickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);

            var element = Element as CustomPickerWithIcon;

            if (Control != null && Element != null && !string.IsNullOrEmpty(element?.Image))
            {
                var arrow = UIImage.FromBundle(element.Image);
                Control.RightViewMode = UITextFieldViewMode.Always;

                UIColor color = element.PlaceholderColor.ToUIColor();
                if (element.Title != null)
                {
                    var placeholderAttributes = new NSAttributedString(element.Title, new UIStringAttributes { ForegroundColor = color });
                    Control.AttributedPlaceholder = placeholderAttributes;
                }

                var image = new UIImageView(arrow);
                image.ContentMode = UIViewContentMode.Center;
                Control.RightView = image;
                Control.RightView.Frame = new CoreGraphics.CGRect(0, 0, 50, Bounds.Height);

                Control.Layer.BorderColor = element.BorderColor.ToCGColor();
                Control.Layer.BorderWidth = 1;
                Control.ClipsToBounds = true;

                Layer.CornerRadius = 0.0f;
                Layer.MasksToBounds = true;
            }
        }
    }
}