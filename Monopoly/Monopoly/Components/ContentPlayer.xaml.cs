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
    /// Interaction logic for ContentPlayer.xaml
    /// </summary>
    /// 

    public partial class ContentPlayer : UserControl
    {


        public string NameCardImpact = "" ; // tên thẻ tác động lên người chơi này  

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
