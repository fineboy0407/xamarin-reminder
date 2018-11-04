using Xamarin.Forms;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// Label with additional properties.
    /// </summary>
    public class ExtendedLabel : Label
    {
        public static readonly BindableProperty LinesProperty =
            BindableProperty.Create(nameof(Lines), typeof(int), typeof(ExtendedLabel), 3);

        public static readonly BindableProperty LineSpacingProperty =
            BindableProperty.Create(nameof(LineSpacing), typeof(double), typeof(ExtendedLabel), 1.3);

        public static readonly BindableProperty IsUnderlinedProperty =
            BindableProperty.Create(nameof(IsUnderlined), typeof(bool), typeof(ExtendedLabel), false, BindingMode.Default);

        /// <summary>
        /// How much lines will be displayed.
        /// </summary>
        public int Lines
        {
            get => (int)GetValue(LinesProperty);
            set => SetValue(LinesProperty, value);
        }

        /// <summary>
        /// Spacing between lines.
        /// </summary>
        public double LineSpacing
        {
            get => (double)GetValue(LineSpacingProperty);
            set => SetValue(LineSpacingProperty, value);
        }

        /// <summary>
        /// Display underline.
        /// </summary>
        public bool IsUnderlined
        {
            get => (bool)GetValue(IsUnderlinedProperty);
            set => SetValue(IsUnderlinedProperty, value);
        }
    }
}