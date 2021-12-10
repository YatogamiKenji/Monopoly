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
    /// Interaction logic for ContentChessCell.xaml
    /// </summary>
    public partial class ContentChessCell : UserControl
    {
        public ImageSource ImageCell
        {
            get { return (ImageSource)GetValue(ImageCellProperty); }
            set { SetValue(ImageCellProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageCellProperty =
            DependencyProperty.Register("ImageCell", typeof(ImageSource), typeof(ContentChessCell));

        public ContentChessCell()
        {
            InitializeComponent();
        }
    }
}
