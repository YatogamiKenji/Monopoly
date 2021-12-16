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
        public Setup()
        {
            InitializeComponent();
            ShowPlayers = new List<PlayerShow>();


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
                ChessBoard board = new ChessBoard(ShowPlayers);
                chess.Content = board;
            }
            else if (countplayer == 3)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ShowPlayers.Add(ShowPlayer3);
                ChessBoard board = new ChessBoard(ShowPlayers);
                chess.Content = board;
            }
            else if (countplayer == 4)
            {
                ShowPlayers.Add(ShowPlayer1);
                ShowPlayers.Add(ShowPlayer2);
                ShowPlayers.Add(ShowPlayer3);
                ShowPlayers.Add(ShowPlayer4);
                ChessBoard board = new ChessBoard(ShowPlayers);
                chess.Content = board;
            }
        }

        // Khởi tạo có 2 người chơi
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 2;
            player3.Visibility = Visibility.Collapsed;
            player4.Visibility = Visibility.Collapsed;



        }
        // Khởi tạo có 3 người chơi
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 3;
            player4.Visibility = Visibility.Collapsed;

        }
        // Khởi tạo có 4 người chơi
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(createName);
            countplayer = 4;



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
        public imgplayer imgplayer1 = new imgplayer();
        private void createImg_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto1.Source = new BitmapImage(new Uri(op.FileName));
            }
           
            imgplayer1.Avatarplayer = op.FileName;
            MessageBox.Show(imgplayer1.Avatarplayer);
        }

        private void createImg2_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto2.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void createImg3_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto3.Source = new BitmapImage(new Uri(op.FileName));
            }

        }

        private void createImg4_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Select a picture";
            op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png";
            if (op.ShowDialog() == true)
            {
                imgPhoto4.Source = new BitmapImage(new Uri(op.FileName));
            }

        }
        public class imgplayer
        {
            private string avatarplayer;

            public string Avatarplayer { get => avatarplayer; set => avatarplayer = value; }
        }
    }
}
