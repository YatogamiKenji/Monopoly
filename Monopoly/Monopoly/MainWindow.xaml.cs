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
using System.Threading;
using System.IO;
using Monopoly.Components;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
namespace Monopoly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            QuitBox.Visibility = Visibility.Hidden;
            Sound.PlayBGM();
            CreateViewStart();
        }

        #region ViewStart

        //tạo view start
        void CreateViewStart()
        {
            ViewStart viewStart = new ViewStart();
            viewStart.OnQuitButtonClick += ViewStart_OnQuitButtonClick;
            viewStart.OnPlayButtonClick += ViewStart_OnPlayButtonClick;
            viewStart.OnAboutButtonClick += ViewStart_OnAboutButtonClick;
            viewStart.OnGuideButtonClick += ViewStart_OnGuideButtonClick;
            view.Content = viewStart;
        }

        //nút guide
        private void ViewStart_OnGuideButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        //nut about
        private void ViewStart_OnAboutButtonClick(object sender, RoutedEventArgs e)
        {
            
        }

        //nút play
        private void ViewStart_OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            CreateSetup();
        }

        //nút quit
        private void ViewStart_OnQuitButtonClick(object sender, RoutedEventArgs e)
        {
            QuitBox.Visibility = Visibility.Visible;
        }

        #endregion

        #region View Setup

        //tạo view setup
        void CreateSetup()
        {
            Setup setup = new Setup();
            setup.OnBackButtonClick += Setup_OnBackButtonClick;
            setup.OnButtonGoClick += Setup_OnButtonGoClick;
            view.Content = setup;
        }    

        //vào game
        private void Setup_OnButtonGoClick(object sender, GoClickEventArgs e)
        {
            ChessBoard chessBoard = new ChessBoard(e.showPlayers, e.GameMode, e.NumberTurns);
            chessBoard.OnEndGameButtonClick += ChessBoard_OnEndGameButtonClick;
            view.Content = chessBoard;
        }

        //hiện view endGame
        private void ChessBoard_OnEndGameButtonClick(object sender, EndGameClickEventArgs e)
        {
            CreateEndGame(e.player);
        }

        //trở về view start
        private void Setup_OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            CreateViewStart();
        }

        #endregion

        #region View EndGame

        //tạo view end game
        void CreateEndGame(Player player)
        {
            endGame endGame = new endGame(player);
            endGame.OnExitButtonClick += EndGame_OnExitButtonClick;
            view.Content = endGame;
        }

        //trở về view start
        private void EndGame_OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            CreateViewStart();
        }

        #endregion

        #region Hàm khác

        //di chuyển cửa sổ
        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        //thu nhỏ cửa sổ
        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        //hiện quitbox
        public void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            QuitBox.Visibility = Visibility.Visible;
        }

        //đóng cửa sổ
        private void Yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        //giữ nguyên
        private void No_MouseDown(object sender, MouseButtonEventArgs e)
        {
            QuitBox.Visibility = Visibility.Hidden;
        }

        #endregion
    }
}
