using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Util;
using ReminderXamarin.Droid.Renderers;
using ReminderXamarin.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(EntryWithBorder), typeof(EntryWithBorderRenderer))]
namespace ReminderXamarin.Droid.Renderers
{
    /// <summary>
    /// Renderer for <see cref="EntryWithBorder"/>
    /// </summary>
    public class EntryWithBorderRenderer : EntryRenderer
    {
        private ShapeDrawable _borderShape;

        public EntryWithBorderRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.NewElement != null && Element != null && Control != null)
            {
                var view = Element as EntryWithBorder;

                _borderShape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RoundRectShape(new[]
                {
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5
                }, null, new[]
                {
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5,
                    (float)5
                }));

                var paint = new Paint(PaintFlags.AntiAlias)
                {
                    Color = view.BorderColor.ToAndroid(),
                    StrokeWidth = 2.5f,
                    StrokeMiter = 10f
                };

                _borderShape.Paint.Set(paint);
                _borderShape.Paint.SetStyle(Paint.Style.Stroke);
                Background = _borderShape;

                var gradientBackground = new GradientDrawable();
                gradientBackground.SetShape(ShapeType.Rectangle);
                gradientBackground.SetColor(view.BackgroundColor.ToAndroid());

                Control.SetBackground(gradientBackground);

                Control.SetPadding((int)DpToPixels(Context, Convert.ToSingle(12)), Control.PaddingTop,
                    (int)DpToPixels(Context, Convert.ToSingle(12)), Control.PaddingBottom);
            }
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}