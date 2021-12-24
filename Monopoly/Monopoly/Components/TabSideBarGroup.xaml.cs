using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

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

        public List<PlayerShow> IconPlayers
        {
            get { return (List<PlayerShow>)GetValue(IconPlayersProperty); }
            set { SetValue(IconPlayersProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Players.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPlayersProperty =
            DependencyProperty.Register("IconPlayers", typeof(List<PlayerShow>), typeof(TabSideBarGroup));

        public TabSideBarGroup()
        {
            InitializeComponent();
            createTab();
        }

        public TabSideBarGroup(List<Player> players, int turn, List<PlayerShow> iconPlayers)
        {
            InitializeComponent();
            Players = players;
            SelectedId = turn;
            IconPlayers = iconPlayers;
            createTab();
        }
       

        private void createTab()
        {
            for (int i = 0; i < Players?.Count; i++)
            {
                TabSideBar t = new TabSideBar
                (
                    i,
                    new BitmapImage(new Uri(@"/Monopoly;component/Images/avatar/avatar" + (i + 1) + ".jpg" , UriKind.Relative)),
                    Players[i].name,
                    Players[i].money,
                    IconPlayers[i].BackgroundPlayer
                );
                Grid.SetColumn(t, i);
                if (SelectedId == i)
                {
                    t.SetBg("selected");
                }
                if (Players[i].isLoser)
                {
                    t.SetBg("disable");
                }
                gridTabSideBarGroup.Children.Add(t);
            }
        }
    }
}
