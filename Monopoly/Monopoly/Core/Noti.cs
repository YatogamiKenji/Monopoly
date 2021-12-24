using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Threading;

namespace Monopoly
{
    public class Noti : Control
    {

        /// <summary>
        /// Hiển thị thông báo
        /// Tham số:
        /// + ContentControl area: Nơi hiển thị thông báo
        /// + UIElement notiBox: Component thông báo sẽ hiển thị
        /// + double existTime: thời gian tồn tại của thông báo
        /// + Action<string> actionAfter: Một hàm được gọi khi thông báo biến mất. Đối số của hàm là một chuỗi, giá trị là timeout nếu thông báo biến mất do hết thời gian, giá trị là click nếu thông báo biến mất do Click vào area
        /// </summary>
        static public void Show(ContentControl area, UIElement notiBox, double existTime, Action<string> actionAfter)
        {
            DoubleAnimation fadeInAnim = new DoubleAnimation(1, new Duration(TimeSpan.FromSeconds(0.25)));
            DoubleAnimation fadeOutAnim = new DoubleAnimation(0, new Duration(TimeSpan.FromSeconds(0.2)));
            DoubleAnimation scaleInY = new DoubleAnimation()
            {
                From = 0.5,
                To = 1,
                Duration = TimeSpan.FromSeconds(0.2),
            };
            DoubleAnimation scaleOutY = new DoubleAnimation()
            {
                From = 1,
                To = 0.5,
                Duration = TimeSpan.FromSeconds(0.15),
            };


            Sound.Notification();

            Grid areaGrid = new Grid();
            areaGrid.Children.Add(notiBox);
            areaGrid.Background = new SolidColorBrush(Colors.Transparent);
            notiBox.Opacity = 0;
            notiBox.RenderTransform = new ScaleTransform();
            notiBox.RenderTransformOrigin = new Point(0.5, 0.5);
            area.Content = areaGrid;

            notiBox.BeginAnimation(OpacityProperty, fadeInAnim);
            notiBox.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleInY);

            DispatcherTimer timer = new DispatcherTimer();

            System.Windows.Input.MouseButtonEventHandler handler = null;
            handler = (sender, e) =>
            {
                timer.Stop();
                SetTimeout(() =>
                {
                    area.Content = null;
                    actionAfter("timeout");
                }, 0.2);
                notiBox.BeginAnimation(OpacityProperty, fadeOutAnim);
                notiBox.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleOutY);
                area.MouseLeftButtonDown -= handler;
            };
            area.MouseLeftButtonDown += handler;

            timer = SetTimeout(() =>
            {
                area.MouseLeftButtonDown -= handler;
                SetTimeout(() =>
                {
                    area.Content = null;
                    actionAfter("timeout");
                }, 0.2);
                notiBox.BeginAnimation(OpacityProperty, fadeOutAnim);
                notiBox.RenderTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleOutY);
            }, existTime);
        }

        static public DispatcherTimer SetTimeout(Action action, double timeout)
        {
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromSeconds(timeout);
            timer.Tick += delegate (object sender, EventArgs args)
            {
                action();
                timer.Stop();
            };
            timer.Start();
            return timer;
        }
    }
}
