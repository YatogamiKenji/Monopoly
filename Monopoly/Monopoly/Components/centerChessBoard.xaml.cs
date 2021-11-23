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

        //funciton timer, show random value 1-6
        public void timer_Tick(object sender, EventArgs e)
        {
            messboxDice diceshow = new messboxDice();
            Random random = new Random();
            dice = random.Next(1, 7);
            num.Title = dice.ToString();
        }
        //create timer
        public DispatcherTimer timer = new DispatcherTimer();
        public void But_xucxac_Click(object sender, RoutedEventArgs e)
        {
            //setup timer
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += timer_Tick;
            timer.Start();
            //Quay hide, Stop show
            But_xucxac.Visibility = Visibility.Collapsed;
            But_xucxac1.Visibility = Visibility.Visible;
        }
        public void But_xucxac_Click1(object sender, RoutedEventArgs e)
        {
            //Quay show, Stop hide
            But_xucxac1.Visibility = Visibility.Collapsed;
            But_xucxac.Visibility = Visibility.Visible;
            timer.Stop();
            ChessBoard chessB = new ChessBoard();
            chessB.changePlayerPosition(dice);
        }
    }
}
