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
    /// Interaction logic for ViewStart.xaml
    /// </summary>
    public partial class ViewStart : UserControl
    {
        public ViewStart()
        {
            InitializeComponent();
        }

        private void QUIT_Click(object sender, RoutedEventArgs e)
        {
            Window.GetWindow(this).Close();
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new ChessBoard();
        }
    }
}
