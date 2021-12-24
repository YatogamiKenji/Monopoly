using System.Windows;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ComeOwnLandView.xaml
    /// </summary>
    public partial class ComeOwnLandView : BaseCenterMapView
    {
        private Land _land;
        public Land land
        {
            get { return _land; }
            set { _land = value; }
        }


        public static readonly RoutedEvent UpgradeButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnUpgradeButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnUpgradeButtonClick
        {
            add { AddHandler(UpgradeButtonClickEvent, value); }
            remove { RemoveHandler(UpgradeButtonClickEvent, value); }
        }

        private void UpgradeButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.Upgrade();
            RaiseEvent(new RoutedEventArgs(UpgradeButtonClickEvent));
        }



        public static readonly RoutedEvent UseCardButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnUseCardButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnUseCardButtonClick
        {
            add { AddHandler(UseCardButtonClickEvent, value); }
            remove { RemoveHandler(UseCardButtonClickEvent, value); }
        }

        private void UseCardButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.ButtonUsePower();
            RaiseEvent(new RoutedEventArgs(UseCardButtonClickEvent));
        }



        public static readonly RoutedEvent SkipButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnSkipButtonClick
        {
            add { AddHandler(SkipButtonClickEvent, value); }
            remove { RemoveHandler(SkipButtonClickEvent, value); }
        }

        private void SkipButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(SkipButtonClickEvent));
        }


        public static readonly RoutedEvent SellButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSellButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnSellButtonClick
        {
            add { AddHandler(SellButtonClickEvent, value); }
            remove { RemoveHandler(SellButtonClickEvent, value); }
        }

        private void SellButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BuyButton();
            RaiseEvent(new RoutedEventArgs(SellButtonClickEvent));
        }
        public ComeOwnLandView(Land land, int fee)
        {
            InitializeComponent();
            _land = land;
            stateOfLandText.Text = "Cấp " + land.level;
            landPriceSellButtonText.Text = _land.landValue / 2 + "";
            landPriceUpgradeButtonText.Text = _land.Upgrade(_land.level + 1) / fee + "";
            thisLandCard.setInfor(land);

        }
    }
}
