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

        public static TabSideBarGroup instance;
        
        public TabSideBarGroup()
        {
            InitializeComponent();
            createTab();
            instance = this;
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
                switch(i)
                {
                    case 0:
                        TabSideBar t1 = new TabSideBar(i, new BitmapImage(new Uri(Setup.instance.imgplayer1.FileName)), Players[i].name, Players[i].money);
                        Grid.SetColumn(t1, i);
                        if (SelectedId == i)
                        {
                            t1.SetBg("selected");
                        }
                        gridTabSideBarGroup.Children.Add(t1);
                        break;
                    case 1:
                        TabSideBar t2 = new TabSideBar(i, new BitmapImage(new Uri(Setup.instance.imgplayer2.FileName)), Players[i].name, Players[i].money);
                        Grid.SetColumn(t2, i);
                        if (SelectedId == i)
                        {
                            t2.SetBg("selected");
                        }
                        gridTabSideBarGroup.Children.Add(t2);
                        break;
                    case 2:
                        TabSideBar t3 = new TabSideBar(i, new BitmapImage(new Uri(Setup.instance.imgplayer3.FileName)), Players[i].name, Players[i].money);
                        Grid.SetColumn(t3, i);
                        if (SelectedId == i)
                        {
                            t3.SetBg("selected");
                        }
                        gridTabSideBarGroup.Children.Add(t3);
                        break;
                    case 3:
                        TabSideBar t4 = new TabSideBar(i, new BitmapImage(new Uri(Setup.instance.imgplayer4.FileName)), Players[i].name, Players[i].money);
                        Grid.SetColumn(t4, i);
                        if (SelectedId == i)
                        {
                            t4.SetBg("selected");
                        }
                        gridTabSideBarGroup.Children.Add(t4);
                        break;

                }
               
                
                
            }
        }
    }
}
