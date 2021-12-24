using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ListContentPlayers.xaml
    /// </summary>
    public partial class ListContentPlayers : UserControl
    {

        //Danh sách các người chơi(người sử dụng thẻ được đánh dấu)
        public List<Player> players = new List<Player>();
        // Lưu các button người chơi(trừ người sử dụng thẻ)
        public List<ContentPlayer> ListButtonPlayers = new List<ContentPlayer>();

        int PlayerChoose; // xác định là người chơi nào đang sử dụng thẻ

        public ListContentPlayers()//List<ContentPlayer> QuantityPlayers)
        {
            InitializeComponent();
            // ListPlayers = QuantityPlayers;
            // ListPlayers.Add(new ContentPlayer { NamePlayer = "Player 1" }); ;
            //ListPlayers.Add(new ContentPlayer { NamePlayer = "Player 2" });
            //ListPlayers.Add(new ContentPlayer { NamePlayer = "Player 3" });
          //  SetGridPosition();
        }

        public ListContentPlayers(List<Player> Players, int personChoose)//List<ContentPlayer> QuantityPlayers)
        {
            InitializeComponent();
            players = Players;
            PlayerChoose = personChoose;
       
            SetGridPosition();
        }

        void SetGridPosition()
        {   
            int t = players.Count; 
            //MessageBox.Show(players.Count.ToString() + ' ' + PlayerChoose.ToString());
            {
                //for (int i = 0; i < Math.Ceiling((decimal)(t - 1) / 3 ); i++)
                //{
                //    var rowDefinition = new RowDefinition();
                //    rowDefinition.Height = GridLength.Auto;
                //    ListContentPlayersGrid.RowDefinitions.Add(rowDefinition);

                //}
                int k = 0; // số cột
                for (int i = 0; i < t; i++)
                {
                    if (i != PlayerChoose) // nếu không phải là người sử dụng thẻ thì mới add;
                    {
                      
                        ContentPlayer x = new ContentPlayer();
                        x.ImagePlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/avatar/avatar" + (i + 1).ToString() + ".jpg", UriKind.Relative));
                        // MessageBox.Show(i.ToString());
                        //if (i == 0)
                        //{
                        //    x.ImagePlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/avatar/avatar1.jpg", UriKind.Relative));
                        //}
                        //else if (i == 1)
                        //{
                        //    x.ImagePlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_green.png", UriKind.Relative));
                        //}
                        //else if (i == 2)
                        //{
                        //    x.ImagePlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_red.png", UriKind.Relative));
                        //}
                        //else if (i == 3)
                        //{
                        //    x.ImagePlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_yellow.png", UriKind.Relative));
                        //}
                        x.NamePlayer = players[i].name;
                        x.Margin = new Thickness(2, 2, 2, 2);
                        x.Width = 93;
                        x.Height = 160;
                        Grid.SetColumn(x, k);
                        ListContentPlayersGrid.Children.Add(x);
                        ListButtonPlayers.Add(x);
                        k++;
                    }
                }
            }
        }
       

    }
}
