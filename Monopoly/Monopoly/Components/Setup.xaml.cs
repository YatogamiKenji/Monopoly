﻿using System;
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
using Monopoly.Components;
using System.Windows.Controls.Primitives;
using System.Windows.Threading;
namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public partial class Setup : UserControl
    {
        // List<ContentPlayer> Cont_Player;   // List các Components của ContentPlayer
        List<PlayerShow> ShowPlayers; //= new List<PlayerShow>();   // List các các Components của PlayerShow, PlayerShow là để show hình hình ảnh ngưởi chơi trên bàn cờ

        // Cấu hình UI người chơi 
        PlayerShow ShowPlayer1 = new PlayerShow { Title = "1", Margin = new Thickness(10, 10, 50, 50), BackgroundPlayer = Brushes.Red };
        PlayerShow ShowPlayer2 = new PlayerShow { Title = "2", Margin = new Thickness(35, 10, 25, 50), BackgroundPlayer = Brushes.MediumVioletRed };
        PlayerShow ShowPlayer3 = new PlayerShow { Title = "3", Margin = new Thickness(35, 35, 25, 25), BackgroundPlayer = Brushes.Blue };
        PlayerShow ShowPlayer4 = new PlayerShow { Title = "4", Margin = new Thickness(10, 35, 50, 25), BackgroundPlayer = Brushes.LawnGreen };

        public Setup()
        {
            InitializeComponent();
            ShowPlayers = new List<PlayerShow>();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewStart start = new ViewStart();
            back.Content = start;
            this.Visibility = Visibility.Collapsed;
        }

        //Chuyển sang giao diện bàn cờ chính
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (ShowPlayers.Count > 0)
            {

                ChessBoard board = new ChessBoard(ShowPlayers);
                chess.Content = board;
            }

        }
        // Khởi tạo có 2 người chơi
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            //Cont_Players = new List<ContentPlayer>();
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 1" });
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 2" });

            ShowPlayers = new List<PlayerShow>();
            ShowPlayers.Add(ShowPlayer1);
            ShowPlayers.Add(ShowPlayer2);

        }
        // Khởi tạo có 3 người chơi
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            //Cont_Players = new List<ContentPlayer>();
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 1" });
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 2" });
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 3" });

            ShowPlayers = new List<PlayerShow>();
            ShowPlayers.Add(ShowPlayer1);
            ShowPlayers.Add(ShowPlayer2);
            ShowPlayers.Add(ShowPlayer3);
        }
        // Khởi tạo có 4 người chơi
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            //Cont_Players = new List<ContentPlayer>();
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 1" });
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 2" });
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 3" });
            //Cont_Players.Add(new ContentPlayer { NamePlayer = "Player 4" });

            ShowPlayers = new List<PlayerShow>();
            ShowPlayers.Add(ShowPlayer1);
            ShowPlayers.Add(ShowPlayer2);
            ShowPlayers.Add(ShowPlayer3);
            ShowPlayers.Add(ShowPlayer4);


        }
        //Khởi tạo chế độ Setup
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {

        }
        //Khởi tạo chế độ Limited
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {

        }
        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            rocketstart.PlacementTarget = start;
            rocketstart.Placement = PlacementMode.Right;
            rocketstart.IsOpen = true;
            start.Content = "GO!!";
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            start.Content = "START";
            rocketstart.Visibility = Visibility.Collapsed;
            rocketstart.IsOpen = false;
        }

    }
}
