using System;
using System.Globalization;
using Xamarin.Forms;

namespace ReminderXamarin.Converters
{
    /// <inheritdoc />
    /// <summary>
    /// Convert number to color depends on number range.
    /// </summary>
    public class NumberToColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var number = (int)value;

            if (number <= 250)
            {
                // Red
                return Color.FromHex("#FF3838");
            }
            if (number <= 500)
            {
                // Light red
                return Color.FromHex("#FF9B9B");
            }
            else if (number > 500 && number < 1000)
            {
                // Orange
                return Color.FromHex("#FF632E");
            }
            else if (number >= 1000 && number < 2000)
            {
                // Light yellow
                return Color.FromHex("#FFAC2E");
            }
            else if (number >= 2000 && number < 5000)
            {
                // Light green
                return Color.FromHex("#10CC00");
            }
            else if (number > 5000 && number < 10000)
            {
                // Green
                return Color.FromHex("#097A00");
            }
            else
            {
                // Black
                return Color.FromHex("#2A2A2A");
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}