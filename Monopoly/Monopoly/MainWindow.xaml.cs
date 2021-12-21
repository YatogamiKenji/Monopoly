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

        void CreateViewStart()
        {
            ViewStart viewStart = new ViewStart();
            viewStart.OnQuitButtonClick += ViewStart_OnQuitButtonClick;
            viewStart.OnPlayButtonClick += ViewStart_OnPlayButtonClick;
            view.Content = viewStart;
        }

        void CreateSetup()
        {
            Setup setup = new Setup();
            setup.OnBackButtonClick += Setup_OnBackButtonClick;
            setup.OnButtonGoClick += Setup_OnButtonGoClick;
            view.Content = setup;
        }    

        private void ViewStart_OnPlayButtonClick(object sender, RoutedEventArgs e)
        {
            CreateSetup();
        }

        private void Setup_OnButtonGoClick(object sender, GoClickEventArgs e)
        {
            ChessBoard chessBoard = new ChessBoard(e.showPlayers, e.GameMode, e.NumberTurns);
            view.Content = chessBoard;
        }

        private void Setup_OnBackButtonClick(object sender, RoutedEventArgs e)
        {
            CreateViewStart();
        }

        private void ViewStart_OnQuitButtonClick(object sender, RoutedEventArgs e)
        {
            QuitBox.Visibility = Visibility.Visible;
        }

        private void DockPanel_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            base.OnMouseLeftButtonDown(e);
            this.DragMove();
        }

        private void Image_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            WindowState = WindowState.Minimized;
        }

        public void Image_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            QuitBox.Visibility = Visibility.Visible;
        }

        private void Yes_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }

        private void No_MouseDown(object sender, MouseButtonEventArgs e)
        {
            QuitBox.Visibility = Visibility.Hidden;
        }
    }
}
