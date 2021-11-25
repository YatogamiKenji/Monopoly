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
    /// Interaction logic for ListContentPlayers.xaml
    /// </summary>
    public partial class ListContentPlayers : UserControl
    {

        List<ContentPlayer> ListPlayers = new List<ContentPlayer>();
        public ListContentPlayers()//List<ContentPlayer> QuantityPlayers)
        {
            InitializeComponent();
            // ListPlayers = QuantityPlayers;
           // ListPlayers.Add(new ContentPlayer { NamePlayer = "Player 1" }); ;
            //ListPlayers.Add(new ContentPlayer { NamePlayer = "Player 2" });
            ListPlayers.Add(new ContentPlayer { NamePlayer = "Player 3" });
            SetGridPosition();
        }

        void SetGridPosition()
        {
            int t = ListPlayers.Count;
           
            {
                for (int i = 0; i < Math.Ceiling((decimal)t / 3 ); i++)
                {
                    var rowDefinition = new RowDefinition();
                    rowDefinition.Height = GridLength.Auto;
                    ListContentPlayersGrid.RowDefinitions.Add(rowDefinition);

                }

                for (int i = 0; i < t; i++)
                {
                    ContentPlayer x = new ContentPlayer();
                    x.Margin = new Thickness(2, 2, 2, 2);
                    x.Width = 93;
                    x.Height = 160;
                    x.SetValue(Grid.RowProperty, (int)Math.Floor((decimal)i / 3));
                    x.SetValue(Grid.ColumnProperty, (int)Math.Floor((decimal)i % 3));
                    ListContentPlayersGrid.Children.Add(x);
                }
            }
        }
       

    }
}
