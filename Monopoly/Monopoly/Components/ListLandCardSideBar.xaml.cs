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
    /// Interaction logic for ListLandCardSideBar.xaml
    /// </summary>
    public partial class ListLandCardSideBar : UserControl
    {


        public List<Land> Lands
        {
            get { return (List<Land>)GetValue(LandsProperty); }
            set { SetValue(LandsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Lands.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LandsProperty =
            DependencyProperty.Register("Lands", typeof(List<Land>), typeof(ListLandCardSideBar));

        public ListLandCardSideBar()
        {
            InitializeComponent();
            createLandCards();
        }
        public ListLandCardSideBar(List<Land> lands)
        {
            InitializeComponent();
            Lands = lands;
            createLandCards();
        }

        private void createLandCards()
        {

            if (Lands != null)
            {
                for (int i = 0; i < Math.Ceiling((decimal)Lands.Count / 3); i++)
                {
                    var rowDefinition = new RowDefinition();
                    rowDefinition.Height = GridLength.Auto;
                    listLandCardSideBarGrid.RowDefinitions.Add(rowDefinition);

                }
                for (int i = 0; i < Lands.Count; i++)
                {
                    LandCard landCard = new LandCard(Lands[i]);

                    landCard.Margin = new Thickness(2, 2, 2, 2);
                    landCard.Width = 97;
                    landCard.Height = 131;
                    landCard.SetValue(Grid.RowProperty, (int)Math.Floor((decimal)i / 3));
                    landCard.SetValue(Grid.ColumnProperty, (int)Math.Floor((decimal)i % 3));
                    listLandCardSideBarGrid.Children.Add(landCard);
                }
            }

        }

    }


}
