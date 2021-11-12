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

        //private List<CCard> TestCard;

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
            //TestCard = new List<CCard>();
            //TestCard.Add(new CPowerCard("Dịch chuyển", "Dịch chuyển đến một ô bất kì", new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative)), 150000));
            //TestCard.Add(new CChanceCard("Dịch chuyển", "Dịch chuyển đến một ô bất kì", new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            //TestCard.Add(new CLuckCard("Dịch chuyển", "Dịch chuyển đến một ô bất kì", new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            //TestCard.Add(new CPowerCard("Dịch chuyển", "Dịch chuyển đến một ô bất kì", new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative)), 150000));
            //TestCard.Add(new CChanceCard("Dịch chuyển", "Dịch chuyển đến một ô bất kì", new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            //TestCard.Add(new CLuckCard("Dịch chuyển", "Dịch chuyển đến một ô bất kì", new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));

            UpdateCard();
        }

        private void UpdateCard()
        {
            //foreach(var card in TestCard)
            //{
            //    if (card.Type == "Power")
            //    {
            //        PowerCard c = new PowerCard();
            //        c.Title = card.Title;
            //        c.Description = card.Description;
            //        c.ImgSource = card.ImgSource;
            //        c.Price = ((CPowerCard)card).Price;
            //        c.Width = 97;
            //        c.Height = 129;
            //        c.Margin = new Thickness(2, 0, 2, 0);
            //        listCardSideBarPanel.Children.Add(c);
            //    }
            //    else if (card.Type == "Chance")
            //    {
            //        ChanceCard c = new ChanceCard();
            //        c.Title = card.Title;
            //        c.Description = card.Description;
            //        c.ImgSource = card.ImgSource;
            //        c.Width = 97;
            //        c.Height = 129;
            //        c.Margin = new Thickness(2, 0, 2, 0);
            //        listCardSideBarPanel.Children.Add(c);

            //    }
            //    else if (card.Type == "Luck")
            //    {
            //        LuckCard c = new LuckCard();
            //        c.Title = card.Title;
            //        c.Description = card.Description;
            //        c.ImgSource = card.ImgSource;
            //        c.Width = 97;
            //        c.Height = 129;
            //        c.Margin = new Thickness(2, 0, 2, 0);
            //        listCardSideBarPanel.Children.Add(c);

            //    }
            //}            
        }
    }
}
