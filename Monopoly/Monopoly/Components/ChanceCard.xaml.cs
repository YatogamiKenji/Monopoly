using System;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ChanceCard.xaml
    /// </summary>
    public partial class ChanceCard : UserControl
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ChanceCard), new PropertyMetadata("Tên mặc định"));



        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Description.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty DescriptionProperty =
            DependencyProperty.Register("Description", typeof(string), typeof(ChanceCard), new PropertyMetadata("Mô tả mặc định"));


        public String ImgSource
        {
            get { return (String)GetValue(ImgSourceProperty); }
            set { SetValue(ImgSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ImgSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImgSourceProperty =
            DependencyProperty.Register("ImgSource", typeof(String), typeof(ChanceCard));


        public ChanceCard()
        {
            InitializeComponent();
        }

        public ChanceCard(Chance chance)
        {
            InitializeComponent();
            Title = chance.name;
            Description = chance.description;
            ImgSource = chance.icon;
        }
    }
}
