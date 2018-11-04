using System.Drawing;
using CoreAnimation;
using CoreGraphics;
using ReminderXamarin.Elements;
using ReminderXamarin.iOS.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(GradientColorStack), typeof(GradientColorStackRenderer))]
namespace ReminderXamarin.iOS.Renderers
{
    /// <summary>
    /// Renderer for <see cref="GradientColorStack"/>
    /// </summary>
    public class GradientColorStackRenderer : VisualElementRenderer<StackLayout>
    {
        public override void Draw(CGRect rect)
        {
            base.Draw(rect);
            GradientColorStack stack = Element as GradientColorStack;
            CGColor startColor = stack?.StartColor.ToCGColor();
            CGColor endColor = stack?.EndColor.ToCGColor();

            var gradientLayer = new CAGradientLayer();
            #region gradient direction
            var startPoint = new PointF
            {
                X = 0,
                Y = 1
            };
            var endPoint = new PointF
            {
                X = 1,
                Y = 0
            };
            #endregion
            gradientLayer.StartPoint = startPoint;
            gradientLayer.EndPoint = endPoint;
            gradientLayer.Frame = rect;
            gradientLayer.Colors = new[] { startColor, endColor };

            NativeView.Layer.InsertSublayer(gradientLayer, 0);
        }
    }
}