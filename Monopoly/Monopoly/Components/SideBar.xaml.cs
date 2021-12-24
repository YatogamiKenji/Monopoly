using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for SideBar.xaml
    /// </summary>
    /// 

    public partial class SideBar : UserControl
    {
        public int SelectedId
        {
            get { return (int)GetValue(SelectedIdProperty);}
            set { SetValue(SelectedIdProperty, value);}
        }
        // Using a DependencyProperty as the backing store for SelectedId.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty SelectedIdProperty =
            DependencyProperty.Register("SelectedId", typeof(int), typeof(SideBar), new PropertyMetadata(0));

        public List<Player> Players
        {
            get { return (List<Player>)GetValue(PlayersProperty); }
            set { SetValue(PlayersProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Players.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty PlayersProperty =
            DependencyProperty.Register("Players", typeof(List<Player>), typeof(SideBar));

        public List<PlayerShow> IconPlayers
        {
            get { return (List<PlayerShow>)GetValue(IconPlayersProperty); }
            set { SetValue(IconPlayersProperty, value); }
        }
        // Using a DependencyProperty as the backing store for Players.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty IconPlayersProperty =
            DependencyProperty.Register("IconPlayers", typeof(List<PlayerShow>), typeof(SideBar));

        public SideBar(List<Player> players, int turn)
        {
            InitializeComponent();
            Players = players;
            SelectedId = turn;
            update(Players, SelectedId);
        }

        public SideBar()
        {
            InitializeComponent();
            update(Players, SelectedId);

        }

        public void update(List<Player> players, int turn)
        {
            Players = players;
            SelectedId = turn;
            TabSideBarGroup tabs = new TabSideBarGroup(Players, SelectedId, IconPlayers);
            tabGroup.Content = tabs;

            if (Players != null)
            {
                ContentSideBar contentSideBar = new ContentSideBar(Players[SelectedId]);
                content.Content = contentSideBar;
            }

        }
    }
}
