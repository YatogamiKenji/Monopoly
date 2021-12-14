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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ContentChessCell.xaml
    /// </summary>
    public partial class ContentChessCell : UserControl
    {


        private Storyboard sShaking; // sự kiện rung ô đất để lựa chọn;
        public ImageSource ImageCell
        {
            get { return (ImageSource)GetValue(ImageCellProperty); }
            set { SetValue(ImageCellProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageCellProperty =
            DependencyProperty.Register("ImageCell", typeof(ImageSource), typeof(ContentChessCell));

        public static readonly RoutedEvent ButtonChessCellClickEvent =
   EventManager.RegisterRoutedEvent(nameof(OnButtonChessCellClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContentChessCell));

        public event RoutedEventHandler OnButtonChessCellClick
        {
            add { AddHandler(ButtonChessCellClickEvent, value); }
            remove { RemoveHandler(ButtonChessCellClickEvent, value); }
        }

        public ContentChessCell()
        {
            InitializeComponent();
            //Storyboard s = (Storyboard) myrect.FindResource("rung");
            //s.Begin();  // Start animation


        }

        private void ButChessCell_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonChessCellClickEvent));
        }

        public void StartShaking()
        {
          
            sShaking = (Storyboard)ButChessCell.FindResource("rung");
            sShaking.Begin();
        }
        public void StopShaking()
        {
            sShaking.Stop();
        }
    }
}