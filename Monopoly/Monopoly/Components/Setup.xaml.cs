using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using System.Windows.Media.Imaging;
using Microsoft.Win32;
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
        public PlayerShow ShowPlayer1;
        public PlayerShow ShowPlayer2;
        public PlayerShow ShowPlayer3;
        public PlayerShow ShowPlayer4;

        public int countplayer;

        public static Setup instance;

        OpenFileDialog op1 = new OpenFileDialog();
        OpenFileDialog op2 = new OpenFileDialog();
        OpenFileDialog op3 = new OpenFileDialog();
        OpenFileDialog op4 = new OpenFileDialog();

        public OpenFileDialog imgplayer1;
        public OpenFileDialog imgplayer2;
        public OpenFileDialog imgplayer3;
        public OpenFileDialog imgplayer4;

        bool gameMode = true; //chọn chế độ chơi (true: Unlimied, false: Setup)
        int numberTurns = 0; //số lượt chơi ở chế độ Setup

        public Setup()
        {
            InitializeComponent();
            ShowPlayers = new List<PlayerShow>();
            instance = this;

            imgplayer1 = op1;
            imgplayer2 = op2;
            imgplayer3 = op3;
            imgplayer4 = op4;
            //op1.InitialDirectory = @"/Monopoly;component/Images/avatar" ;
            //op2.InitialDirectory = @"/Monopoly;component/Images/avatar";
            //op3.InitialDirectory = @"/Monopoly;component/Images/avatar";
            //op4.InitialDirectory = @"/Monopoly;component/Images/avatar";
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ViewStart start = new ViewStart();
            back.Content = start;

        }

        //Chuyển sang giao diện bàn cờ chính
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

            if (countplayer == 2)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ChessBoard board = new ChessBoard(ShowPlayers, gameMode, numberTurns);
                chess.Content = board;
            }
            else if (countplayer == 3)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ShowPlayers.Add(ShowPlayer3);
                ChessBoard board = new ChessBoard(ShowPlayers, gameMode, numberTurns);
                chess.Content = board;
            }
            else if (countplayer == 4)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ShowPlayers.Add(ShowPlayer3);
                ShowPlayers.Add(ShowPlayer4);
                ChessBoard board = new ChessBoard(ShowPlayers, gameMode, numberTurns);
                chess.Content = board;
            }
        }

        // Khởi tạo có 2 người chơi
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {

            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 2;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Collapsed;
            player4.Visibility = Visibility.Collapsed;
        }

        // Khởi tạo có 3 người chơi
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 3;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Visible;
            player4.Visibility = Visibility.Collapsed;
        }

        // Khởi tạo có 4 người chơi
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 4;
            player1.Visibility = Visibility.Visible;
            player2.Visibility = Visibility.Visible;
            player3.Visibility = Visibility.Visible;
            player4.Visibility = Visibility.Visible;
        }

        //Khởi tạo chế độ Setup
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            gameMode = false;
            numberTurns = 3;
        }

        //Khởi tạo chế độ Limited
        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            gameMode = true;
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

        private void ok_Click(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["CloseMenu"] as Storyboard;
            slide.Begin(createName);

            ShowPlayers = new List<PlayerShow>();

            ShowPlayer1 = new PlayerShow { Title = nameplayer1.Text, Margin = new Thickness(10, 10, 50, 50), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_blue.png", UriKind.Relative)) };
            ShowPlayer2 = new PlayerShow { Title = nameplayer2.Text, Margin = new Thickness(35, 10, 25, 50), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_green.png", UriKind.Relative)) };
            ShowPlayer3 = new PlayerShow { Title = nameplayer3.Text, Margin = new Thickness(10, 10, 50, 50), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_blue.png", UriKind.Relative)) };
            ShowPlayer4 = new PlayerShow { Title = nameplayer4.Text, Margin = new Thickness(35, 10, 25, 50), BackgroundPlayer = new BitmapImage(new Uri(@"/Monopoly;component/Images/player/player_green.png", UriKind.Relative)) };

        }

        private void createImg_Click(object sender, RoutedEventArgs e)
        {

            op1.Title = "Select a picture";
            op1.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op1.ShowDialog() == true)
            {
                imgPhoto1.Source = new BitmapImage(new Uri(op1.FileName));
            }


        }

        private void createImg2_Click(object sender, RoutedEventArgs e)
        {

            op2.Title = "Select a picture";
            op2.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op2.ShowDialog() == true)
            {
                imgPhoto2.Source = new BitmapImage(new Uri(op2.FileName));
            }

        }

        private void createImg3_Click(object sender, RoutedEventArgs e)
        {

            op3.Title = "Select a picture";
            op3.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op3.ShowDialog() == true)
            {
                imgPhoto3.Source = new BitmapImage(new Uri(op3.FileName));
            }

        }

        private void createImg4_Click(object sender, RoutedEventArgs e)
        {
            op4.Title = "Select a picture";
            op4.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op4.ShowDialog() == true)
            {
                imgPhoto4.Source = new BitmapImage(new Uri(op4.FileName));
            }

        }

    }
}