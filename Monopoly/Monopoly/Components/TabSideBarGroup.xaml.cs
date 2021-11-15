using Monopoly;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for TabSideBarGroup.xaml
    /// </summary>
    public partial class TabSideBarGroup : UserControl
    {
        

        public int SelectedId
        {
            get { return (int)GetValue(SelectedIdProperty); }
            set { SetValue(SelectedIdProperty, value); }
        }

        // Using a DependencyProperty as the backing store for SelectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIdProperty =
            DependencyProperty.Register("SelectedId", typeof(int), typeof(TabSideBarGroup), new PropertyMetadata(0));

        private List<TabSideBar> listItem;





        public List<Player> Players
        {
            get { return (List<Player>)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value); setTab(); }
        }

        // Using a DependencyProperty as the backing store for Players.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayersProperty =
            DependencyProperty.Register("Players", typeof(List<Player>), typeof(TabSideBarGroup));





        // Event
        //public static readonly RoutedEvent TabClickEvent =
        //    EventManager.RegisterRoutedEvent(nameof(OnTabClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(TabSideBarGroup));

        //public event RoutedEventHandler OnTabClick
        //{
        //    add { AddHandler(TabClickEvent, value); }
        //    remove { RemoveHandler(TabClickEvent, value); }
        //}

        public TabSideBarGroup()
        {
            InitializeComponent();
            listItem = new List<TabSideBar>();
            for (int i = 0; i < Players.Count; i++)
            {
                TabSideBar t = new TabSideBar(i, new BitmapImage(new Uri(@"/Monopoly;component/Image/bgCardEx.png", UriKind.Relative)), Players[i].name, Players[i].money);
                Grid.SetColumn(t, i);
                t.Margin = new Thickness(2, 0, 2, 0);
                t.Background = Brushes.LightGray;
                if (SelectedId == i)
                {
                    t.Background = Brushes.White;
                }
                listItem.Add(t);
                gridTabSideBarGroup.Children.Add(t);
            }
        }

        void setTab()
        {
            for (int i = 0; i < Players.Count; i++)
            {
                
                listItem[i].Background = Brushes.LightGray;
                if (SelectedId == i)
                {
                    listItem[i].Background = Brushes.White;
                }
            }
        }

        //private void TestEvent(object sender, MouseEventArgs e)
        //{

        //    MessageBox.Show(SelectedId + "");
        //    SelectedId = 3;

        //}

        //private void TabClickFunc(object sender, RoutedEventArgs e)
        //{
        //    RaiseEvent(new RoutedEventArgs(TabClickEvent));
        //}
    }
}
