using System.Windows;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ComeEmptyLandView.xaml
    /// </summary>
    public partial class ComeEmptyLandView : BaseCenterMapView
    {

        private Land _land;
        public Land land
        {
            get { return _land; }
            set { _land = value; }
        }


        public static readonly RoutedEvent BuyButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBuyButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

        public event RoutedEventHandler OnBuyButtonClick
        {
            add { AddHandler(BuyButtonClickEvent, value); }
            remove { RemoveHandler(BuyButtonClickEvent, value); }
        }

        private void BuyButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BuyButton();
            RaiseEvent(new RoutedEventArgs(BuyButtonClickEvent));
        }



        public static readonly RoutedEvent UseCardButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnUseCardButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

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
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

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

        public ComeEmptyLandView(Land land)
        {
            this.DataContext = this;
            InitializeComponent();
            _land = land;
            landPriceButtonText.Text = _land.value.ToString();
            thisLandCard.setInfor(_land);
        }

    }
}