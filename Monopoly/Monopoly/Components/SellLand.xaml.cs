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
    /// Interaction logic for SellLand.xaml
    /// </summary>
    public partial class SellLand : UserControl
    {
        public SellLand()
        {
            InitializeComponent();
        }

        public SellLand(ListLandPlayers listLandPlayers)
        {
            InitializeComponent();
            Grid.SetRow(listLandPlayers, 1);
            ListCard.Children.Add(listLandPlayers);
        }

        public static readonly RoutedEvent ButtonCancleClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnButtonCancleClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContenButtonCard));

        public event RoutedEventHandler OnButtonCancleClick
        {
            add { AddHandler(ButtonCancleClickEvent, value); }
            remove { RemoveHandler(ButtonCancleClickEvent, value); }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonCancleClickEvent));
        }
    }
}
