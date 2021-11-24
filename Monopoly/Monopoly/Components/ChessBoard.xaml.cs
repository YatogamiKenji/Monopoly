using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Monopoly.Components
{
    /// <summary>
    /// Interaction logic for ChessBoard.xaml
    /// </summary>
    public partial class ChessBoard : UserControl
    {
        //lượt của player nào
        public int PlayerTurn = 0;
        //số vòng hiện tại
        public List<int> turn;
        //danh sách chứa các player
        List<Canvas> players = new List<Canvas>();
        //chứa các ô trên bàn cờ ở trên thiết kế (XAML)
        List<Canvas> cellPos;
        //lưu dữ liệu của các player
        List<Player> playersList = new List<Player>();
        //lưu dữ liệu của các ô trên bàn cờ
        Cell[] cellManager = new Cell[40];
        //lưu dữ liệu đất
        List<Land> lands = new List<Land>();
        //lưu dữ liệu các thẻ cơ hội
        List<Chance> chances = new List<Chance>();
        //lưu dữ liệu các thẻ khí vận
        List<Power> powers = new List<Power>();

        public ChessBoard()
        {
            InitializeComponent();
            Init();
        }

        //khởi tạo giá trị
        public void Init()
        {
            InitPlayer();
            InitPlayerClass();
            InitData();
            cellPos = new List<Canvas>(40)
            { _0,_1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31,_32,_33,_34,_35,_36,_37,_38,_39 };
            
            turn = new List<int>(4) { 0, 0, 0, 0 };
        }

        //khởi tạo player
        public void InitPlayerClass()
        {
            for (int i = 0; i < 4; i++)
            {
                Player player = new Player();
                player.position = 0;
                playersList.Add(player);
            }
            sideBar.Players = playersList;
            sideBar.update(playersList, PlayerTurn);
        }

        //khởi tạo data
        void InitData()
        {
            var content = System.IO.File.ReadAllText(@"D:\Bài Giảng UIT - HK3\Lập trình trực quan\Đồ án\New folder\Monopoly\Monopoly\Monopoly\Data\Land.json");
            lands = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Land>>(content);
            for (int i = 0; i < lands.Count; i++) lands[i].landValue = lands[i].value;
            int count = 0;
            //khởi tạo dữ liệu quản lý các ô trên bàn cờ
            for (int i = 0; i < 40; i++)
            {
                cellManager[i] = new Cell();
                if (i == 0) cellManager[0].type = CellType.BatDau;
                else if (i == 10) cellManager[10].type = CellType.OTu;
                else if (i == 20) cellManager[20].type = CellType.BaiDoXe;
                else if (i == 30) cellManager[30].type = CellType.VaoTu;
                else if (i == 3 || i == 37) cellManager[i].type = CellType.Thue;
                else if (i == 7 || i == 23) cellManager[i].type = CellType.CoHoi;
                else if (i == 13 || i == 27) cellManager[i].type = CellType.KhiVan;
                else if (i == 17 || i == 33) cellManager[i].type = CellType.QuyenNang;
                else
                {
                    cellManager[i].type = CellType.Dat;
                    cellManager[i].index = count++;
                }
            }
        }

        //khởi tạo lại vị trí của các player trên bàn cờ
        public void InitPlayer()
        {
            players.Add(player1);
            players.Add(player2);
            players.Add(player3);
            players.Add(player4);
            //khởi tạo lại vị trí
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
        messboxDice diceshow = new messboxDice();

        //funciton timer, show random value 1-6
        public void timer_Tick(object sender, EventArgs e)
        {
            dice = random.Next(1, 7);
            diceshow.Title = dice.ToString();
            dices.Content = diceshow;

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

            //tính số vòng đã đi được
            DoEvents();
            Thread.Sleep(1000);

            //change player position
            for (int i = 0; i < dice; i++) 
            {
                playersList[PlayerTurn].position = (playersList[PlayerTurn].position + 1) % 40;
                Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[playersList[PlayerTurn].position]));
                Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[playersList[PlayerTurn].position]));
                //xử lý khi đi ngang ô bắt đầu
                if (cellManager[playersList[PlayerTurn].position].type == CellType.BatDau)
                {
                    //thưởng tiền khi đi qua ô bắt đầu
                    playersList[PlayerTurn].money += 1000 * (turn[PlayerTurn] / 2 + 1);
                    if (turn[PlayerTurn] / 2 + 1 < 10) turn[PlayerTurn]++;
                    sideBar.update(playersList, PlayerTurn);
                }
                DoEvents();
                Thread.Sleep(500);
            }

            But_xucxac.Visibility = Visibility.Collapsed;
            sideBar.update(playersList, PlayerTurn);

            //xử lý nếu đi vào ô đất
            if (cellManager[playersList[PlayerTurn].position].type == CellType.Dat)
            {
                //nếu đất trống thì hiện bản mua để người chơi lựa chọn
                if (lands[cellManager[playersList[PlayerTurn].position].index].owner == -1)
                {
                    ComeEmptyLandView comeEmptyLandView = new ComeEmptyLandView();
                    comeEmptyLandView.land = lands[cellManager[playersList[PlayerTurn].position].index];
                    comeEmptyLandView.SetInfor();
                    comeEmptyLandView.OnBuyButtonClick += ComeEmptyLandView_OnBuyButtonClick;
                    comeEmptyLandView.OnSkipButtonClick += ComeEmptyLandView_OnSkipButtonClick;
                    comeEmptyLandView.OnUseCardButtonClick += ComeLandView_OnUseCardButtonClick;
                    dices.Content = comeEmptyLandView;
                }

                //nếu là đất của mình thì sẽ hiện bảng nâng cấp
                else if (lands[cellManager[playersList[PlayerTurn].position].index].owner == PlayerTurn)
                {
                    ComeOwnLandView comeOwnLandView = new ComeOwnLandView();
                    comeOwnLandView.land = lands[cellManager[playersList[PlayerTurn].position].index];
                    comeOwnLandView.SetInfor();
                    comeOwnLandView.OnSellButtonClick += ComeOwnLandView_OnSellButtonClick;
                    comeOwnLandView.OnBuyButtonClick += ComeOwnLandView_OnBuyButtonClick;
                    comeOwnLandView.OnSkipButtonClick += ComeOwnLandView_OnSkipButtonClick;
                    comeOwnLandView.OnUseCardButtonClick += ComeLandView_OnUseCardButtonClick;
                    dices.Content = comeOwnLandView;
                }

                //nếu là đất của người khác thì tự động trả thuế và thông báo lên (nếu có)
                else if (lands[cellManager[playersList[PlayerTurn].position].index].owner != PlayerTurn)
                {
                    //nếu đủ tiền thì tự động trả
                    if (playersList[PlayerTurn].money >= lands[cellManager[playersList[PlayerTurn].position].index].Tax())
                    {
                        playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                        playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                        But_xucxac.Visibility = Visibility.Visible;
                        sideBar.update(playersList, PlayerTurn);
                    }
                    //nếu không đủ tiền xử lý sự kiện bán đất, bán nhà để trả nợ
                    else
                    {

                    }
                    DoEvents();
                    Thread.Sleep(1500);
                    PlayerTurn = (PlayerTurn + 1) % 4;
                    sideBar.update(playersList, PlayerTurn);
                }
            }

            //xử lý khi đi vào ô cơ hội
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.CoHoi)
            {
                // Tiến hành random thẻ cơ hội
                //ComeLuckLand comeLuckLand = new ComeLuckLand();
                //dices.Content = comeLuckLand;
                sideBar.update(playersList, PlayerTurn);
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }

            //xử lý khi đi vào ô khí vận
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.KhiVan)
            {
                // Tiến hành random thẻ khí vận
                //ComeChanceCard comeChanceCard = new ComeChanceCard();
                //dices.Content = comeChanceCard;
                sideBar.update(playersList, PlayerTurn);
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }

            //xử lý khi đi vào ô quyền năng
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.QuyenNang)
            {
                //Tiến hành random thẻ quyền năng
                //ComePowerCard comePowerCard = new ComePowerCard();
                //dices.Content = comePowerCard;
                sideBar.update(playersList, PlayerTurn);
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }

            //xử lý khi đi vào ô ở tù
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.OTu)
            {
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }

            //xử lý khi đi vào ô vào tù
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.VaoTu)
            {
                //đưa player đến ô vào tù
                playersList[PlayerTurn].position = 10;
                Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[10]));
                Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[10]));
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }

            //xử lý khi đi vào ô thuế
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.Thue)
            {
                //phạt 10% số tiền hiện có khi đi vào ô thuế
                playersList[PlayerTurn].money = Convert.ToInt32(Math.Ceiling(0.9 * playersList[PlayerTurn].money));
                sideBar.update(playersList, PlayerTurn);
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }

            //xử lý khi đi vào bãi đổ xe
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.BaiDoXe)
            {
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % 4;
                DoEvents();
                Thread.Sleep(1500);
                sideBar.update(playersList, PlayerTurn);
            }
            sideBar.update(playersList, PlayerTurn);
        }

        private void ComeLandView_OnUseCardButtonClick(object sender, RoutedEventArgs e)
        {
            //UseCardToAnother useCardToAnother = new UseCardToAnother();
            //dices.Content = useCardToAnother;
        }

        private void ComeOwnLandView_OnSkipButtonClick(object sender, RoutedEventArgs e)
        {
            //tính lượt của các player
            PlayerTurn = (PlayerTurn + 1) % 4;
            DoEvents();
            Thread.Sleep(1000);
            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = diceshow;
        }

        private void ComeOwnLandView_OnBuyButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu người chơi bán thì gọi lệnh bên dưới
            playersList[PlayerTurn].money += lands[cellManager[playersList[PlayerTurn].position].index].landValue / 2;
            playersList[PlayerTurn].RemoveLand(lands[cellManager[playersList[PlayerTurn].position].index].name);
            sideBar.update(playersList, PlayerTurn);

            //tính lượt của các player
            PlayerTurn = (PlayerTurn + 1) % 4;
            DoEvents();
            Thread.Sleep(1500);
            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = diceshow;
        }

        private void ComeOwnLandView_OnSellButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu player đồng ý nâng cấp thì gọi lệnh bên dưới
            if (playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].Upgrade())
            {
                playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Upgrade();
                sideBar.update(playersList, PlayerTurn);

                //tính lượt của các player
                PlayerTurn = (PlayerTurn + 1) % 4;
                But_xucxac.Visibility = Visibility.Visible;
                dices.Content = diceshow;
            }
            else MessageBox.Show("không đủ tiền");
            DoEvents();
            Thread.Sleep(1500);
            sideBar.update(playersList, PlayerTurn);
        }

        private void ComeEmptyLandView_OnSkipButtonClick(object sender, RoutedEventArgs e)
        {
            //tính lượt của các player
            PlayerTurn = (PlayerTurn + 1) % 4;
            DoEvents();
            Thread.Sleep(1000);
            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = diceshow;
        }

        private void ComeEmptyLandView_OnBuyButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu người chơi mua thì gọi lệnh bên dưới
            if (playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].value)
            {
                playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].value;
                lands[cellManager[playersList[PlayerTurn].position].index].owner = PlayerTurn;
                playersList[PlayerTurn].AddLand(lands[cellManager[playersList[PlayerTurn].position].index]);
                sideBar.update(playersList, PlayerTurn);
                DoEvents();
                Thread.Sleep(1500);

                //tính lượt của các player
                PlayerTurn = (PlayerTurn + 1) % 4;
                But_xucxac.Visibility = Visibility.Visible;
                dices.Content = diceshow;
            }
            else MessageBox.Show("không đủ tiền");
            sideBar.update(playersList, PlayerTurn);
        }

        public static void DoEvents()
        {
            Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
        }
    }
}
