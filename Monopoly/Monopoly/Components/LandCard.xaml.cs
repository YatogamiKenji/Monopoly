using System;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for LandCard.xaml
    /// </summary>
    public partial class LandCard : UserControl
    {
        public string TypeCard;

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(LandCard), new PropertyMetadata("Tên mặc định"));

        public int Level
        {
            get { return (int)GetValue(LevelProperty); }
            set { SetValue(LevelProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Level.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty LevelProperty =
            DependencyProperty.Register("Level", typeof(int), typeof(LandCard), new PropertyMetadata(0));

        public int Tax
        {
            get { return (int)GetValue(TaxProperty); }
            set { SetValue(TaxProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Tax.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TaxProperty =
            DependencyProperty.Register("Tax", typeof(int), typeof(LandCard), new PropertyMetadata(0));

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(LandCard), new PropertyMetadata(0));

        public String ImgSource
        {
            get { return (String)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }
        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(String), typeof(LandCard));

        public LandCard()
        {
            InitializeComponent();
        }

        public LandCard(Land land)
        {
            InitializeComponent();
            TypeCard = land.GetType().Name;
            Title = land.name;
            Level = land.level;
            Tax = land.Tax();
            Value = land.landValue;
            ImgSource = @"/Monopoly;component" + land.avatar;
        }

        public LandCard(string title, int level, int tax, int value, String imgSource)
        {
            InitializeComponent();
            Title = title;
            Level = level;
            Tax = tax;
            Value = value;
            ImgSource = imgSource;
        }
    }
}
