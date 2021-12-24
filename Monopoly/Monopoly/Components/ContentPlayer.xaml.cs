using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ContentPlayer.xaml
    /// </summary>
    /// 

    public partial class ContentPlayer : UserControl
    {


        public string NameCardImpact = "" ; // tên thẻ tác động lên người chơi này  

        public Power power;

        public string NamePlayer
        {
            get { return (string)GetValue(NamePlayerProperty); }
            set { SetValue(NamePlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for NamePlayer.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty NamePlayerProperty =
            DependencyProperty.Register("NamePlayer", typeof(string), typeof(ContentPlayer), new PropertyMetadata(""));

        public static readonly RoutedEvent ButtonPlayerClickEvent =
       EventManager.RegisterRoutedEvent(nameof(OnButtonPlayerClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ContentPlayer));

        public event RoutedEventHandler OnButtonPlayerClick
        {
            add { AddHandler(ButtonPlayerClickEvent, value); }
            remove { RemoveHandler(ButtonPlayerClickEvent, value); }
        }

        public ImageSource ImagePlayer
        {
            get { return (ImageSource)GetValue(ImagePlayerProperty); }
            set { SetValue(ImagePlayerProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImagePlayerProperty =
            DependencyProperty.Register("ImagePlayer", typeof(ImageSource), typeof(ContentPlayer));

        public ContentPlayer()
        {
            InitializeComponent();
        }
        //public ContentPlayer(Player x)
        //{
        //    InitializeComponent();
        //    NamePlayer = x.name;
        //}

        private void ChoosePlayer(object sender, RoutedEventArgs e)
        {
            RaiseEvent(new RoutedEventArgs(ButtonPlayerClickEvent));
        }
    }
}
