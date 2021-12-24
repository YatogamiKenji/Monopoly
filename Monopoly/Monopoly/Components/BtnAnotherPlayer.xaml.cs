using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for BtnAnotherPlayer.xaml
    /// </summary>
    public delegate void BtnAnotherPlayerClickEventHandler(object sender, BtnAnotherPlayerClickEventArgs agrs);

    public partial class BtnAnotherPlayer : UserControl
    {
        public static readonly RoutedEvent ClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnClick), RoutingStrategy.Bubble, typeof(BtnAnotherPlayerClickEventHandler), typeof(UseCardView));
        public event BtnAnotherPlayerClickEventHandler OnClick
        {
            add { AddHandler(ClickEvent, value); }
            remove { RemoveHandler(ClickEvent, value); }
        }


        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(BtnAnotherPlayer), new PropertyMetadata(0));


        public ImageSource Avatar
        {
            get { return (ImageSource)GetValue(AvatarProperty); }
            set { SetValue(AvatarProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AvatarProperty =
            DependencyProperty.Register("Avatar", typeof(ImageSource), typeof(BtnAnotherPlayer), new PropertyMetadata());
        
        public string PlayerName
        {
            get { return (string)GetValue(PlayerNameProperty); }
            set { SetValue(PlayerNameProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PlayerName.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayerNameProperty =
            DependencyProperty.Register("PlayerName", typeof(string), typeof(BtnAnotherPlayer), new PropertyMetadata(""));


        public int Money
        {
            get { return (int)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Money.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoneyProperty =
            DependencyProperty.Register("Money", typeof(int), typeof(BtnAnotherPlayer), new PropertyMetadata(0));


        public BtnAnotherPlayer(int id, ImageSource avatar, string playerName, int money)
        {
            InitializeComponent();
            Id = id;
            Avatar = avatar;
            PlayerName = playerName;
            Money = money;
        }

        private void Grid_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Sound.Player();
            RaiseEvent(new BtnAnotherPlayerClickEventArgs(ClickEvent, this){ idPlayer = Id });
        }
    }
}
