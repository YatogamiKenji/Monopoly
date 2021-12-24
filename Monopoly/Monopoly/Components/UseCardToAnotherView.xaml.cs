using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Media.Imaging;

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
                if (i != turn && players[i].isLoser == false)
                {
                    BtnAnotherPlayer btnAnotherPlayer =
                        new BtnAnotherPlayer(
                            i,
                            new BitmapImage(new Uri(@"/Monopoly;component/Images/avatar/avatar" + (i + 1) + ".jpg", UriKind.Relative)),
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
            Sound.StartButton();
            RaiseEvent(new BtnAnotherPlayerClickEventArgs(ButtonPlayerClickEvent, this) { idPlayer = e.idPlayer });
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(CancleButtonClickEvent));

        }
    }
}
