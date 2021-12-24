using System;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for DiceView.xaml
    /// </summary>

    public delegate void SpinnedDiceEventHandler(object sender, SpinnedDiceEventAgrs agrs);

    public partial class DiceView : BaseCenterMapView
    {

        public static RoutedEvent SpinnedDiceEvent =
            EventManager.RegisterRoutedEvent("OnSpinnedDice", RoutingStrategy.Bubble, typeof(SpinnedDiceEventHandler), typeof(DiceView));

        public event SpinnedDiceEventHandler OnSpinnedDice
        {
            add { AddHandler(SpinnedDiceEvent, value);}
            remove { RemoveHandler(SpinnedDiceEvent, value); }
        }


        public static readonly RoutedEvent ButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(DiceView));

        public event RoutedEventHandler OnButtonClick
        {
            add { AddHandler(ButtonClickEvent, value); }
            remove { RemoveHandler(ButtonClickEvent, value); }
        }

        Random rand = new Random();
        public DiceView()
        {
            InitializeComponent();
            Loaded += (s, e) =>
            {
                this.Focusable = true;
                this.Focus();
                addEventCheat();
            };
        }

        private void btnSpin_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonClickEvent));
            Sound.StartButton();
            Sound.Spinning();
            btnSpin.Style = FindResource("BtnStyle1Gray") as Style;
            btnSpin.IsEnabled = false;

            int randAngle = 720 + rand.Next(0, 6)*60 + (rand.Next(0, 21) - 10);
            DoubleAnimation rotateAnim = new DoubleAnimation(0, (double)randAngle, new Duration(TimeSpan.FromSeconds(1.5)));
            rotateAnim.EasingFunction = new PowerEase { EasingMode = EasingMode.EaseInOut };
            wheel.RenderTransform = new RotateTransform();
            wheel.RenderTransformOrigin = new Point(0.5, 0.5);
            wheel.RenderTransform.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);

            Noti.SetTimeout(() =>
            {
                int num = 7 - (((randAngle-30) % 360 / 60) + 1);
                RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = num });
            }, 1.6);
        }

        // Thực hiện Click vào cái nút quay
        public void clickBtnSpin()
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(btnSpin);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
        }

        // Cheat: Trong Diceview, khi ấn các phím số số từ 1 đến 6 sẽ cho ra kết quả xúc xắc tương ứng
        private void addEventCheat()
        {

            KeyDown += (s, e) =>
            {
                if (e.Key == Key.D1)
                {
                    RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = 1 });
                    btnSpin.Click -= btnSpin_Click;
                }
                if (e.Key == Key.D2)
                {
                    RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = 2 });
                    btnSpin.Click -= btnSpin_Click;
                }
                if (e.Key == Key.D3)
                {
                    RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = 3 });
                    btnSpin.Click -= btnSpin_Click;
                }
                if (e.Key == Key.D4)
                {
                    RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = 4 });
                    btnSpin.Click -= btnSpin_Click;
                }
                if (e.Key == Key.D5)
                {
                    RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = 5 });
                    btnSpin.Click -= btnSpin_Click;
                }
                if (e.Key == Key.D6)
                {
                    RaiseEvent(new SpinnedDiceEventAgrs(SpinnedDiceEvent, this) { valueOfDice = 6 });
                    btnSpin.Click -= btnSpin_Click;
                }
            };
        }
    }
}
