using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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
