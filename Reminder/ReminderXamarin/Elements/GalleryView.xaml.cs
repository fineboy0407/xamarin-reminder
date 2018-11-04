using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// Contains Stack layout with image gallery. Provide ItemsSource, ItemTemplate and CurrentImage
    /// properties.
    /// </summary>
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GalleryView : ContentView
    {
        private ImageGallery _gallery;
        private bool _isInitialized;

        public GalleryView()
        {
            InitializeComponent();
        }

        public static readonly BindableProperty ItemsSourceProperty =
            BindableProperty.Create(nameof(ItemsSource),
                typeof(IEnumerable<Image>),
                typeof(GalleryView),
                null);

        public static readonly BindableProperty ItemTemplateProperty =
            BindableProperty.Create(nameof(ItemTemplate),
                typeof(DataTemplate),
                typeof(GalleryView),
                null);

        public static readonly BindableProperty CurrentImageProperty =
            BindableProperty.Create(nameof(CurrentImage),
                typeof(Image),
                typeof(GalleryView),
                null);

        /// <summary>
        /// Set current image to be displayed.
        /// </summary>
        public Image CurrentImage { get; set; }

        /// <summary>
        /// List of <seealso cref="Image"/> as item source for image gallery.
        /// </summary>
        public IEnumerable<Image> ItemsSource
        {
            get => (IEnumerable<Image>)GetValue(ItemsSourceProperty);
            set => SetValue(ItemsSourceProperty, value);
        }

        /// <summary>
        /// Item template for image gallery.
        /// </summary>
        public DataTemplate ItemTemplate
        {
            get => (DataTemplate)GetValue(ItemTemplateProperty);
            set
            {
                SetValue(ItemsSourceProperty, value);
                _gallery.ItemTemplate = value;
            }
        }

        protected override void OnPropertyChanged(string propertyName = null)
        {
            base.OnPropertyChanged(propertyName);

            if (!_isInitialized)
            {
                _gallery = new ImageGallery(new ObservableCollection<Image>());
                _isInitialized = true;
            }

            if (propertyName == nameof(ItemsSource))
            {
                _gallery.Images = new ObservableCollection<Image>(ItemsSource);

                _gallery.ImageChanged += GalleryOnImageChanged;
                CarouselViewContainer.Children.Add(_gallery);
            }
            else if (propertyName == nameof(ItemTemplate))
            {
                _gallery.ItemTemplate = ItemTemplate;
            }
            else if (propertyName == nameof(CurrentImage))
            {
                if (CurrentImage != null)
                {
                    _gallery.SetCurrentPosition(GetIndexOfImage(CurrentImage));
                }
            }
        }

        private void GalleryOnImageChanged(object sender, int number)
        {
            CurrentImage = ItemsSource.ElementAt(number);
        }

        // Returns index of passed image in ItemsSource collection.
        // Comparing by image.Source property since its relatively unique value.
        // If nothing find return 0;
        private int GetIndexOfImage(Image image)
        {
            FileImageSource fileImageSource = (FileImageSource)image.Source;
            string imagePath = fileImageSource.File;

            for (int i = 0; i < ItemsSource.Count(); i++)
            {
                string comparableImagePath = ((FileImageSource) ItemsSource.ElementAt(i).Source).File;
                if (imagePath == comparableImagePath)
                {
                    return i;
                }
            }
            return 0;
        }
    }
}