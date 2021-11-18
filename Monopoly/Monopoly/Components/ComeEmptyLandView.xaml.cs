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
    /// Interaction logic for ComeEmptyLandView.xaml
    /// </summary>
    public partial class ComeEmptyLandView : UserControl
    {

        private Land _land;
        public Land land
        {
            get { return _land; }
            set { _land = value; }
        }

        public string NameOfLand
        {
            get { return (string)GetValue(NameOfLandProperty); }
            set { SetValue(NameOfLandProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NameOfLand.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NameOfLandProperty =
            DependencyProperty.Register("NameOfLand", typeof(string), typeof(ComeEmptyLandView), new PropertyMetadata(""));

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(ComeEmptyLandView));



        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(int), typeof(ComeEmptyLandView), new PropertyMetadata(0));




        public List<int> PriceLevel
        {
            get { return (List<int>)GetValue(PriceLevelProperty); }
            set { SetValue(PriceLevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceLevel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceLevelProperty =
            DependencyProperty.Register("PriceLevel", typeof(List<int>), typeof(ComeEmptyLandView));




        public List<int> PriceTax
        {
            get { return (List<int>)GetValue(PriceTaxProperty); }
            set { SetValue(PriceTaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceTax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceTaxProperty =
            DependencyProperty.Register("PriceTax", typeof(List<int>), typeof(ComeEmptyLandView));


        public static readonly RoutedEvent BuyButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnBuyButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

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
            EventManager.RegisterRoutedEvent(nameof(OnUseCardButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

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
            EventManager.RegisterRoutedEvent(nameof(OnSkipButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeEmptyLandView));

        public event RoutedEventHandler OnSkipButtonClick
        {
            add { AddHandler(SkipButtonClickEvent, value); }
            remove { RemoveHandler(SkipButtonClickEvent, value); }
        }

        private void SkipButtonClickFunc(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(SkipButtonClickEvent));
        }


        public ComeEmptyLandView()
        {
            InitializeComponent();
            NameOfLand = "Tên đất mặc định";
            ImgSource = new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative));
            PriceLevel = new List<int>();
            PriceTax = new List<int>();
        }

        public ComeEmptyLandView(string nameOfLand, ImageSource imgSource, int price, List<int> priceLevel, List<int> priceTax)
        {
            InitializeComponent();
            NameOfLand = nameOfLand;
            ImgSource = imgSource;
            Price = price;
            PriceLevel = priceLevel;
            PriceTax = priceTax;
        }

        public void SetInfor(string nameOfLand, ImageSource imgSource, int price, List<int> priceLevel, List<int> priceTax)
        {
            NameOfLand = nameOfLand;
            ImgSource = imgSource;
            Price = price;
            PriceLevel = priceLevel;
            PriceTax = priceTax;
        }

        public void SetInfor()
        {
            NameOfLand = _land.name;
            Price = _land.value;
            List<int> value = new List<int>();
            List<int> tax = new List<int>();
            for (int i = 1; i < 6; i++) 
            {
                value.Add(_land.Upgrade(i));
                tax.Add(_land.Tax(i));
            }
            PriceLevel = value;
            PriceTax = tax;
        }
    }
}
