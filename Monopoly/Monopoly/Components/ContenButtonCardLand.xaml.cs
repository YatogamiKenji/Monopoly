using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Monopoly.Components
{

    /// <summary>
    /// Interaction logic for ContenButtonCard.xaml
    /// </summary>
    public partial class ContenButtonCardLand : UserControl
    {

        public string IDCard; // loaị class thẻ
        public Land land;

        //PowerCard typeCard; // 
        public static readonly RoutedEvent ButtonCardClickEvent =
          EventManager.RegisterRoutedEvent(nameof(OnButtonCardClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContenButtonCardLand));

        public event RoutedEventHandler OnButtonCardClick
        {
            add { AddHandler(ButtonCardClickEvent, value); }
            remove { RemoveHandler(ButtonCardClickEvent, value); }
        }

        private void ButtonCard_Click(object sender, RoutedEventArgs e)
        {
            Sound.Planet();
            RaiseEvent(new RoutedEventArgs(ButtonCardClickEvent));
        }

        // Button ButtonCard;
        public ContenButtonCardLand()
        {
            InitializeComponent();
        }

        public ContenButtonCardLand(LandCard typeCard, Land land)
        {
            InitializeComponent();
            this.land = land;
            Bor_PicCard.Children.Add(typeCard);
            IDCard = typeCard.TypeCard;
        }
    }
}
