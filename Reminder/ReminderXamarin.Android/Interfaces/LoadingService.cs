using Android.Graphics;
using Android.Views;
using Android.Widget;
using ReminderXamarin.Droid.Interfaces;
using Plugin.CurrentActivity;
using ReminderXamarin.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(LoadingService))]
namespace ReminderXamarin.Droid.Interfaces
{
    /// <inheritdoc />
    /// <summary>
    /// Implementation of <see cref="ILoadingService" /> for Android.
    /// </summary>
    public class LoadingService : ILoadingService
    {
        private RelativeLayout _relLayout;
        private ProgressBar _bar;

        /// <inheritdoc />
        /// <summary>
        /// Create layout with loading indicator and message, place it in a top of current activity view
        /// and make it visible.
        /// </summary>
        public void ShowLoading(string message = null)
        {
            if (_relLayout != null)
            {
                _relLayout.Visibility = ViewStates.Invisible;
            }

            FrameLayout layout = (FrameLayout)CrossCurrentActivity.Current.Activity.Window.DecorView.FindViewById(Android.Resource.Id.Content);
            _relLayout = new RelativeLayout(CrossCurrentActivity.Current.Activity) { LayoutParameters = layout.LayoutParameters };
            _relLayout.SetBackgroundColor(Color.Black);
            _relLayout.Alpha = 0.5F;
            _relLayout.Click += null;

            _bar = new ProgressBar(CrossCurrentActivity.Current.Activity)
            {
                Indeterminate = true,
                Visibility = ViewStates.Visible,
                Id = 231236123
            };
            _bar.IndeterminateDrawable.SetColorFilter(Color.White, PorterDuff.Mode.SrcIn);

            var param1 = new RelativeLayout.LayoutParams(100, 100);
            param1.AddRule(LayoutRules.CenterInParent);
            _relLayout.AddView(_bar, param1);

            var textView = new TextView(CrossCurrentActivity.Current.Activity)
            {
                Text = message ?? "Loading",
                TextSize = 14
            };
            textView.SetTextColor(Color.White);
            var param2 = new RelativeLayout.LayoutParams(ViewGroup.LayoutParams.WrapContent, ViewGroup.LayoutParams.WrapContent);
            param2.AddRule(LayoutRules.Below, _bar.Id);
            param2.AddRule(LayoutRules.CenterHorizontal);
            _relLayout.AddView(textView, param2);

            layout.AddView(_relLayout, layout.LayoutParameters);

            _relLayout.Visibility = ViewStates.Visible;
        }

        /// <inheritdoc />
        /// <summary>
        /// Set visibility of layout with loading indicator and text to false
        /// </summary>
        public void HideLoading()
        {
            _relLayout.Click -= null;
            if (_relLayout.Visibility == ViewStates.Visible)
            {
                _relLayout.Visibility = ViewStates.Invisible;
            }
        }
    }
}