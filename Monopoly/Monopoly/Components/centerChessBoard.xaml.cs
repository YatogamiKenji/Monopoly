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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for centerChessBoard.xaml
    /// </summary>
    public partial class centerChessBoard : UserControl
    {
        public centerChessBoard()
        {
            InitializeComponent();
        }
        public Random random = new Random();
        public int dice = 0;
        public void But_xucxac_Click(object sender, RoutedEventArgs e)
        {
            dice = random.Next(1, 7);
            num.content.Text = dice.ToString();
           
            Storyboard sb = Resources["OpenMenu"] as Storyboard;
            sb.Begin(num);
        }
        
    }
}
