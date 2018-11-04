using System;
using Xamarin.Forms;

namespace ReminderXamarin.Elements
{
    /// <inheritdoc />
    /// <summary>
    /// Image with ability to zoom and pan.
    /// </summary>
    public class ZoomImage : Image
    {
        private const double MinScale = 1;
        private const double MaxScale = 4;
        private const double Overshoot = 0.15;
        private double _startScale;
        private double _startX, _startY;

        public ZoomImage()
        {
            var pinch = new PinchGestureRecognizer();
            pinch.PinchUpdated += OnPinchUpdated;
            GestureRecognizers.Add(pinch);

            var pan = new PanGestureRecognizer();
            pan.PanUpdated += OnPanUpdated;
            GestureRecognizers.Add(pan);

            var tap = new TapGestureRecognizer { NumberOfTapsRequired = 2 };
            tap.Tapped += OnTapped;
            GestureRecognizers.Add(tap);

            Scale = MinScale;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
        }

        protected override SizeRequest OnMeasure(double widthConstraint, double heightConstraint)
        {
            Scale = MinScale;
            TranslationX = TranslationY = 0;
            AnchorX = AnchorY = 0;
            return base.OnMeasure(widthConstraint, heightConstraint);
        }

        private void OnTapped(object sender, EventArgs e)
        {
            if (Scale > MinScale)
            {
                this.ScaleTo(MinScale, 250, Easing.CubicInOut);
                this.TranslateTo(0, 0, 250, Easing.CubicInOut);
            }
            else
            {
                AnchorX = AnchorY = 0.5; //TODO tapped position
                this.ScaleTo(MaxScale, 250, Easing.CubicInOut);
            }
        }

        private void OnPanUpdated(object sender, PanUpdatedEventArgs e)
        {
            switch (e.StatusType)
            {
                case GestureStatus.Started:
                    _startX = (1 - AnchorX) * Width;
                    _startY = (1 - AnchorY) * Height;
                    break;
                case GestureStatus.Running:
                    AnchorX = Clamp(1 - (_startX + e.TotalX) / Width, 0, 1);
                    AnchorY = Clamp(1 - (_startY + e.TotalY) / Height, 0, 1);
                    break;
            }
        }

        private void OnPinchUpdated(object sender, PinchGestureUpdatedEventArgs e)
        {
            switch (e.Status)
            {
                case GestureStatus.Started:
                    _startScale = Scale;
                    AnchorX = e.ScaleOrigin.X;
                    AnchorY = e.ScaleOrigin.Y;
                    break;
                case GestureStatus.Running:
                    double current = Scale + (e.Scale - 1) * _startScale;
                    Scale = Clamp(current, MinScale * (1 - Overshoot), MaxScale * (1 + Overshoot));
                    break;
                case GestureStatus.Completed:
                    if (Scale > MaxScale)
                    {
                        this.ScaleTo(MaxScale, 250, Easing.SpringOut);
                    }
                    else if (Scale < MinScale)
                    {
                        this.ScaleTo(MinScale, 250, Easing.SpringOut);
                    }
                    break;
            }
        }

        private T Clamp<T>(T value, T minimum, T maximum) where T : IComparable
        {
            if (value.CompareTo(minimum) < 0)
            {
                return minimum;
            }
            if (value.CompareTo(maximum) > 0)
            {
                return maximum;
            }
            return value;
        }
    }
}