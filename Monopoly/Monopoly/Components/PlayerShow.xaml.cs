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

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for PlayerShow.xaml
    /// </summary>
    public partial class PlayerShow : UserControl
    {


        //public string NamePlayer
        //{
        //    get { return (string)GetValue(NamePlayerProperty); }
        //    set { SetValue(NamePlayerProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty NamePlayerProperty =
        //    DependencyProperty.Register("NamePlayer", typeof(string), typeof(PlayerShow), new PropertyMetadata(""));



        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(PlayerShow), new PropertyMetadata(""));



        public ImageSource BackgroundPlayer
        {
            get { return (ImageSource)GetValue(BackgroundPlayerProperty); }
            set { SetValue(BackgroundPlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty BackgroundPlayerProperty =
            DependencyProperty.Register("BackgroundPlayer", typeof(ImageSource), typeof(PlayerShow));

        public PlayerShow()
        {   
            InitializeComponent();
        }
    }
}
