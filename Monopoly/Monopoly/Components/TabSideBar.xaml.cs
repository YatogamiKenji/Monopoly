using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for TabSideBar.xaml
    /// </summary>
    public partial class TabSideBar : UserControl
    {

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(TabSideBar), new PropertyMetadata(0));


        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(TabSideBar), new PropertyMetadata());




        public string PlayerName
        {
            get { return (string)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerNameProperty =
            DependencyProperty.Register("PlayerName", typeof(string), typeof(TabSideBar), new PropertyMetadata(""));



        public int Money
        {
            get { return (int)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Money.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoneyProperty =
            DependencyProperty.Register("Money", typeof(int), typeof(TabSideBar), new PropertyMetadata(0));



        public ImageSource IconPlayerImg
        {
            get { return (ImageSource)GetValue(IconPlayerImgProperty); }
            set { SetValue(IconPlayerImgProperty, value); }
        }

        // Using a DependencyProperty as the backing store for IconPlayerImg.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPlayerImgProperty =
            DependencyProperty.Register("IconPlayerImg", typeof(ImageSource), typeof(TabSideBar), new PropertyMetadata());



        public TabSideBar(int id, ImageSource imgSource, string playerName, int money, ImageSource iconPlayerImg)
        {
            InitializeComponent();
            Id = id;
            ImgSource = imgSource;
            PlayerName = playerName;
            Money = money;
            IconPlayerImg = iconPlayerImg;
        }

        public void SetBg(string state)
        {
            if (state == "selected")
                imgBg.Source = new BitmapImage(new Uri(@"/Monopoly;component/Images/sidebar/tab_sidebar_selected.png", UriKind.Relative));
            else if (state == "disable")
                imgBg.Source = new BitmapImage(new Uri(@"/Monopoly;component/Images/sidebar/tab_sidebar_disable.png", UriKind.Relative));
            else
                imgBg.Source = new BitmapImage(new Uri(@"/Monopoly;component/Images/sidebar/tab_sidebar.png", UriKind.Relative));
        }
    }
}
