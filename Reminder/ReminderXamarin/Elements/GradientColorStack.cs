using Xamarin.Forms;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// Gradient stack layout.
    /// </summary>
    public class GradientColorStack : StackLayout
    {
        /// <summary>
        /// Gradient start color.
        /// </summary>
        public Color StartColor { get; set; } = Color.FromHex("#0DBDBD");
        /// <summary>
        /// Gradient end color.
        /// </summary>
        public Color EndColor { get; set; } = Color.FromHex("#0068A0");
    }
}