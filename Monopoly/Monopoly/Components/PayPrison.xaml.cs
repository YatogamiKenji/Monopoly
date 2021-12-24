using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for PayPrison.xaml
    /// </summary>
    public partial class PayPrison : BaseCenterMapView
    {
        public static readonly RoutedEvent OkButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnOkButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PayPrison));

        public event RoutedEventHandler OnOkButtonClick
        {
            add { AddHandler(OkButtonClickEvent, value); }
            remove { RemoveHandler(OkButtonClickEvent, value); }
        }

        private void OkButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BuyButton();
            RaiseEvent(new RoutedEventArgs(OkButtonClickEvent));
        }

        public static readonly RoutedEvent SkipButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PayPrison));

        public event RoutedEventHandler OnSkipButtonClick
        {
            add { AddHandler(SkipButtonClickEvent, value); }
            remove { RemoveHandler(SkipButtonClickEvent, value); }
        }

        private void SkipButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(SkipButtonClickEvent));
        }

        public PayPrison()
        {
            InitializeComponent();
        }
    }
}
