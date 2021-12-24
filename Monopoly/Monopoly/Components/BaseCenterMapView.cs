using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Monopoly.Components
{
    public class BaseCenterMapView : UserControl
    {
        public virtual void setCountdown(double countdown)
        {
            Layouts.PanelCenterMap thisPanel = (Layouts.PanelCenterMap)FindName("thisPanel");
            thisPanel?.SetCountdown((int)Math.Ceiling(countdown));
        }

        private void mountedAnim()
        {
            this.Opacity = 0;
            DoubleAnimation fadeInAnim = new DoubleAnimation(1, new Duration(TimeSpan.FromSeconds(0.25)));
            DoubleAnimation scaleX = new DoubleAnimation()
            {
                From = 0.8,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.25),
            };

            DoubleAnimation scaleY = new DoubleAnimation()
            {
                From = 0.8,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.25),
            };

            this.BeginAnimation(OpacityProperty, fadeInAnim);

            this.RenderTransform = new ScaleTransform();
            this.RenderTransformOrigin = new Point(0.5, 0.5);
            this.RenderTransform.BeginAnimation(ScaleTransform.ScaleXProperty, scaleX);
            this.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleY);
        }

        public void unmoutedAnim()
        {
            DoubleAnimation fadeInAnim = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.15)));
            this.BeginAnimation(OpacityProperty, fadeInAnim);
        }

        public BaseCenterMapView()
        {
            this.Loaded += (s, e) => { mountedAnim(); };
        }
    }
}
