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

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for messboxDice.xaml
    /// </summary>
    public partial class messboxDice : UserControl
    {
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(messboxDice), new PropertyMetadata(string.Empty));
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public messboxDice()
        {
            InitializeComponent();
        }

        private void close_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
