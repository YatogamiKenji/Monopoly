using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for LandCardDetail.xaml
    /// </summary>
    public partial class LandCardDetail : UserControl
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
            DependencyProperty.Register("NameOfLand", typeof(string), typeof(LandCardDetail), new PropertyMetadata(""));

        public ImageSource ImgSource
        {
            get { return (ImageSource)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(ImageSource), typeof(LandCardDetail), new PropertyMetadata());

        public int Price
        {
            get { return (int)GetValue(PriceProperty); }
            set { SetValue(PriceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Price.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceProperty =
            DependencyProperty.Register("Price", typeof(int), typeof(LandCardDetail), new PropertyMetadata(0));

        public List<int> PriceLevel
        {
            get { return (List<int>)GetValue(PriceLevelProperty); }
            set { SetValue(PriceLevelProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceLevel.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceLevelProperty =
            DependencyProperty.Register("PriceLevel", typeof(List<int>), typeof(LandCardDetail));

        public List<int> PriceTax
        {
            get { return (List<int>)GetValue(PriceTaxProperty); }
            set { SetValue(PriceTaxProperty, value); }
        }

        // Using a DependencyProperty as the backing store for PriceTax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PriceTaxProperty =
            DependencyProperty.Register("PriceTax", typeof(List<int>), typeof(LandCardDetail));

        public LandCardDetail()
        {
            this.DataContext = this;
            InitializeComponent();
            NameOfLand = "Tên đất mặc định";
            PriceLevel = new List<int>() {0, 0, 0, 0, 0 };
            PriceTax = new List<int>() { 0, 0, 0, 0, 0 };
        }

        public void setInfor(Land land)
        {
            _land = land;
            NameOfLand = _land.name;
            Price = _land.value;
            ImgSource = new BitmapImage(new Uri(@"/Monopoly;component" + land.avatar, UriKind.Relative)) ;
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
