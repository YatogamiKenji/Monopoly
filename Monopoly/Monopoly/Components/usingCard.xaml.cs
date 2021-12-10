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

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for usingCard.xaml
    /// </summary>
    public partial class usingCard : UserControl
    {
        public usingCard()
        {
            InitializeComponent();
        }

        public usingCard(ListCardPlayers listCardPlayers)
        {
            InitializeComponent();
            Grid.SetRow(listCardPlayers, 1);
            ListCard.Children.Add(listCardPlayers);

        }

        public static readonly RoutedEvent ButtonCancleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnButtonCancleClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContenButtonCard));

        public event RoutedEventHandler OnButtonCancleClick
        {
            add { AddHandler(ButtonCancleClickEvent, value); }
            remove { RemoveHandler(ButtonCancleClickEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonCancleClickEvent));
        }
    }
}
