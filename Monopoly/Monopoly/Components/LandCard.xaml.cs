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
    /// Interaction logic for LandCard.xaml
    /// </summary>
    public partial class LandCard : UserControl
    {
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LandCard), new PropertyMetadata("Tên mặc định"));



        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Level.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(int), typeof(LandCard), new PropertyMetadata(0));



        public int Tax
        {
            get { return (int)GetValue(TaxProperty); }
            set { SetValue(TaxProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Tax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaxProperty =
            DependencyProperty.Register("Tax", typeof(int), typeof(LandCard), new PropertyMetadata(0));


        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(LandCard), new PropertyMetadata(0));

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(LandCard));

        public LandCard()
        {
            InitializeComponent();
        }
    }
}