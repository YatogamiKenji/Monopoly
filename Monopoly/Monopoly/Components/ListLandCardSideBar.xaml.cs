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
        class TestLand
        {
            public string Title;
            public int Level;
            public int Tax;
            public int Value;
            public ImageSource ImgSource;
            public TestLand(string title, int level, int tax, int value, ImageSource imageSource)
            {
                Title = title;
                Level = level;
                Tax = tax;
                Value = value;
                ImgSource = imageSource;
            }
        }
        private List<TestLand> testLands;


        //public List<object> ListLandCard
        //{
        //    get { return (List<object>)GetValue(ListLandCardProperty); }
        //    set { SetValue(ListLandCardProperty, value); }
        //}

        //// Using a DependencyProperty as the backing store for ListCard.  This enables animation, styling, binding, etc...
        //public static readonly DependencyProperty ListLandCardProperty =
        //    DependencyProperty.Register("ListCard", typeof(List<object>), typeof(ListCardSideBar));

        public ListLandCardSideBar()
        {
            InitializeComponent();
            testLands = new List<TestLand>();
            testLands.Add(new TestLand("Đất 1", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 2", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 3", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 4", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 5", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 1", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 2", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 3", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 4", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            testLands.Add(new TestLand("Đất 5", 3, 12345, 150000, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative))));
            UpdateCard();
        }

        private void UpdateCard()
        {
            for (int i = 0; i < Math.Ceiling((decimal)testLands.Count/3); i++)
            {
                var rowDefinition = new RowDefinition();
                rowDefinition.Height = GridLength.Auto;
                listLandCardSideBarGrid.RowDefinitions.Add(rowDefinition);
            }
            for (int i = 0; i < testLands.Count; i++)
            {
                var land = new LandCard();
                land.Title = testLands[i].Title;
                land.Level = testLands[i].Level;
                land.Tax = testLands[i].Tax;
                land.Value = testLands[i].Value;
                land.ImgSource = testLands[i].ImgSource;
                land.Margin = new Thickness(2, 2, 2, 2);
                land.Width = 93;
                land.Height = 120;
                land.SetValue(Grid.RowProperty, (int)Math.Floor((decimal)i/3));
                land.SetValue(Grid.ColumnProperty, (int)Math.Floor((decimal)i % 3));
                listLandCardSideBarGrid.Children.Add(land);
            }
        }

    }

    
}
