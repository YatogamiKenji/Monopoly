using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ViewAbout.xaml
    /// </summary>
    public partial class ViewAbout : UserControl
    {
        public ViewAbout()
        {
            InitializeComponent();
        }
        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBackButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ViewStart));
        public event RoutedEventHandler OnBackButtonClick
        {
            add { AddHandler(BackButtonClickEvent, value); }
            remove { RemoveHandler(BackButtonClickEvent, value); }
        }
        private void BACK_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(BackButtonClickEvent));
        }
    }
}
