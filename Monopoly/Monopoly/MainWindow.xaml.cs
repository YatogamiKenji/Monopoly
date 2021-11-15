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
using System.Threading;
using System.IO;
using Monopoly.Components;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace Monopoly
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }



        private List<Player> _players;

        public List<Player> players
        {
            get { return _players; }
            set { _players = value; OnPropertyChanged(); }
        }


        private int _turn = 0;
        public int turn
        {
            get { return _turn; }
            set { _turn = value; OnPropertyChanged(); }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            turn = 1;
            players = new List<Player>();
            for (int i = 0; i < 4; i++)
            {
                List<Land> lands = new List<Land>(2) { new Land("Dat " + i, 12563, 3), new Land("Dat 2", 12345, 2)};
                players.Add(new Player("Player" + i, 20000 + i, 0, true));
                players[i].lands = lands;
            }

            sideBar.update(players, turn);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            turn = (turn + 1) % 4;
            sideBar.update(players, turn);
        }
    }
}
