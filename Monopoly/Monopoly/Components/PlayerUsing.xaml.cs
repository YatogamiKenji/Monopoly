using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for PlayerUsing.xaml
    /// </summary>
    public partial class PlayerUsing : BaseCenterMapView
    {
        public static readonly RoutedEvent UseCardButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnUseCardButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PlayerUsing));

        public event RoutedEventHandler OnUseCardButtonClick
        {
            add { AddHandler(UseCardButtonClickEvent, value); }
            remove { RemoveHandler(UseCardButtonClickEvent, value); }
        }

        private void UseCardButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.ButtonUsePower();
            RaiseEvent(new RoutedEventArgs(UseCardButtonClickEvent));
        }

        public static readonly RoutedEvent SkipButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(PlayerUsing));

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

        public PlayerUsing()
        {
            InitializeComponent();
        }
    }
}
