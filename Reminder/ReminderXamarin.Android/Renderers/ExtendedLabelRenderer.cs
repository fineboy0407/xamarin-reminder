using System.ComponentModel;
using Android.Content;
using Android.Graphics;
using Android.Widget;
using ReminderXamarin.Droid.Renderers;
using ReminderXamarin.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ExtendedLabel), typeof(ExtendedLabelRenderer))]
namespace ReminderXamarin.Droid.Renderers
{
    /// <summary>
    /// Renderer for <see cref="ExtendedLabel"/>
    /// </summary>
    public class ExtendedLabelRenderer : LabelRenderer
    {
        protected ExtendedLabel LabelElement { get; private set; }

        public ExtendedLabelRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                LabelElement = Element as ExtendedLabel;
            }

            if (Control != null && LabelElement != null && e.NewElement != null)
            {
                var lineSpacing = LabelElement.LineSpacing;
                Control.SetLineSpacing(1f, (float)lineSpacing);
                Control.SetSingleLine(false);
                Control.SetMaxLines(LabelElement.Lines);
                UpdateUi(LabelElement, Control);
                UpdateLayout();
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            base.OnElementPropertyChanged(sender, e);

            if (Element is ExtendedLabel view)
            {
                if (e.PropertyName == ExtendedLabel.IsUnderlinedProperty.PropertyName)
                {
                    Control.PaintFlags = view.IsUnderlined ? Control.PaintFlags | PaintFlags.UnderlineText : Control.PaintFlags &= ~PaintFlags.UnderlineText;
                }
            }
        }

        private static void UpdateUi(ExtendedLabel view, TextView control)
        {
            if (view.FontSize > 0)
            {
                control.TextSize = (float)view.FontSize;
            }

            if (view.IsUnderlined)
            {
                control.PaintFlags = control.PaintFlags | PaintFlags.UnderlineText;
            }
        }
    }
}