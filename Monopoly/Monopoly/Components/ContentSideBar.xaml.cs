using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ContentSideBar.xaml
    /// </summary>
    /// 


    public partial class ContentSideBar : UserControl
    {



        public int Money
        {
            get { return (int)GetValue(MoneyProperty); }
            set { SetValue(MoneyProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Money.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MoneyProperty =
            DependencyProperty.Register("Money", typeof(int), typeof(ContentSideBar), new PropertyMetadata(0));



        public List<Land> Lands
        {
            get { return (List<Land>)GetValue(LandsProperty); }
            set { SetValue(LandsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lands.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LandsProperty =
            DependencyProperty.Register("Lands", typeof(List<Land>), typeof(ContentSideBar));


     //   private Player _player; // người chơi hiện tại

        public ContentSideBar(int money, List<Land> lands)
        {
            InitializeComponent();
            Money = money;
            Lands = lands;
            landHeading.Text = "Đất (" + Lands?.Count + "):";
            listLandCard.Content = new ListLandCardSideBar(Lands);
        }

        public ContentSideBar(Player player)
        {
            InitializeComponent();
           // _player = player;
            Money = player.money;
            Lands = player.lands;
            landHeading.Text = "Đất (" + Lands?.Count + "):";
            cardHeading.Text = "Thẻ (" + player.powers?.Count + "):";
            listCardSideBar.Content = new ListCardSideBar(player.powers, player.isOutPrisonCard);
            listLandCard.Content = new ListLandCardSideBar(Lands);
        }
    }
}
