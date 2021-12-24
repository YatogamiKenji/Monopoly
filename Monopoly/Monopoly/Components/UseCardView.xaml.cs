using System.Collections.Generic;
using System.Windows;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for UseCardView.xaml
    /// </summary>
    public delegate void UseACardButtonClickEventHandler(object sender, UseACardButtonClickEventArgs agrs);
    public partial class UseCardView : BaseCenterMapView
    {
        public static readonly RoutedEvent CancleButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnCancleButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(UseCardView));
        public event RoutedEventHandler OnCancleButtonClick
        {
            add { AddHandler(CancleButtonClickEvent, value); }
            remove { RemoveHandler(CancleButtonClickEvent, value); }
        }

        public static RoutedEvent UseACardButtonClickEvent =
           EventManager.RegisterRoutedEvent("OnUseACardButtonClick", RoutingStrategy.Bubble, typeof(UseACardButtonClickEventHandler), typeof(UseCardView));
        public event UseACardButtonClickEventHandler OnUseACardButtonClick
        {
            add
            {
                AddHandler(UseACardButtonClickEvent, value);
            }
            remove
            {
                RemoveHandler(UseACardButtonClickEvent, value);
            }
        }

        public Player player
        {
            get { return (Player)GetValue(playerProperty); }
            set { SetValue(playerProperty, value); }
        }
        // Using a DependencyProperty as the backing store for player.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty playerProperty =
            DependencyProperty.Register("player", typeof(Player), typeof(UseCardView));

        private int selectedIndex = 0;
        private List<BtnCard> listBtnCard = new List<BtnCard>();

        private int _currentPriceCard;
        public int currentPriceCard
        {
            get { return _currentPriceCard; }
            set { _currentPriceCard = value; }
        }

        private int _valueOfDice = 1;

        public UseCardView(Player currentPlayer, int valueOfDice)
        {
            this.DataContext = this;
            InitializeComponent();
            player = currentPlayer;
            _valueOfDice = valueOfDice;
            if (player.powers != null)
            {
                List<Power> powers = player.powers;
                for (int i = 0; i < powers.Count; i++)
                {
                    bool isEnoughMoneyToUse = true;
                    if (valueOfDice * powers[i].value > player.money)
                        isEnoughMoneyToUse = false;
                    listBtnCard.Add(new BtnCard(powers[i], i, isEnoughMoneyToUse));
                }

                if (player.isOutPrisonCard)
                    listBtnCard.Add(new BtnCard(new ChanceOutPrison(), powers.Count));

                for (int i = 0; i < listBtnCard.Count; i++)
                {
                    listBtnCard[i].OnBtnCardClick += UseCardView_OnBtnCardClick;
                    listBtnCard[i].Margin = new Thickness(2, 2, 2, 2);
                    listCardUseCardView.Children.Add(listBtnCard[i]);
                }

                listBtnCard[selectedIndex].IsSelected = true;
                updatePowerDetailInfo();
            }

        }

        private void UseCardView_OnBtnCardClick(object sender, BtnCardClickEventArgs e)
        {
            selectedIndex = e.idCard;
            

            // Highlight thẻ được chọn
            for (int i = 0; i < listBtnCard.Count; i++)
            {
                listBtnCard[i].IsSelected = false;
            }
            listBtnCard[selectedIndex].IsSelected = true;

            // Upate thông tin chi tiết
            updatePowerDetailInfo();
        }

        void updatePowerDetailInfo ()
        {
            if (selectedIndex == player.powers.Count)
            {
                if (player.isInPrison)
                {
                    currentPriceCard = 0;
                }
                else currentPriceCard = 1000;
                mainDescription.Text = new ChanceOutPrison().description;
            }
            else
            {
                currentPriceCard = player.powers[selectedIndex].value * _valueOfDice;
                mainDescription.Text = player.powers[selectedIndex].description;
            }
        }

        private void CancleButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(CancleButtonClickEvent));
        }

        Power power = new Power();

        private void UseACardButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.ButtonUsePower();
            if (selectedIndex < player.powers.Count) power = player.powers[selectedIndex];

            RaiseEvent(new UseACardButtonClickEventArgs(UseACardButtonClickEvent, this)
            {
                power = power,
                isEnoughMoneyToUse = currentPriceCard <= player.money ? true : false,
            });
        }
    }
}
