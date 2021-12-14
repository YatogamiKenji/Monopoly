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
    /// Interaction logic for PanelCenterMap.xaml
    /// </summary>
    [ContentProperty(nameof(Children))]  // Prior to C# 6.0, replace nameof(Children) with "Children"
    public partial class PanelCenterMap : UserControl
    {

        public static readonly DependencyPropertyKey ChildrenProperty = DependencyProperty.RegisterReadOnly(
            nameof(Children),  // Prior to C# 6.0, replace nameof(Children) with "Children"
            typeof(UIElementCollection),
            typeof(PanelCenterMap),
            new PropertyMetadata());

        public UIElementCollection Children
        {
            get { return (UIElementCollection)GetValue(ChildrenProperty.DependencyProperty); }
            private set { SetValue(ChildrenProperty, value); }
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PanelCenterMap), new PropertyMetadata("TIÊU ĐỀ MẶC ĐỊNH"));

        public string CountdownStr
        {
            get { return (string)GetValue(CountdownStrProperty); }
            set { SetValue(CountdownStrProperty, value); }
        }

        // Using a DependencyProperty as the backing store for CountdownStr.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty CountdownStrProperty =
            DependencyProperty.Register("CountdownStr", typeof(string), typeof(PanelCenterMap), new PropertyMetadata("00 : 00"));


        public PanelCenterMap()
        {
            InitializeComponent();
            Children = mainContent.Children;
        }

        public void SetCountdown(int countdown)
        {
            if (countdown < 0)
                countdown = 0;
            int m = countdown / 60;
            int s = countdown % 60;
            CountdownStr = (m < 10 ? "0" : "") + m + " : " + (s < 10 ? "0" : "") + s;
        }
    }
}
