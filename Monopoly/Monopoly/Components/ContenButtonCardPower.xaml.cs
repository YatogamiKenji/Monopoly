using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{

    /// <summary>
    /// Interaction logic for ContenButtonCard.xaml
    /// </summary>
    public partial class ContenButtonCardPower : UserControl
    {

        public string IDCard; // loaị class thẻ
        public Power power;

        //PowerCard typeCard; // 
        public static readonly RoutedEvent ButtonCardClickEvent =
          EventManager.RegisterRoutedEvent(nameof(OnButtonCardClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContenButtonCardPower));

        public event RoutedEventHandler OnButtonCardClick
        {
            add { AddHandler(ButtonCardClickEvent, value); }
            remove { RemoveHandler(ButtonCardClickEvent, value); }
        }

        private void ButtonCard_Click(object sender, RoutedEventArgs e)
        {
            Sound.ButtonUsePower();
            RaiseEvent(new RoutedEventArgs(ButtonCardClickEvent));
        }

        // Button ButtonCard;
        public ContenButtonCardPower()
        {
            InitializeComponent();
        }

        public ContenButtonCardPower(PowerCard typeCard, Power power)
        {
            InitializeComponent();
            this.power = power;
            Bor_PicCard.Children.Add(typeCard);
            IDCard = typeCard.TypeCard;
        }
    }
}
