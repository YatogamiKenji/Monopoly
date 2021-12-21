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
    /// Interaction logic for endGame.xaml
    /// </summary>
    public partial class endGame : UserControl
    {
        public endGame(Player player)
        {
            InitializeComponent();
            ContentSideBar contentSideBar = new ContentSideBar(player);
            SideBar.Content = contentSideBar;
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
