using System;
using System.Globalization;
using ReminderXamarin.Models;
using Xamarin.Forms;

namespace ReminderXamarin.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// Convert priority to image source.
    /// </summary>
    public class PriorityToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var priority = (ToDoPriority) value;
            if (priority == ToDoPriority.High)
            {
                return "warning_high.png";
            }
            if (priority == ToDoPriority.Medium)
            {
                return "warning_medium.png";
            }
            return "warning_low.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var imageSource = (string) value;
            if (imageSource == "warning_high.png")
            {
                return ToDoPriority.High;
            }
            if (imageSource == "warning_medium.png")
            {
                return ToDoPriority.Medium;
            }
            return ToDoPriority.Low;
        }
    }
}