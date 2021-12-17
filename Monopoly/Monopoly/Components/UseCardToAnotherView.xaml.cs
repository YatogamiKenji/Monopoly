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
    /// Interaction logic for UseCardToAnotherView.xaml
    /// </summary>
    public partial class UseCardToAnotherView : BaseCenterMapView
    {
        public static readonly RoutedEvent CancleButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnCancleButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UseCardToAnotherView));
        public event RoutedEventHandler OnCancleButtonClick
        {
            add { AddHandler(CancleButtonClickEvent, value); }
            remove { RemoveHandler(CancleButtonClickEvent, value); }
        }

        public static readonly RoutedEvent ButtonPlayerClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnButtonPlayerClick), RoutingStrategy.Bubble, typeof(BtnAnotherPlayerClickEventHandler), typeof(UseCardToAnotherView));
        public event BtnAnotherPlayerClickEventHandler OnButtonPlayerClick
        {
            add { AddHandler(ButtonPlayerClickEvent, value); }
            remove { RemoveHandler(ButtonPlayerClickEvent, value); }
        }

        public UseCardToAnotherView(List<Player> players, int turn)
        {
            InitializeComponent();
            for (int i = 0; i < players.Count; i++)
            {
                if (i != turn)
                {
                    BtnAnotherPlayer btnAnotherPlayer =
                        new BtnAnotherPlayer(
                            i,
                            new BitmapImage(new Uri(@"/Monopoly;component/Images/avatar/circle-avatar" + (i + 1) + ".jpg", UriKind.Relative)),
                            players[i].name,
                            players[i].money
                        );
                    btnAnotherPlayer.OnClick += BtnAnotherPlayer_OnClick;
                    mainContent.Children.Add(btnAnotherPlayer);
                }
            }
        }

        private void BtnAnotherPlayer_OnClick(object sender, BtnAnotherPlayerClickEventArgs e)
        {
            RaiseEvent(new BtnAnotherPlayerClickEventArgs(ButtonPlayerClickEvent, this) { idPlayer = e.idPlayer });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(CancleButtonClickEvent));

        }
    }
}
