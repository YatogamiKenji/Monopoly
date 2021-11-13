﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Monopoly;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    /// 

    public partial class SideBar : UserControl, INotifyPropertyChanged

    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public int SelectedId
        {
            get { return (int)GetValue(SelectedIdProperty); }
            set { SetValue(SelectedIdProperty, value); OnPropertyChanged(); }
        }

        // Using a DependencyProperty as the backing store for SelectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIdProperty =
            DependencyProperty.Register("SelectedId", typeof(int), typeof(SideBar), new PropertyMetadata(0));




        public List<Player> Players
        {
            get { return (List<Player>)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value); OnPropertyChanged(); }
        }

        // Using a DependencyProperty as the backing store for Players.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayersProperty =
            DependencyProperty.Register("Players", typeof(List<Player>), typeof(SideBar));



        public SideBar()
        {
            InitializeComponent();
            Players = new List<Player>();
        }
    }
}