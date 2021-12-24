using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ListLandPlayers.xaml
    /// </summary>
    public partial class ListLandPlayers : UserControl
    {
        List<Land> Lands;
        public List<ContenButtonCardLand> contenButtonCards;

        public ListLandPlayers()
        {
            InitializeComponent();
        }

        public ListLandPlayers(List<Land> lands)
        {
            InitializeComponent();
            Lands = lands;
            contenButtonCards = new List<ContenButtonCardLand>();
            createPowersCards();
        }

        private void createPowersCards()
        {
            if (Lands != null)
            {
                for (int i = 0; i < Math.Ceiling((decimal)Lands.Count / 3); i++)
                {
                    var rowDefinition = new RowDefinition();
                    rowDefinition.Height = GridLength.Auto;
                    listCardPlayersGrid.RowDefinitions.Add(rowDefinition);

                }
                for (int i = 0; i < Lands.Count; i++)
                {
                    ContenButtonCardLand butCard = new ContenButtonCardLand(new LandCard(Lands[i]), Lands[i]);
                    butCard.Margin = new Thickness(2, 2, 2, 2);
                    butCard.Width = 110;
                    butCard.Height = 145;
                    butCard.SetValue(Grid.RowProperty, (int)Math.Floor((decimal)i / 3));
                    butCard.SetValue(Grid.ColumnProperty, (int)Math.Floor((decimal)i % 3));
                    listCardPlayersGrid.Children.Add(butCard);
                    contenButtonCards.Add(butCard);
                }
            }

        }
    }
}
