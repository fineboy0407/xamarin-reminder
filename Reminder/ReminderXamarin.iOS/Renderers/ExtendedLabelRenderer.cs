using System;
using System.ComponentModel;
using Foundation;
using ReminderXamarin.Elements;
using ReminderXamarin.iOS.Renderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace ReminderXamarin.iOS.Renderers
{
    /// <summary>
    /// Renderer for <see cref="ExtendedLabel"/>
    /// </summary>
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var view = Element as ExtendedLabel;

                var paragraphStyle = new NSMutableParagraphStyle
                {
                    LineSpacing = (nfloat)view.LineSpacing
                };
                var str = new NSMutableAttributedString(view.Text);
                var style = UIStringAttributeKey.ParagraphStyle;
                var range = new NSRange(0, str.Length);

                str.AddAttribute(style, paragraphStyle, range);
                Control.Lines = view.Lines;
                Control.AttributedText = str;

                UpdateUi(view, Control);
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);
            var view = Element as ExtendedLabel;

            if (e.PropertyName == ExtendedLabel.IsUnderlinedProperty.PropertyName)
            {
                UpdateUi(view, Control);
            }
        }

        private static void UpdateUi(ExtendedLabel view, UILabel control)
        {
            var attrString = new NSMutableAttributedString(control.Text);

            if (view.IsUnderlined)
            {
                attrString.AddAttribute(UIStringAttributeKey.UnderlineStyle,
                    NSNumber.FromInt32((int)NSUnderlineStyle.Single),
                    new NSRange(0, attrString.Length));
            }

            control.AttributedText = attrString;
        }
    }
}