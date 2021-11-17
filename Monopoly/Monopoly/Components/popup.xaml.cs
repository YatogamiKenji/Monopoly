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
    /// Interaction logic for popup.xaml
    /// </summary>
    public partial class popup : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("angle", typeof(string), typeof(popup), new PropertyMetadata(string.Empty));
        public string angle
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        public popup()
        {
            InitializeComponent();
        }
    }
}
