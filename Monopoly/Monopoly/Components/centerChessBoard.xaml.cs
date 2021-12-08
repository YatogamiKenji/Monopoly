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
        public DispatcherTimer timer = new DispatcherTimer();
        public DispatcherTimer timer1 = new DispatcherTimer();
        public DispatcherTimer timer2 = new DispatcherTimer();


        private void dice_Click(object sender, RoutedEventArgs e)
        {
            Storyboard sb = (Storyboard)rc.FindResource("spin");
            TransRotate.Angle = 0;
            timer.Interval = TimeSpan.FromSeconds(0.5);
            timer.Tick += timer_Tick;
            timer1.Interval = TimeSpan.FromSeconds(2);
            timer1.Tick += timer1_Tick;
            timer2.Interval = TimeSpan.FromSeconds(1);
            timer2.Tick += timer2_Tick;
            sb.Begin();
            timer.Start();
        }

        public void timer_Tick(object sender, EventArgs e)
        {
            Random a = new Random();
            changespeed(a.Next(15, 30));
            timer.Stop();
            timer1.Start();
        }
        public void timer1_Tick(object sender, EventArgs e)
        {
            Random a = new Random();
            changespeed(a.Next(3, 7));

            timer1.Stop();
            timer2.Start();
        }
        public int dicenum;
        public void timer2_Tick(object sender, EventArgs e)
        {
            changespeed(0);

            double an = TransRotate.Angle;
            getAngle(an);
            Storyboard sb = (Storyboard)rc.FindResource("spin");
            sb.Stop();
            TransRotate.Angle = an;

            num.content.Text = dicenum.ToString();
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(num);


            timer2.Stop();
        }

        public void getAngle(double ang)
        {
            if (ang >= 330)
            {
                dicenum = 1;
            }
            else if (ang >= 0 && ang < 30)
            {
                dicenum = 1;
            }
            else if (ang >= 30 && ang < 90)
            {
                dicenum = 2;
            }
            else if (ang >= 90 && ang < 150)
            {
                dicenum = 3;
            }
            else if (ang >= 150 && ang < 210)
            {
                dicenum = 4;
            }
            else if (ang >= 210 && ang < 270)
            {
                dicenum = 5;
            }
            else if (ang >= 270 && ang < 330)
            {
                dicenum = 6;
            }
        }

        public void changespeed(int speed)
        {
            Storyboard sb = (Storyboard)rc.FindResource("spin");
            sb.SetSpeedRatio(speed);

        }

    }
}
