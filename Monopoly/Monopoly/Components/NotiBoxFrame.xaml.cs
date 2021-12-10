using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for NotiBoxFrame.xaml
    /// </summary>
    [ContentProperty(nameof(Children))]  // Prior to C# 6.0, replace nameof(Children) with "Children"
    public partial class NotiBoxFrame : UserControl
    {
        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
            nameof(Children),  // Prior to C# 6.0, replace nameof(Children) with "Children"
            typeof(UIElementCollection),
            typeof(NotiBoxFrame),
            new PropertyMetadata());

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NotiBoxFrame), new PropertyMetadata(""));

        public string ColorFrame
        {
            get { return (string)GetValue(ColorFrameProperty); }
            set 
            { 
                SetValue(ColorFrameProperty, value);
            }
        }

        // Using a DependencyProperty as the backing store for ColorFrame.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorFrameProperty =
            DependencyProperty.Register("ColorFrame", typeof(string), typeof(NotiBoxFrame), new PropertyMetadata(""));


        public NotiBoxFrame()
        {
            InitializeComponent();
            Children = notiBoxContent.Children;
            Loaded += (sender, e) =>
            {
                setColor();
            };
        }

        private void setColor ()
        {
            if (ColorFrame == "Red")
                imgBg.Source = new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_red.png", UriKind.Relative));
            else if (ColorFrame == "Green")
                imgBg.Source = new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_green.png", UriKind.Relative));
            else
                imgBg.Source = new BitmapImage(new Uri(@"/Monopoly;component/Images/message_box_center_map/message_box_center_map_blue.png", UriKind.Relative));

        }
    }
}
