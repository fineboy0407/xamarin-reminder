using System;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Support.V4.Content;
using Android.Text;
using Android.Util;
using ReminderXamarin.Droid.Renderers;
using ReminderXamarin.Elements;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomPickerWithIcon), typeof(CustomPickerWithIconRenderer))]
namespace ReminderXamarin.Droid.Renderers
{
    /// <summary>
    /// Renderer for <see cref="CustomPickerWithIcon" />
    /// </summary>
    public class CustomPickerWithIconRenderer : PickerRenderer
    {
        private CustomPickerWithIcon _element;
        private ShapeDrawable _borderShape;

        public CustomPickerWithIconRenderer(Context context) : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Picker> e)
        {
            base.OnElementChanged(e);
            _element = Element as CustomPickerWithIcon;

            if (Control != null && Element != null && !string.IsNullOrEmpty(_element?.Image))
            {
                _borderShape = new ShapeDrawable(new Android.Graphics.Drawables.Shapes.RoundRectShape(new[]
                {
                    (float)0,
                    (float)0,
                    (float)0,
                    (float)0,
                    (float)0,
                    (float)0,
                    (float)0,
                    (float)0
                }, null, null));

                var paint = new Paint(PaintFlags.AntiAlias)
                {
                    Color = _element.BorderColor.ToAndroid(),
                    StrokeWidth = 2.5f,
                    StrokeMiter = 10f
                };

                _borderShape.Paint.Set(paint);
                _borderShape.Paint.SetStyle(Paint.Style.Stroke);
                Background = _borderShape;

                Control.TextSize = 16;

                Control.InputType = InputTypes.TextFlagNoSuggestions;
                Control.SetHintTextColor(_element.PlaceholderColor.ToAndroid());

                Control.SetBackground(AddPickerStyles(_element.Image));
                Control.SetPadding((int)DpToPixels(Context, Convert.ToSingle(12)), (int)DpToPixels(Context, Convert.ToSingle(12)),
                    (int)DpToPixels(Context, Convert.ToSingle(12)), Control.PaddingBottom);
            }
        }

        public LayerDrawable AddPickerStyles(string imagePath)
        {
            Drawable[] layers = { GetDrawable(imagePath) };
            LayerDrawable layerDrawable = new LayerDrawable(layers);
            layerDrawable.SetLayerInset(0, 0, 0, 20, 0);

            return layerDrawable;
        }

        private BitmapDrawable GetDrawable(string imagePath)
        {
            var px = (int)TypedValue.ApplyDimension(ComplexUnitType.Dip, 20, Resources.DisplayMetrics);
            imagePath = imagePath.Replace(".png", "").Replace(".jpg", "").Replace(".jpeg", "");
            var resourceId = (int)typeof(Resource.Drawable).GetField(imagePath).GetValue(null);
            var drawable = ContextCompat.GetDrawable(Context, resourceId);
            var bitmap = ((BitmapDrawable)drawable).Bitmap;

            var result = new BitmapDrawable(Resources, Bitmap.CreateScaledBitmap(bitmap, px, px, true));
            result.Gravity = Android.Views.GravityFlags.Right;

            return result;
        }

        public static float DpToPixels(Context context, float valueInDp)
        {
            DisplayMetrics metrics = context.Resources.DisplayMetrics;
            return TypedValue.ApplyDimension(ComplexUnitType.Dip, valueInDp, metrics);
        }
    }
}