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
    /// Interaction logic for ComeOwnLandView.xaml
    /// </summary>
    public partial class ComeOwnLandView : UserControl
    {



        public string NameOfLand
        {
            get { return (string)GetValue(NameOfLandProperty); }
            set { SetValue(NameOfLandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOfLand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOfLandProperty =
            DependencyProperty.Register("NameOfLand", typeof(string), typeof(ComeOwnLandView), new PropertyMetadata(""));

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(ComeOwnLandView));



        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(int), typeof(ComeOwnLandView), new PropertyMetadata(0));




        public List<int> PriceLevel
        {
            get { return (List<int>)GetValue(PriceLevelProperty); }
            set { SetValue(PriceLevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceLevel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceLevelProperty =
            DependencyProperty.Register("PriceLevel", typeof(List<int>), typeof(ComeOwnLandView));




        public List<int> PriceTax
        {
            get { return (List<int>)GetValue(PriceTaxProperty); }
            set { SetValue(PriceTaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceTax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceTaxProperty =
            DependencyProperty.Register("PriceTax", typeof(List<int>), typeof(ComeOwnLandView));


        public int PriceSell
        {
            get { return (int)GetValue(PriceSellProperty); }
            set { SetValue(PriceSellProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceSell.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceSellProperty =
            DependencyProperty.Register("PriceSell", typeof(int), typeof(ComeOwnLandView), new PropertyMetadata(0));



        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Level.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(int), typeof(ComeOwnLandView), new PropertyMetadata(0));




        public static readonly RoutedEvent BuyButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBuyButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnBuyButtonClick
        {
            add { AddHandler(BuyButtonClickEvent, value); }
            remove { RemoveHandler(BuyButtonClickEvent, value); }
        }

        private void BuyButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(BuyButtonClickEvent));
        }



        public static readonly RoutedEvent UseCardButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnUseCardButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnUseCardButtonClick
        {
            add { AddHandler(UseCardButtonClickEvent, value); }
            remove { RemoveHandler(UseCardButtonClickEvent, value); }
        }

        private void UseCardButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(UseCardButtonClickEvent));
        }



        public static readonly RoutedEvent SkipButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnSkipButtonClick
        {
            add { AddHandler(SkipButtonClickEvent, value); }
            remove { RemoveHandler(SkipButtonClickEvent, value); }
        }

        private void SkipButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SkipButtonClickEvent));
        }


        public static readonly RoutedEvent SellButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnSellButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeOwnLandView));

        public event RoutedEventHandler OnSellButtonClick
        {
            add { AddHandler(SellButtonClickEvent, value); }
            remove { RemoveHandler(SellButtonClickEvent, value); }
        }

        private void SellButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SellButtonClickEvent));
        }

        public ComeOwnLandView()
        {
            InitializeComponent();
            NameOfLand = "Tên đất mặc định";
            ImgSource = new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative));
            Price = 12345;
            PriceSell = 1234;
            PriceLevel = new List<int>(5) { 1111, 2222, 3333, 4444, 5555 };
            PriceTax = new List<int>(5) { 111, 222, 333, 444, 555 };
            Level = 0;
        }

        public ComeOwnLandView(string nameOfLand, ImageSource imgSource, int price, int priceSell, List<int> priceLevel, List<int> priceTax, int level)
        {
            InitializeComponent();
            NameOfLand = nameOfLand;
            ImgSource = imgSource;
            Price = price;
            PriceSell = priceSell;
            PriceLevel = priceLevel;
            PriceTax = priceTax;
            Level = level;
        }

        public void SetInfor(string nameOfLand, ImageSource imgSource, int price, int priceSell, List<int> priceLevel, List<int> priceTax, int level)
        {
            NameOfLand = nameOfLand;
            ImgSource = imgSource;
            Price = price;
            PriceSell = priceSell;
            PriceLevel = priceLevel;
            PriceTax = priceTax;
            Level = level;
        }
    }
}
