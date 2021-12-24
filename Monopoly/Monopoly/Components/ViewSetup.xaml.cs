using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Text.RegularExpressions;
using System.Windows.Threading;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for Setup.xaml
    /// </summary>
    public delegate void BtnGoClickEventHandler(object sender, GoClickEventArgs agrs);

    public partial class Setup : UserControl
    {
        // List<ContentPlayer> Cont_Player;   // List các Components của ContentPlayer
        List<PlayerShow> ShowPlayers; //= new List<PlayerShow>();   // List các các Components của PlayerShow, PlayerShow là để show hình hình ảnh ngưởi chơi trên bàn cờ
        // Cấu hình UI người chơi 
        public PlayerShow ShowPlayer1;
        public PlayerShow ShowPlayer2;
        public PlayerShow ShowPlayer3;
        public PlayerShow ShowPlayer4;
        public string[] nameplayer = new string[4];
        public int countplayer;
        bool gameMode = true; //chọn chế độ chơi (true: Unlimied, false: Setup)
        int numberTurns = 0; //số lượt chơi ở chế độ Setup
        public static Setup instance;

        public Setup()
        {
            InitializeComponent();
            ShowPlayers = new List<PlayerShow>();
            instance = this;
            choselimitted.Visibility = Visibility.Visible;
            Override.Visibility = Visibility.Hidden;
        }

        public static readonly RoutedEvent BackButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBackButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(Setup));

        public event RoutedEventHandler OnBackButtonClick
        {
            add { AddHandler(BackButtonClickEvent, value); }
            remove { RemoveHandler(BackButtonClickEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(BackButtonClickEvent));
        }

        public static readonly RoutedEvent ButtonGoClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnButtonGoClick), RoutingStrategy.Bubble, typeof(BtnGoClickEventHandler), typeof(Setup));
        
        public event BtnGoClickEventHandler OnButtonGoClick
        {
            add { AddHandler(ButtonGoClickEvent, value); }
            remove { RemoveHandler(ButtonGoClickEvent, value); }
        }

        //Chuyển sang giao diện bàn cờ chính
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();

            if (countplayer == 2)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
            }
            else if (countplayer == 3)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ShowPlayers.Add(ShowPlayer3);
            }
            else if (countplayer == 4)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ShowPlayers.Add(ShowPlayer3);
                ShowPlayers.Add(ShowPlayer4);
            }

            if (countplayer > 1)
            {
                RaiseEvent(new GoClickEventArgs(ButtonGoClickEvent, this)
                {
                    showPlayers = ShowPlayers,
                    GameMode = gameMode,
                    NumberTurns = numberTurns
                });
            }
            else Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Vui lòng chọn số người chơi!", "Red"), 2.5, (str) => { });
        }

        // Khởi tạo có 2 người chơi
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            chose3.Visibility = Visibility.Collapsed;
            chose4.Visibility = Visibility.Collapsed;
            chose2.Visibility = Visibility.Visible;
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 2;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Collapsed;
            player4.Visibility = Visibility.Collapsed;
            Override.Visibility = Visibility.Visible;
        }

        // Khởi tạo có 3 người chơi
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            chose2.Visibility = Visibility.Collapsed;
            chose4.Visibility = Visibility.Collapsed;
            chose3.Visibility = Visibility.Visible;
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 3;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Visible;
            player4.Visibility = Visibility.Collapsed;
            Override.Visibility = Visibility.Visible;
        }

        // Khởi tạo có 4 người chơi
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            chose3.Visibility = Visibility.Collapsed;
            chose2.Visibility = Visibility.Collapsed;
            chose4.Visibility = Visibility.Visible;
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 4;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Visible;
            player4.Visibility = Visibility.Visible;
            Override.Visibility = Visibility.Visible;
        }

        //Khởi tạo chế độ Setup
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(setup_chose);
            chosesetup.Visibility = Visibility.Visible;
            choselimitted.Visibility = Visibility.Collapsed;
            Override.Visibility = Visibility.Visible;
            Sound.StartButton();
            gameMode = false;
        }

        //Khởi tạo chế độ Limited
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            chosesetup.Visibility = Visibility.Collapsed;
            choselimitted.Visibility = Visibility.Visible;
            Sound.StartButton();
            gameMode = true;
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            rocketstart.PlacementTarget = start;
            rocketstart.Placement = PlacementMode.Right;
            rocketstart.IsOpen = true;
            start.Content = "ĐI NÀO!!!";
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            start.Content = "SẴN SÀNG";
            rocketstart.Visibility = Visibility.Collapsed;
            rocketstart.IsOpen = false;
        }

        public Player player11 = new Player();

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            Storyboard slide = Resources["CloseMenu"] as Storyboard;
            slide.Begin(createName);
            ShowPlayers = new List<PlayerShow>();
            ShowPlayer1 = new PlayerShow { Title = "1", Margin = new Thickness(10, 10, 50, 30), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_blue.png", UriKind.Relative)) };
            ShowPlayer2 = new PlayerShow { Title = "2", Margin = new Thickness(40, 10, 20, 30), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_green.png", UriKind.Relative)) };
            ShowPlayer3 = new PlayerShow { Title = "3", Margin = new Thickness(10, 30, 50, 10), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_red.png", UriKind.Relative)) };
            ShowPlayer4 = new PlayerShow { Title = "4", Margin = new Thickness(40, 30, 20, 10), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_yellow.png", UriKind.Relative)) };
            nameplayer[0] = nameplayer1.Text;
            nameplayer[1] = nameplayer2.Text;
            nameplayer[2] = nameplayer3.Text;
            nameplayer[3] = nameplayer4.Text;
            Override.Visibility = Visibility.Hidden;
        }

        private void TextChangedFuntion(object sender, TextChangedEventArgs e)
        {
            Sound.Type();
        }

        private void ok1_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            if (turn.Text != "" && int.Parse(turn.Text) > 0)
            {
                Storyboard slide = Resources["CloseMenu"] as Storyboard;
                slide.Begin(setup_chose);
                numberTurns = int.Parse(turn.Text);
            }
            Override.Visibility = Visibility.Hidden;
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Sound.Type();  
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }
    }
}