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

        public List<Player> Players
        {
            get { return (List<Player>)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value);}
        }

        // Using a DependencyProperty as the backing store for Players.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayersProperty =
            DependencyProperty.Register("Players", typeof(List<Player>), typeof(TabSideBarGroup));


        public TabSideBarGroup()
        {
            InitializeComponent();
            createTab();
        }

        public TabSideBarGroup(List<Player> players, int turn)
        {
            InitializeComponent();
            Players = players;
            SelectedId = turn;
            createTab();
        }

        private void createTab()
        {
            for (int i = 0; i < Players?.Count; i++)
            {
                TabSideBar t = new TabSideBar(i, new BitmapImage(new Uri(@"/Monopoly;component/Images/avatar/circle-avatar" + (i + 1).ToString() + ".jpg", UriKind.Relative)), Players[i].name, Players[i].money);
                Grid.SetColumn(t, i);
                if (SelectedId == i)
                {
                    t.SetBg("selected");
                }
                gridTabSideBarGroup.Children.Add(t);
            }
        }
    }
}
