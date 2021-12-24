using System.Windows;
using System.Windows.Controls;

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
