using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for BtnLandCard.xaml
    /// </summary>
    public delegate void BtnLandCardClickEventHandler(object sender, BtnLandCardClickEventArgs agrs);

    public partial class BtnLandCard : UserControl
    {
        public static RoutedEvent BtnLandCardCLickEvent =
            EventManager.RegisterRoutedEvent("OnSpinnedDice", RoutingStrategy.Bubble, typeof(BtnLandCardClickEventHandler), typeof(BtnLandCard));

        public event BtnLandCardClickEventHandler OnBtnLandCardClick
        {
            add
            {
                AddHandler(BtnLandCardCLickEvent, value);
            }
            remove
            {
                RemoveHandler(BtnLandCardCLickEvent, value);
            }
        }

        public Land Land
        {
            get { return (Land)GetValue(landProperty); }
            set { SetValue(landProperty, value); }
        }

        // Using a DependencyProperty as the backing store for power.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty landProperty =
            DependencyProperty.Register("land", typeof(Land), typeof(BtnLandCard));

        public int Id
        {
            get { return (int)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Id.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IdProperty =
            DependencyProperty.Register("Id", typeof(int), typeof(BtnLandCard), new PropertyMetadata(0));

        public bool IsSelected
        {
            get { return (bool)GetValue(IsSelectedProperty); }
            set { SetValue(IsSelectedProperty, value); setHighLight(); }
        }

        // Using a DependencyProperty as the backing store for IsSelected.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IsSelectedProperty =
            DependencyProperty.Register("IsSelected", typeof(bool), typeof(BtnLandCard), new PropertyMetadata(false));

        // Using a DependencyProperty as the backing store for EnoughMoneyToUse.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty EnoughMoneyToUseProperty =
            DependencyProperty.Register("EnoughMoneyToUse", typeof(bool), typeof(BtnLandCard), new PropertyMetadata(true));

        public BtnLandCard()
        {
            InitializeComponent();

        }

        public BtnLandCard(Land land, int idCard)
        {
            InitializeComponent();
            Id = idCard;
            Land = land;
            landCard.Children.Add(new LandCard(Land));
            cantUseLayer.Opacity = 0;
        }

        void setHighLight()
        {
            if (IsSelected)
            {
                imgHighlight.Opacity = 1;
            }
            else
            {
                imgHighlight.Opacity = 0;
            }
        }

        private void BtnLandCardClickFunc(object sender, MouseButtonEventArgs e)
        {
            Sound.Planet();
            RaiseEvent(new BtnLandCardClickEventArgs(BtnLandCardCLickEvent, this) { land = Land, idCard = Id });
        }

        private void HandleBtnLandCardHover(object sender, MouseEventArgs e)
        {
            imgHighlight.Opacity = 1;
            Cursor = Cursors.Hand;
        }

        private void HandleBtnLandCardLeave(object sender, MouseEventArgs e)
        {
            if (!IsSelected) imgHighlight.Opacity = 0;
        }
    }
}
