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
    /// Interaction logic for ListCardPlayers.xaml
    /// </summary>
    public partial class ListCardPlayers : UserControl
    {


        public List<Power> Powers; //= new List<Power>();
        public List<ContenButtonCard> contenButtonCards;// = new List<ContenButtonCard>();
        //{
        //    get { return (List<Power>)GetValue(PowersProperty); }
        //    set { SetValue(PowersProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for Lands.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty PowersProperty =
        //    DependencyProperty.Register("Powers", typeof(List<Power>), typeof(ListCardPlayers));

        public ListCardPlayers()
        {
            InitializeComponent();
            createPowersCards();
        }
        public ListCardPlayers(List<Power> powers)
        {
            InitializeComponent();
            Powers = powers;
            contenButtonCards = new List<ContenButtonCard>();
            //PowerAppointPersonToPrison x = new PowerAppointPersonToPrison();
            //ContenButtonCard testCard = new ContenButtonCard(new PowerCard(x));
            //contenButtonCards.Add(testCard);
            createPowersCards();
        }
        //public ListCardPlayers(ListCardSideBar Cardpowers)
        //{
        //    InitializeComponent();
        //    Powers = Cardpowers.powers;
        //    createPowersCards();
        //}
        private void createPowersCards()
        {
            if (Powers != null)
            {
                for (int i = 0; i < Math.Ceiling((decimal)Powers.Count / 3); i++)
                {
                    var rowDefinition = new RowDefinition();
                    rowDefinition.Height = GridLength.Auto;
                    listCardPlayersGrid.RowDefinitions.Add(rowDefinition);

                }
                for (int i = 0; i < Powers.Count; i++)
                {
                  
                    
                    ContenButtonCard butCard = new ContenButtonCard(new PowerCard(Powers[i]), Powers[i]);
                    butCard.Margin = new Thickness(2, 2, 2, 2);
                    butCard.Width = 110;
                    butCard.Height = 145;
                    butCard.SetValue(Grid.RowProperty, (int)Math.Floor((decimal)i / 3));
                    butCard.SetValue(Grid.ColumnProperty, (int)Math.Floor((decimal)i % 3));
                    listCardPlayersGrid.Children.Add(butCard);
                    contenButtonCards.Add(butCard);
                  //butCard.OnButtonCardClick += ButCard_OnButtonCardClick;
                }
            }

        }

    
    }
}
