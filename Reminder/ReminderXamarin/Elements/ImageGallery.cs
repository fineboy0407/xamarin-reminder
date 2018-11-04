using System;
using System.Collections.ObjectModel;
using ReminderXamarin.Helpers;
using ReminderXamarin.Interfaces;
using Xamarin.Forms;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// <see cref="ImageGallery"/> extends <see cref="StackLayout"/> and takes collection of <see cref="Image"/> in
    /// constructor as parameter. This class uses <see cref="CarouselView"/> to draw horizontal set of images
    /// that could be changed by swipe.
    /// </summary>
    public class ImageGallery : StackLayout
    {
        // Carousel.Position property doesn't show correct value, so here is current element position number
        private int _currentPosition;
        private readonly CarouselView _carousel;
        private static readonly IAlertService AlertService = DependencyService.Get<IAlertService>();

        public ImageGallery(ObservableCollection<Image> images)
        {
            HorizontalOptions = LayoutOptions.FillAndExpand;
            VerticalOptions = LayoutOptions.FillAndExpand;

            _carousel = new CarouselView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };

            Images = images;
            _carousel.ItemsSource = images;
            _carousel.PositionSelected += OnImageChanged;

            Children.Add(_carousel);
            AddOptionsToAllImages();
        }

        private void AddOptionsToAllImages()
        {
            var deleteImage = new Image
            {
                Source = ConstantsHelper.DeleteImageSource,
                HeightRequest = 20
            };
            var deleteGestureRecognizer = new TapGestureRecognizer();
            // Taping on "delete" image will delete current image after user confirm it.
            deleteGestureRecognizer.Tapped += async (sender, args) =>
            {
                bool result = await AlertService.ShowYesNoAlert(ConstantsHelper.AreYouSure, ConstantsHelper.Yes, ConstantsHelper.No);
                if (result)
                {
                    Images.RemoveAt(_currentPosition);
                    MessagingCenter.Send(this, ConstantsHelper.ImageDeleted, _currentPosition);
                }
            };
            deleteImage.GestureRecognizers.Add(deleteGestureRecognizer);
            Children.Add(deleteImage);
        }

        /// <summary>
        /// Collection of <seealso cref="Image"/> as item source for image gallery.
        /// </summary>
        public ObservableCollection<Image> Images
        {
            get => (ObservableCollection<Image>)_carousel.ItemsSource;
            set => _carousel.ItemsSource = value;
        }

        /// <summary>
        /// Item template for image gallery.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get => _carousel.ItemTemplate;
            set => _carousel.ItemTemplate = value;
        }

        public event EventHandler<int> ImageChanged;

        /// <summary>
        /// Display current image gallery element by number.
        /// </summary>
        /// <param name="position">number of element to be displayed.</param>
        public void SetCurrentPosition(int position)
        {
            _carousel.Position = position;
            _currentPosition = position;
        }

        private void OnImageChanged(object sender, SelectedPositionChangedEventArgs e)
        {
            // Get the selected page
            _currentPosition = (int) e.SelectedPosition;
            ImageChanged?.Invoke(this, _currentPosition);
        }
    }
}