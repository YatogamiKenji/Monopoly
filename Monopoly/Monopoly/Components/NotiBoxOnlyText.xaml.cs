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
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for NotiBoxOnlyText.xaml
    /// </summary>
    public partial class NotiBoxOnlyText : UserControl
    {



        public string Color
        {
            get { return (string)GetValue(ColorProperty); }
            set { SetValue(ColorProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Color.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ColorProperty =
            DependencyProperty.Register("Color", typeof(string), typeof(NotiBoxOnlyText), new PropertyMetadata(""));




        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Text.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(NotiBoxOnlyText), new PropertyMetadata(""));




        public NotiBoxOnlyText()
        {
            this.DataContext = this;
            InitializeComponent();
        }

        public NotiBoxOnlyText(string text, string color)
        {
            this.DataContext = this;
            InitializeComponent();
            Text = text;
            Color = color;
        }
    }
}
