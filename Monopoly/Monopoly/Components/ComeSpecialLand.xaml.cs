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
    /// Interaction logic for ComeSpecialLand.xaml
    /// </summary>
    public partial class ComeSpecialLand : UserControl
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ComeSpecialLand), new PropertyMetadata("Tên ô"));

        public ComeSpecialLand(PowerCard powerCard)
        {
            InitializeComponent();
            Title = "Ô QUYỀN NĂNG";
             
            Grid.SetRow(powerCard, 1);

            powerCard.Height = 210;
            powerCard.Width = 160;
           powerCard.HorizontalAlignment = HorizontalAlignment.Center;
           powerCard.VerticalAlignment = VerticalAlignment.Top;     
            NoticeTakeCard.Children.Add(powerCard);
        }


        public static readonly RoutedEvent OKButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnOKButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeSpecialLand));

        public event RoutedEventHandler OnOKButtonClick
        {
            add { AddHandler(OKButtonClickEvent, value); }
            remove { RemoveHandler(OKButtonClickEvent, value); }
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(OKButtonClickEvent));
        }


        




    }
}
