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
using Monopoly;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ListCardSideBar.xaml
    /// </summary>
    public partial class ListCardSideBar : UserControl
    {

        List<Power> powers = new List<Power>();
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
                PowerCard powerCard = new PowerCard();
                powerCard.Title = card.name;
                powerCard.Description = card.description;
                //powerCard.ImgSource = card.ImgSource;
                powerCard.Price = card.value;
                powerCard.Width = 97;
                powerCard.Height = 129;
                powerCard.Margin = new Thickness(2, 0, 2, 0);
                listCardSideBarPanel.Children.Add(powerCard);
            }
            if (isPrison)
            {
                LuckCard luckCard = new LuckCard();
                luckCard.Title = "Ra tù";
                luckCard.Description = "Ra tù";
                //luckCard.ImgSource =;
                luckCard.Width = 97;
                luckCard.Height = 129;
                luckCard.Margin = new Thickness(2, 0, 2, 0);
                listCardSideBarPanel.Children.Add(luckCard);
            }
        }
    }
}
