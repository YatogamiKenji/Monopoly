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
    /// Interaction logic for ChessBoard.xaml
    /// </summary>
    public partial class ChessBoard : UserControl
    {
        List<Canvas> players = new List<Canvas>();
        List<Canvas> cellPos;
        public int PlayerTurn = 0;
        Player[] playersClass = new Player[4];
        CellBase[] cellManager = new CellBase[6];
        List<Land> lands = new List<Land>();

        public ChessBoard()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            InitPlayer();
            InitPlayerClass();
            InitCellManager();
            InitData();
            cellPos = new List<Canvas>(40)
            { _0,_1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31,_32,_33,_34,_35,_36,_37,_38,_39 };
        }

        public void InitPlayerClass()
        {
            for (int i = 0; i < 4; i++)
            {
                playersClass[i] = new Player();
                playersClass[i].position = 0;
            }
        }

        public void InitCellManager()
        {
            for (int i = 0; i < 6; i++)
            {
                if (i == 0)
                {
                    cellManager[i] = new CellStart();
                }
                else if (i > 0 && i < 6)
                {
                    cellManager[i] = new CellLand();
                }
            }
            CellLand CurLand1 = new CellLand();
            CurLand1.name = "A";
            CurLand1.value = 1000;
            CurLand1.level = 0;
            cellManager[1] = CurLand1;
            CellLand CurLand2 = new CellLand();
            CurLand2.name = "B";
            CurLand2.value = 1200;
            CurLand2.level = 0;
            cellManager[2] = CurLand2;
            CellLand CurLand3 = new CellLand();
            CurLand3.name = "C";
            CurLand3.value = 1400;
            CurLand3.level = 0;
            cellManager[3] = CurLand3;
            CellLand CurLand4 = new CellLand();
            CurLand4.name = "D";
            CurLand4.value = 1600;
            CurLand4.level = 0;
            cellManager[4] = CurLand4;
            CellLand CurLand5 = new CellLand();
            CurLand5.name = "E";
            CurLand5.value = 1800;
            CurLand5.level = 0;
            cellManager[5] = CurLand5;
        }

        void InitData()
        {
            var content = System.IO.File.ReadAllText(@"D:\Bài Giảng UIT - HK3\Lập trình trực quan\Đồ án\New folder\Monopoly\Monopoly\Monopoly\Data\Land.json");
            lands = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Land>>(content);
        }

        public void InitPlayer()
        {
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            Grid.SetRow(players[0], 10);
            Grid.SetColumn(players[0], 0);
            Grid.SetRow(players[1], 10);
            Grid.SetColumn(players[1], 0);
            Grid.SetRow(players[2], 10);
            Grid.SetColumn(players[2], 0);
            Grid.SetRow(players[3], 10);
            Grid.SetColumn(players[3], 0);
        }

        private void But_xucxac_Click(object sender, RoutedEventArgs e)
        {
            Random random = new Random();
            int dice = random.Next(1, 7);
            playersClass[PlayerTurn].position = (playersClass[PlayerTurn].position + dice) % 40;
            Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[playersClass[PlayerTurn].position]));
            Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[playersClass[PlayerTurn].position]));
            //cellManager[playersClass[PlayerTurn].position].Chuc_nang();
            PlayerTurn = (PlayerTurn + 1) % 4;
        }
    }
}
