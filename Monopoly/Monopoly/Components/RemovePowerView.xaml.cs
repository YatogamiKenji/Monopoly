using System.Collections.Generic;
using System.Windows;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for UseCardView.xaml
    /// </summary>
    public delegate void RemoveCardButtonClickEventHandler(object sender, RemoveCardButtonClickEventArgs agrs);

    public partial class RemovePowerView : BaseCenterMapView
    {
        public static readonly RoutedEvent CancleButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnCancleButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(RemovePowerView));
        
        public event RoutedEventHandler OnCancleButtonClick
        {
            add { AddHandler(CancleButtonClickEvent, value); }
            remove { RemoveHandler(CancleButtonClickEvent, value); }
        }

        public static RoutedEvent RemoveCardButtonClickEvent =
           EventManager.RegisterRoutedEvent("RemoveCardButtonClick", RoutingStrategy.Bubble, typeof(RemoveCardButtonClickEventHandler), typeof(RemovePowerView));
        
        public event RemoveCardButtonClickEventHandler OnRemoveCardButtonClick
        {
            add
            {
                AddHandler(RemoveCardButtonClickEvent, value);
            }
            remove
            {
                RemoveHandler(RemoveCardButtonClickEvent, value);
            }
        }

        public Player player
        {
            get { return (Player)GetValue(playerProperty); }
            set { SetValue(playerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for player.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty playerProperty =
            DependencyProperty.Register("player", typeof(Player), typeof(RemovePowerView));

        private int selectedIndex = 0;
        private List<BtnCard> listBtnCard = new List<BtnCard>();

        public RemovePowerView(Player currentPlayer)
        {
            this.DataContext = this;
            InitializeComponent();
            player = currentPlayer;

            if (player.powers != null)
            {
                List<Power> powers = player.powers;
                for (int i = 0; i < powers.Count; i++)
                    listBtnCard.Add(new BtnCard(powers[i], i, true));

                for (int i = 0; i < listBtnCard.Count; i++)
                {
                    listBtnCard[i].OnBtnCardClick += RemoveView_OnBtnCardClick;
                    listBtnCard[i].Margin = new Thickness(2, 2, 2, 2);
                    listCardUseCardView.Children.Add(listBtnCard[i]);
                }

                listBtnCard[selectedIndex].IsSelected = true;
                updatePowerDetailInfo();
            }
        }

        private void RemoveView_OnBtnCardClick(object sender, BtnCardClickEventArgs e)
        {
            selectedIndex = e.idCard;

            // Highlight thẻ được chọn
            for (int i = 0; i < listBtnCard.Count; i++)
                listBtnCard[i].IsSelected = false;
            listBtnCard[selectedIndex].IsSelected = true;

            // Upate thông tin chi tiết
            updatePowerDetailInfo();
        }

        void updatePowerDetailInfo()
        {
            mainDescription.Text = player.powers[selectedIndex].description;
        }

        private void CancleButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.BackButton();
            RaiseEvent(new RoutedEventArgs(CancleButtonClickEvent));
        }

        private void RemoveButtonClickFunc(object sender, RoutedEventArgs e)
        {
            Sound.ButtonUsePower();
            RaiseEvent(new RemoveCardButtonClickEventArgs(RemoveCardButtonClickEvent, this)
            {
                power = player.powers[selectedIndex],
            });
        }
    }
}
