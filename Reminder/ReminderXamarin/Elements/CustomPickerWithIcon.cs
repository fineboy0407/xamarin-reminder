using ReminderXamarin.Helpers;
using Xamarin.Forms;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// Picker with border and icon at the right corner.
    /// </summary>
    public class CustomPickerWithIcon : Picker
    {
        public static readonly BindableProperty ImageProperty = BindableProperty.Create(nameof(Image),
            typeof(string), typeof(CustomPickerWithIcon), ConstantsHelper.ArrowForwardImage);
        public static BindableProperty PlaceholderColorProperty = BindableProperty.Create(nameof(PlaceholderColor),
            typeof(Color), typeof(CustomPickerWithIcon), Color.DodgerBlue, BindingMode.TwoWay);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor),
            typeof(Color), typeof(CustomPickerWithIcon), Color.DodgerBlue, BindingMode.Default);

        /// <summary>
        /// Image that will be displayed at right corner of the picker.
        /// </summary>
        public string Image
        {
            get => (string)GetValue(ImageProperty);
            set => SetValue(ImageProperty, value);
        }

        /// <summary>
        /// Color of the placeholder.
        /// </summary>
        public Color PlaceholderColor
        {
            get => (Color)GetValue(PlaceholderColorProperty);
            set => SetValue(PlaceholderColorProperty, value);
        }

        /// <summary>
        /// Border color for this picker.
        /// </summary>
        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
    }
}