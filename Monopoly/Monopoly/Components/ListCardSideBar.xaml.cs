using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ListCardSideBar.xaml
    /// </summary>
    public partial class ListCardSideBar : UserControl
    {

        public  List<Power> powers = new List<Power>();
        bool isPrison = false;

        public List<object> ListCard
        {
            get { return (List<object>)GetValue(ListCardProperty); }
            set { SetValue(ListCardProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ListCard.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ListCardProperty =
            DependencyProperty.Register("ListCard", typeof(List<object>), typeof(ListCardSideBar));

        public ListCardSideBar()
        {
            InitializeComponent();

            UpdateCard();
        }

        public ListCardSideBar(List<Power> powers, bool prison)
        {
            InitializeComponent();
            this.powers = powers;
            isPrison = prison;
            UpdateCard();
        }

        private void UpdateCard()
        {

           

            foreach (var card in powers)
            {
                PowerCard powerCard = new PowerCard(card);
                powerCard.Margin = new Thickness(2, 0, 2, 0);
                listCardSideBarPanel.Children.Add(powerCard);
            }
            if (isPrison)
            {
                ChanceCard luckCard = new ChanceCard(new ChanceOutPrison());
                luckCard.Width = 101;
                luckCard.Height = 131;
                luckCard.Margin = new Thickness(2, 0, 2, 0);
                listCardSideBarPanel.Children.Add(luckCard);
            }
        }
    }
}
