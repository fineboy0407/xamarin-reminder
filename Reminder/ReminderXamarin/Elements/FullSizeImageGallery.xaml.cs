using System.Collections.Generic;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Elements
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FullSizeImageGallery : PopupPage
    {
        /// <summary>
        /// Create new instance of <see cref="FullSizeImageGallery"/>
        /// </summary>
        /// <param name="images">collection of images for gallery.</param>
        /// <param name="selectedImage">current image to be displayed when gallery open.</param>
        public FullSizeImageGallery(IEnumerable<Image> images, Image selectedImage)
        {
            InitializeComponent();
            GalleryView.ItemsSource = images;
            GalleryView.CurrentImage = selectedImage;
        }
    }
}