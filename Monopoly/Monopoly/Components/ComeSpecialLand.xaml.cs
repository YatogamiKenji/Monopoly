using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ComeSpecialLand.xaml
    /// </summary>
    public partial class ComeSpecialLand : BaseCenterMapView
    {

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Title.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title", typeof(string), typeof(ComeSpecialLand), new PropertyMetadata("Tên ô"));

        public static readonly RoutedEvent OKButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnOKButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ComeSpecialLand));

        public event RoutedEventHandler OnOKButtonClick
        {
            add { AddHandler(OKButtonClickEvent, value); }
            remove { RemoveHandler(OKButtonClickEvent, value); }
        }

        private void Button_OK(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            RaiseEvent(new RoutedEventArgs(OKButtonClickEvent));
        }

        public ComeSpecialLand(PowerCard powerCard)
        {
            this.DataContext = this;
            InitializeComponent();
            Title = "Ô QUYỀN NĂNG";

            Grid.SetRow(powerCard, 1);
            NoticeTakeCard.Children.Add(powerCard);

            mainDescription.Text = powerCard.Description;
        }

        public ComeSpecialLand(ChanceCard chanceCard)
        {
            this.DataContext = this;
            InitializeComponent();
            Title = "Ô CƠ HỘI";

            Grid.SetRow(chanceCard, 1);
            NoticeTakeCard.Children.Add(chanceCard);

            mainDescription.Text = chanceCard.Description;

        }

        public ComeSpecialLand(LuckCard luckCard)
        {
            this.DataContext = this;
            InitializeComponent();
            Title = "Ô KHÍ VẬN";

            Grid.SetRow(luckCard, 1);
            NoticeTakeCard.Children.Add(luckCard);

            mainDescription.Text = luckCard.Description;

        }
    }
}
