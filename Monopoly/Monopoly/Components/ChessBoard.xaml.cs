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
using System.Windows.Threading;
using System.Windows.Controls.Primitives;
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
        Cell[] cellManager = new Cell[40];
        List<Land> lands = new List<Land>();
        List<Chance> chances = new List<Chance>();
        List<Power> powers = new List<Power>();

        public ChessBoard()
        {
            InitializeComponent();
            Init();
        }

        public void Init()
        {
            InitPlayer();
            InitPlayerClass();
            //InitData();
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

        //void InitData()
        //{
        //    var content = System.IO.File.ReadAllText(@"D:\IT008.LTTQ\Monopoludesign\Design\Monopoly\Monopoly\Data");
        //    lands = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Land>>(content);
        //    int count = 0;
        //    for (int i = 0; i < 40; i++)
        //    {
        //        cellManager[i] = new Cell();
        //        if (i == 0) cellManager[0].type = CellType.BatDau;
        //        else if (i == 10) cellManager[10].type = CellType.OTu;
        //        else if (i == 20) cellManager[20].type = CellType.BaiDoXe;
        //        else if (i == 30) cellManager[30].type = CellType.VaoTu;
        //        else if (i == 3 || i == 37) cellManager[i].type = CellType.Thue;
        //        else if (i == 7 || i == 23) cellManager[i].type = CellType.CoHoi;
        //        else if (i == 13 || i == 27) cellManager[i].type = CellType.KhiVan;
        //        else if (i == 17 || i == 33) cellManager[i].type = CellType.QuyenNang;
        //        else
        //        {
        //            cellManager[i].type = CellType.Dat;
        //            cellManager[i].index = count++;
        //        }
        //    }
        //}

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

        //create value ramdom
        public Random random = new Random();
        public int dice = 0;

        //funciton timer, show random value 1-6
        public void timer_Tick(object sender, EventArgs e)
        {
            messboxDice diceshow = new messboxDice();
            Random random = new Random();
            dice = random.Next(1, 7);
            num.Title = dice.ToString();
        }
        //create timer
        public DispatcherTimer timer = new DispatcherTimer();
        public void But_xucxac_Click(object sender, RoutedEventArgs e)
        {
            //setup timer
            timer.Interval = TimeSpan.FromSeconds(0.01);
            timer.Tick += timer_Tick;
            timer.Start();
            //Quay hide, Stop show
            But_xucxac.Visibility = Visibility.Collapsed;
            But_xucxac1.Visibility = Visibility.Visible;
        }

        public void But_xucxac_Click1(object sender, RoutedEventArgs e)
        {
            //Quay show, Stop hide
            But_xucxac1.Visibility = Visibility.Collapsed;
            But_xucxac.Visibility = Visibility.Visible;
            timer.Stop();
            //change player position
            playersClass[PlayerTurn].position = (playersClass[PlayerTurn].position + dice) % 40;
            Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[playersClass[PlayerTurn].position]));
            Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[playersClass[PlayerTurn].position]));
            //if (cellManager[playersClass[PlayerTurn].position].type == CellType.Dat)
            //{
            //    //MessageBox.Show("mua!!!");
            //    MessageBox.Show(lands[cellManager[playersClass[PlayerTurn].position].index].name);
            //}    
            ////MessageBox.Show(cellManager[playersClass[PlayerTurn].position].type.ToString());
            PlayerTurn = (PlayerTurn + 1) % 4;


        }
        private void _1_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _1;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_1";
            
        }
        private void _1_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
            
        }

        private void _2_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _2;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_2";
        }

        private void _2_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _3_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _3;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_3";
        }

        private void _3_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _4_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _4;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_4";
        }

        private void _4_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _5_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _5;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_5";
        }

        private void _5_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _6_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _6;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_6";
        }

        private void _6_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _7_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _7;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_7";
        }

        private void _7_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _8_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _8;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_8";
        }

        private void _8_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _9_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _9;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = "_9";
        }

        private void _9_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_left.Visibility = Visibility.Collapsed;
            popup_left.IsOpen = false;
        }

        private void _11_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _11;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_11";
        }

        private void _11_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _12_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _12;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_12";
        }

        private void _12_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _13_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _13;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_13";
        }

        private void _13_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _14_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _14;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_14";
        }

        private void _14_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _15_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _15_MouseEnter(object sender, MouseEventArgs e)
        {
            
            popup_top.PlacementTarget = _15;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_15";
        }

        private void _31_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _31;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_31";
        }

        private void _31_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _16_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _16;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_16";
        }

        private void _16_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _17_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _17;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_17";
        }

        private void _17_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _18_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _18;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_18";
        }

        private void _18_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _19_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_top.PlacementTarget = _19;
            popup_top.Placement = PlacementMode.Right;
            popup_top.IsOpen = true;
            texttop.PopupText.Text = "_19";
        }

        private void _19_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_top.Visibility = Visibility.Collapsed;
            popup_top.IsOpen = false;
        }

        private void _39_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _39;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_39";
        }

        private void _39_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _38_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _38;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_38";
        }

        private void _38_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _37_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _37;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_37";
        }

        private void _37_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _36_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _36;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_36";
        }

        private void _36_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _35_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _35;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_35";
        }

        private void _35_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _34_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _34_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _34;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_34";
        }

        private void _33_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _33_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _33;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_33";
        }

        private void _32_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _32;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = "_32";
        }

        private void _32_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_bottom.Visibility = Visibility.Collapsed;
            popup_bottom.IsOpen = false;
        }

        private void _21_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _21_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _21;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_21";
        }

        private void _22_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _22_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _22;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_22";
        }

        private void _23_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _23_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _23;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_23";
        }

        private void _24_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _24;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_24";
        }

        private void _24_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _25_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _25_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _25;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_25";
        }

        private void _26_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _26;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_26";
        }

        private void _26_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _27_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _27;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_27";
        }

        private void _27_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _28_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _28;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_28";
        }

        private void _28_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _29_MouseLeave(object sender, MouseEventArgs e)
        {
            popup_right.Visibility = Visibility.Collapsed;
            popup_right.IsOpen = false;
        }

        private void _29_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _29;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = "_29";
        }
    }
}
