using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Layouts
{
    class NotiBoxFrame : ContentControl
    {
        public string ColorFrame
        {
            get { return (string)GetValue(ColorFrameProperty); }
            set { SetValue(ColorFrameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ColorFrame.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorFrameProperty =
            DependencyProperty.Register("ColorFrame", typeof(string), typeof(NotiBoxFrame), new PropertyMetadata());

        static NotiBoxFrame()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(NotiBoxFrame), new FrameworkPropertyMetadata(typeof(NotiBoxFrame)));
        }
    }
}
