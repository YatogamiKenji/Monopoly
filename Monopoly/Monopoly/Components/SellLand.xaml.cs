using System.Collections.Generic;
using System.Windows;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for UseCardView.xaml
    /// </summary>
    public delegate void SellLandButtonClickEventHandler(object sender, SellLandButtonClickEventArgs agrs);

    public partial class SellLand : BaseCenterMapView
    {
        public static readonly RoutedEvent CancleButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnCancleButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(SellLand));
        
        public event RoutedEventHandler OnCancleButtonClick
        {
            add { AddHandler(CancleButtonClickEvent, value); }
            remove { RemoveHandler(CancleButtonClickEvent, value); }
        }

        public static RoutedEvent SellLandButtonClickEvent =
           EventManager.RegisterRoutedEvent("OnSellLandButtonClick", RoutingStrategy.Bubble, typeof(SellLandButtonClickEventHandler), typeof(SellLand));
        
        public event SellLandButtonClickEventHandler OnSellLandButtonClick
        {
            add
            {
                AddHandler(SellLandButtonClickEvent, value);
            }
            remove
            {
                RemoveHandler(SellLandButtonClickEvent, value);
            }
        }

        public Player player
        {
            get { return (Player)GetValue(playerProperty); }
            set { SetValue(playerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for player.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty playerProperty =
            DependencyProperty.Register("player", typeof(Player), typeof(SellLand));

        private int selectedIndex = 0;
        private List<BtnLandCard> listBtnCard = new List<BtnLandCard>();

        private int _currentPriceCard;
        public int currentPriceCard
        {
            get { return _currentPriceCard; }
            set { _currentPriceCard = value; }
        }

        public SellLand(Player currentPlayer)
        {
            this.DataContext = this;
            InitializeComponent();
            player = currentPlayer;
            if (player.lands != null)
            {
                List<Land> lands = player.lands;
                for (int i = 0; i < lands.Count; i++)
                    listBtnCard.Add(new BtnLandCard(lands[i], i));

                for (int i = 0; i < listBtnCard.Count; i++)
                {
                    listBtnCard[i].OnBtnLandCardClick += SellLand_OnBtnLandCardClick;
                    listBtnCard[i].Margin = new Thickness(2, 2, 2, 2);
                    listCardUseCardView.Children.Add(listBtnCard[i]);
                }

                listBtnCard[selectedIndex].IsSelected = true;
                updateLandDetailInfo();
            }

        }

        private void SellLand_OnBtnLandCardClick(object sender, BtnLandCardClickEventArgs e)
        {
            selectedIndex = e.idCard;

            // Highlight thẻ được chọn
            for (int i = 0; i < listBtnCard.Count; i++)
            {
                listBtnCard[i].IsSelected = false;
            }
            listBtnCard[selectedIndex].IsSelected = true;

            // Upate thông tin chi tiết
            updateLandDetailInfo();
        }

        void updateLandDetailInfo()
        {
            currentPriceCard = player.lands[selectedIndex].value / 2;
            mainDescription.Text = player.lands[selectedIndex].description + "Giá trị: " + player.lands[selectedIndex].value;
        }

        private void CancleButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(CancleButtonClickEvent));
        }

        private void SellLandButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            RaiseEvent(new SellLandButtonClickEventArgs(SellLandButtonClickEvent, this)
            {
                land = player.lands[selectedIndex],
                index = selectedIndex
            });
        }
    }
}
