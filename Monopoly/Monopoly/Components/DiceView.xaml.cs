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

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for DiceView.xaml
    /// </summary>

    public delegate void SpinnedDiceEventHandler(object sender, SpinnedDiceEventAgrs agrs);

    public partial class DiceView : UserControl
    {

        public static RoutedEvent SpinnedDiceEvent =
            EventManager.RegisterRoutedEvent("OnSpinnedDice", RoutingStrategy.Bubble, typeof(SpinnedDiceEventHandler), typeof(DiceView));

        public event SpinnedDiceEventHandler OnSpinnedDice
        {
            add
            {
                AddHandler(SpinnedDiceEvent, value);
            }
            remove
            {
                RemoveHandler(SpinnedDiceEvent, value);
            }
        }

        Random rand = new Random();
        public DiceView()
        {
            InitializeComponent();
        }

        private void btnSpin_Click(object sender, RoutedEventArgs e)
        {

            btnSpin.Style = FindResource("BtnStyle1Gray") as Style;
            btnSpin.IsEnabled = false;

            int randAngle = 720 + rand.Next(0, 6)*60 + (rand.Next(0, 11) - 10);
            DoubleAnimation rotateAnim = new DoubleAnimation(0, (double)randAngle, new Duration(TimeSpan.FromSeconds(1.5)));
            rotateAnim.EasingFunction = new PowerEase { EasingMode = EasingMode.EaseInOut };
            wheel.RenderTransform = new RotateTransform();
            wheel.RenderTransformOrigin = new Point(0.5, 0.5);
            wheel.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);

            Noti.SetTimeout(() =>
            {
                int num = 7-((randAngle % 360)/60+1);
                RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = num });
            }, 1.6);
        }
    }
}
