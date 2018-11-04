using System.Drawing;
using CoreGraphics;
using ReminderXamarin.iOS.Interfaces;
using ReminderXamarin.Interfaces;
using UIKit;

[assembly: Xamarin.Forms.Dependency(typeof(LoadingService))]
namespace ReminderXamarin.iOS.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="ILoadingService" /> for iOS.
    /// </summary>
    public class LoadingService : ILoadingService
    {
        private LoadingOverlay _loadingOverlay;

        public void ShowLoading(string message = null)
        {
            _loadingOverlay?.Hide();
            _loadingOverlay = new LoadingOverlay(UIApplication.SharedApplication.KeyWindow.RootViewController.View.Bounds, message ?? string.Empty);
            UIApplication.SharedApplication.KeyWindow.RootViewController.View.Add(_loadingOverlay);
        }

        public void HideLoading()
        {
            _loadingOverlay.Hide();
        }
    }

    public sealed class LoadingOverlay : UIView
    {
        // control declarations
        private readonly UIActivityIndicatorView _activitySpinner;

        public LoadingOverlay(CGRect frame, string message) : base(frame)
        {
            // Configurable bits.
            BackgroundColor = UIColor.Black;
            Alpha = 0.75f;
            AutoresizingMask = UIViewAutoresizing.FlexibleDimensions;

            float labelHeight = 22;
            float labelWidth = (float)(Frame.Width - 20);

            // Derive the center x and y.
            float centerX = (float)(Frame.Width / 2);
            float centerY = (float)(Frame.Height / 2);

            // Create the activity spinner, center it horizontall and put it 5 points above center x
            _activitySpinner = new UIActivityIndicatorView(UIActivityIndicatorViewStyle.WhiteLarge);
            _activitySpinner.Frame = new RectangleF(
                (float)(centerX - (_activitySpinner.Frame.Width / 2)),
                (float)(centerY - _activitySpinner.Frame.Height - 20),
                (float)_activitySpinner.Frame.Width,
                (float)_activitySpinner.Frame.Height);
            _activitySpinner.AutoresizingMask = UIViewAutoresizing.FlexibleMargins;
            AddSubview(_activitySpinner);
            _activitySpinner.StartAnimating();

            // Create and configure the "Loading Data" label.
            var loadingLabel = new UILabel(new RectangleF(
                centerX - (labelWidth / 2),
                centerY + 20,
                labelWidth,
                labelHeight
            ))
            {
                BackgroundColor = UIColor.Clear,
                TextColor = UIColor.White,
                Text = string.IsNullOrEmpty(message) ? "Loading..." : message,
                TextAlignment = UITextAlignment.Center,
                AutoresizingMask = UIViewAutoresizing.FlexibleMargins
            };
            AddSubview(loadingLabel);
        }

        /// <summary>
        /// Fades out the control and then removes it from the super view.
        /// </summary>
        public void Hide()
        {
            UIView.Animate(
                0.5, // duration
                () => { Alpha = 0; },
                () => { RemoveFromSuperview(); }
            );
        }
    };
}