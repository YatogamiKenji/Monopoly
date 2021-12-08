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
        static public void Show(ContentControl area, UIElement notiBox, int existTime, Action<string> actionAfter)
        {
            DoubleAnimation fadeInAnim = new DoubleAnimation(1, new Duration(TimeSpan.FromSeconds(0.2)));
            DoubleAnimation fadeOutAnim = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.2)));

            

            Grid areaGrid = new Grid();
            areaGrid.Children.Add(notiBox);
            areaGrid.Background = new SolidColorBrush(Colors.Transparent);
            notiBox.Opacity = 0;
            area.Content = areaGrid;

            notiBox.BeginAnimation(OpacityProperty, fadeInAnim);

            DispatcherTimer existTimer = new DispatcherTimer();
            existTimer.Interval = TimeSpan.FromSeconds(existTime);
            existTimer.Start();

            DispatcherTimer delayAnimTimer = new DispatcherTimer();
            delayAnimTimer.Interval = TimeSpan.FromSeconds(0.2);


            existTimer.Tick += new EventHandler((sender, e) =>
            {
                delayAnimTimer.Tick += new EventHandler((sender, e) => 
                {
                    area.Content = null;
                    actionAfter("timeout");
                });
                delayAnimTimer.Start();
                notiBox.BeginAnimation(OpacityProperty, fadeOutAnim);


            });

            area.MouseLeftButtonDown += new System.Windows.Input.MouseButtonEventHandler((sender, e) =>
            {
                delayAnimTimer.Tick += new EventHandler((sender, e) =>
                {
                    area.Content = null;
                    actionAfter("click");
                });
                delayAnimTimer.Start();
                notiBox.BeginAnimation(OpacityProperty, fadeOutAnim);
            });
        }
    }
}
