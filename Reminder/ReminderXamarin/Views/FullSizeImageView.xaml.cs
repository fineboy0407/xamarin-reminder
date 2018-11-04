using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Views
{
    /// <summary>
    /// This view shows image in full size.
    /// as popup
    /// </summary>
	[XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullSizeImageView : PopupPage
    {
        /// <summary>
        /// Create new instance of <see cref="FullSizeImageView"/>.
        /// </summary>
        /// <param name="imageSource">image source.</param>
        public FullSizeImageView(ImageSource imageSource)
        {
            InitializeComponent();
            Image.Source = imageSource;
        }

        // Close current popup page if user tap outside of the image.
        private async void Background_OnClick(object sender, EventArgs e)
        {
            await Navigation.PopPopupAsync();
        }
    }
}