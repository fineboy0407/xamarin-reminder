using Xamarin.Forms;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// ContentView with properties: border color, corner radius and border width.
    /// </summary>
    public class ContentViewWithBorder : ContentView
    {
        public static readonly BindableProperty CornerRadiusProperty = BindableProperty.Create(nameof(CornerRadius), 
            typeof(double), typeof(ContentViewWithBorder), 0.0, BindingMode.Default);
        public static readonly BindableProperty BorderColorProperty = BindableProperty.Create(nameof(BorderColor), 
            typeof(Color), typeof(ContentViewWithBorder), Color.Black, BindingMode.Default);
        public static readonly BindableProperty BorderWidthProperty = BindableProperty.Create(nameof(BorderWidth), 
            typeof(double), typeof(ContentViewWithBorder), 1.0, BindingMode.Default);

        public Color BorderColor
        {
            get => (Color)GetValue(BorderColorProperty);
            set => SetValue(BorderColorProperty, value);
        }
        public double CornerRadius
        {
            get => (double)GetValue(CornerRadiusProperty);
            set => SetValue(CornerRadiusProperty, value);
        }
        public double BorderWidth
        {
            get => (double)GetValue(BorderWidthProperty);
            set => SetValue(BorderWidthProperty, value);
        }
    }
}