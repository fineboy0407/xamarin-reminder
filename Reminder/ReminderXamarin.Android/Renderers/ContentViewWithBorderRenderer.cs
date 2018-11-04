using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using ReminderXamarin.Droid.Renderers;
using ReminderXamarin.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(ContentViewWithBorder), typeof(ContentViewWithBorderRenderer))]
namespace ReminderXamarin.Droid.Renderers
{
    public class ContentViewWithBorderRenderer : VisualElementRenderer<ContentView>
    {
        private ShapeDrawable _borderShape;

        public ContentViewWithBorderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<ContentView> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                return;
            }

            if (e.NewElement != null)
            {
                var element = e.NewElement as ContentViewWithBorder;
                _borderShape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RoundRectShape(new[] { (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius,
                                                                                                                    (float)element.CornerRadius }, null, null));
                var paint = new Paint(PaintFlags.AntiAlias)
                {
                    Color = element.BorderColor.ToAndroid(),
                    StrokeWidth = (float)element.BorderWidth * 2.5f,
                    StrokeMiter = 10f
                };

                _borderShape.Paint.Set(paint);
                _borderShape.Paint.SetStyle(Paint.Style.Stroke);

                Background = _borderShape;
            }
        }
    }
}