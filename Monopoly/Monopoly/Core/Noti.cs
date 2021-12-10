using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Monopoly
{
    public class Noti : Control
    {
        static public void Show(ContentControl area, UIElement notiBox, double existTime, Action<string> actionAfter)
        {
            DoubleAnimation fadeInAnim = new DoubleAnimation(1, new Duration(TimeSpan.FromSeconds(0.25)));
            DoubleAnimation fadeOutAnim = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.2)));

            

            Grid areaGrid = new Grid();
            areaGrid.Children.Add(notiBox);
            areaGrid.Background = new SolidColorBrush(Colors.Transparent);
            notiBox.Opacity = 0;
            area.Content = areaGrid;

            notiBox.BeginAnimation(OpacityProperty, fadeInAnim);

            SetTimeout(() => 
            {
                SetTimeout(() =>
                {
                    area.Content = null;
                    actionAfter("timeout");
                }, 0.2);
                notiBox.BeginAnimation(OpacityProperty, fadeOutAnim);
            }, existTime);

            System.Windows.Input.MouseButtonEventHandler handler = null;
            handler = (sender, e) =>
            {
                SetTimeout(() =>
                {
                    area.Content = null;
                    actionAfter("timeout");
                }, 0.2);
                notiBox.BeginAnimation(OpacityProperty, fadeOutAnim);
                area.MouseLeftButtonDown -= handler;
            };
            area.MouseLeftButtonDown += handler;
        }

        static public void SetTimeout(Action action, double timeout)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(timeout);
            timer.Tick += delegate (object sender, EventArgs args)
            {
                action();
                timer.Stop();
            };
            timer.Start();
        }
    }
}
