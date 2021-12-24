using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for endGame.xaml
    /// </summary>
    public partial class endGame : UserControl
    {
        public endGame(Player player)
        {
            InitializeComponent();
            ContentSideBar contentSideBar = new ContentSideBar(player);
            Sidebar.Content = contentSideBar;
            playerName.Text = player.name;
        }

        public static readonly RoutedEvent ExitButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnExitButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(endGame));

        public event RoutedEventHandler OnExitButtonClick
        {
            add { AddHandler(ExitButtonClickEvent, value); }
            remove { RemoveHandler(ExitButtonClickEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(ExitButtonClickEvent));
        }
    }
}
