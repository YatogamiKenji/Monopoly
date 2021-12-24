using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ListCardPlayers.xaml
    /// </summary>
    public partial class ListCardPlayers : UserControl
    {
        public List<Power> Powers;
        public List<ContenButtonCardPower> contenButtonCards;

        public ListCardPlayers()
        {
            InitializeComponent();
            createPowersCards();
        }

        public ListCardPlayers(List<Power> powers)
        {
            InitializeComponent();
            Powers = powers;
            contenButtonCards = new List<ContenButtonCardPower>();
            createPowersCards();
        }

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
                    ContenButtonCardPower butCard = new ContenButtonCardPower(new PowerCard(Powers[i]), Powers[i]);
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
