using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Threading;
using System.Windows.Controls.Primitives;

namespace Monopoly.Components
{
    enum CenterMapView { Dice, ComeEmptyLand, ComeOwnLand, ComeLuck, ComePower, ComeChance, UseCard, UseCardToAnother, PlayerUsing, Prev, Setting, CheatConsole, PayPrison }

    public delegate void BtnEndGameClickEventHandler(object sender, EndGameClickEventArgs agrs);

    public partial class ChessBoard : UserControl
    {
        #region Danh sách biến

        public int PlayerTurn = 0; //lượt của player nào

        public List<int> turn = new List<int>(); //số vòng hiện tại (để tăng thưởng khi qua ô bắt đầu)

        public List<PlayerShow> players; //danh sách chứa các player

        List<Border> cellPos; //chứa các ô trên bàn cờ ở trên thiết kế (XAML)

        List<Player> playersList = new List<Player>(); //lưu dữ liệu của các player

        Cell[] cellManager = new Cell[40]; //lưu dữ liệu của các ô trên bàn cờ

        List<Land> lands = new List<Land>(); //lưu dữ liệu đất
        
        List<Chance> chances = new List<Chance>(); //lưu dữ liệu các thẻ cơ hội

        List<CommunityChest> communityChests = new List<CommunityChest>(); //lưu dữ liệu các thẻ khí vận

        ListCardPlayers listCardPlayers = new ListCardPlayers(); //giao diện danh sách các thẻ của mỗi người chơi

        int NumberOfPlayers = 0; // Số lượng người chơi

        PlayerUsing playerUsing = new PlayerUsing(); //biến này lưu compoenent khi đi vào các ô đặc biệt

        Stack<CenterMapView> stackView = new Stack<CenterMapView>(); //chứa các view đã xuất hiện (để trở lại view trước)

        int dice; //chỉ số của xúc sắc

        int bankrupt = 0; //số người chơi đã phá sản

        bool gameMode; // chế độ chơi

        int numberTurns; //số lượt chơi trong chế độ setup

        int numberTurn; //số lượt đã trải qua để xử lý trong chế độ setup

        //các biến để di truyền dữ liệu giữa các hàm
        Power usingPower = new Power();
        Player usingPlayer = new Player();

        double countDown = 10; // Thời gian đếm ngược ở mỗi view
        DispatcherTimer countDownTimer; // Đồng hồ điều khiển thời gian đếm ngược


        #endregion

        #region Init UI

        public ChessBoard()
        {
            InitializeComponent();
            Init();
            Override.Visibility = Visibility.Hidden;
        }

        public ChessBoard(List<PlayerShow> PlayerShowFromSetup)
        {
            InitializeComponent();
            this.players = PlayerShowFromSetup;
            Init();
            Override.Visibility = Visibility.Hidden;
        }

        public ChessBoard(List<PlayerShow> PlayerShowFromSetup, bool gameMode, int numberTurns)
        {
            InitializeComponent();
            this.players = PlayerShowFromSetup;
            this.gameMode = gameMode;
            this.numberTurns = numberTurns;
            Init();
            Override.Visibility = Visibility.Hidden;
        }

        //khởi tạo giá trị
        public void Init()
        {
            InitData();
            InitPlayer();
            InitPlayerClass();
            InitPlayerUsing();
            InitListChance();
            InitListCommunityChest();

            cellPos = new List<Border>(40)
            { _0,_1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31,_32,_33,_34,_35,_36,_37,_38,_39 };

            for (int i = 0; i < players.Count; i++) turn.Add(0);

            countDownTimer = new DispatcherTimer();
            countDownTimer.Interval = TimeSpan.FromSeconds(0.2);
            countDownTimer.Tick += CountDownTimer_Tick;
            countDownTimer.Start();

            SwitchView(CenterMapView.Dice);
        }

        //khởi tạo player
        public void InitPlayerClass()
        {
            for (int i = 0; i < players.Count; i++)
            {
                Player player = new Player();
                if (Setup.instance.nameplayer[i] == "")
                {
                    player.name = "Player " + (i+1).ToString();
                }
                else
                {
                    player.name = Setup.instance.nameplayer[i];
                }
                player.position = 0;
                playersList.Add(player);
            }

            NumberOfPlayers = players.Count;
            sideBar.Players = playersList;
            sideBar.IconPlayers = players;
            sideBar.update(playersList, PlayerTurn);

            PowerStart();
        }

        //khởi tạo data
        void InitData()
        {
            //var content = System.IO.File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Data\Land.json");
            var content = System.IO.File.ReadAllText(System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\Data\Land.json");
            lands = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Land>>(content);
            for (int i = 0; i < lands.Count; i++)
            {
                lands[i].landValue = lands[i].value;
                lands[i].SetDefault();
            }

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
            //khởi tạo lại vị trí
            for (int i = 0; i < players.Count; i++)
            {
                Grid.SetRow(players[i], 10);
                Grid.SetColumn(players[i], 0);
                BanCo.Children.Add(players[i]);
            }
        }

        //Khi bắt đầu mỗi người sẽ có 3 thẻ quyền năng
        void PowerStart()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
                for (int j = 0; j < 3; j++) playersList[i].AddPower(RandomPower());
            sideBar.update(playersList, 0);
        }

        //khởi tạo component Player Using
        void InitPlayerUsing()
        {
            playerUsing.OnUseCardButtonClick += SwitchToUseCardView;
            playerUsing.OnSkipButtonClick += EndTurn;
        }

        //khởi tạo list cơ hội
        void InitListChance()
        {
            chances.Add(new ChanceBeingAttacked());
            chances.Add(new ChanceErrorMap());
            chances.Add(new ChanceFlyTooFast());
            chances.Add(new ChanceGoToAsgard());
            chances.Add(new ChanceGoToDevil());
            chances.Add(new ChanceGotoPrison());
            chances.Add(new ChanceGoToStart());
            chances.Add(new ChanceGoToValoran());
            chances.Add(new ChanceMeetMinerals());
            chances.Add(new ChanceMeetSpaceJunk());
            chances.Add(new ChanceOutPrison());
            chances.Add(new ChancePickUpTreasure());
            chances.Add(new ChanceRescueShipDistress());
        }

        //khởi tạo list khí vận
        void InitListCommunityChest()
        {
            communityChests.Add(new CommunityChestBankError());
            communityChests.Add(new CommunityChestBribe());
            communityChests.Add(new CommunityChestFuelCharger());
            communityChests.Add(new CommunityChestGoToPrison());
            communityChests.Add(new CommunityChestGoToStart());
            communityChests.Add(new CommunityChestHomeRepair());
            communityChests.Add(new CommunityChestMeetSpacePirate());
            communityChests.Add(new CommunityChestNoSpeedControl());
            communityChests.Add(new CommunityChestOvertime());
            communityChests.Add(new CommunityChestUpgrade());
            communityChests.Add(new CommunityChestWedding());
            communityChests.Add(new CommunityChestWinTheRace());
        }

        #endregion

        #region Sự kiện xử lý khi quay xúc sắc

        void ChangePlayerPosition()
        {
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
                    if (playersList[PlayerTurn].isDoubleStart) playersList[PlayerTurn].money += 4000 * (turn[PlayerTurn] / 2 + 1);
                    else playersList[PlayerTurn].money += 2000 * (turn[PlayerTurn] / 2 + 1);
                    if (turn[PlayerTurn] / 2 + 1 < 10) turn[PlayerTurn]++;
                    sideBar.update(playersList, PlayerTurn);
                }

                Wait(200);
            }
        }

        //sử lý khi trên người có tác dụng của thẻ PowerTeleport
        void UsingPowerTeleport()
        {
            for (int i = 1; i <= dice; i++) 
            {
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[playersList[PlayerTurn].position + i].Child;
                contentChessCell.OnButtonChessCellClick += TeleportClick;
                contentChessCell.StartShaking();
              //  contentChessCell.IsHitTestVisible = true;
            }   
        }

        //xử lý sau khi chọn ô muốn đi đến
        private void TeleportClick(object sender, RoutedEventArgs e)
        {
            ContentChessCell chessCell = sender as ContentChessCell;
            Border parentChessCell = (Border)chessCell.Parent;

            int index = -1;

            for (int i = 1; i <= dice; i++)
            {
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[playersList[PlayerTurn].position + i].Child;
                contentChessCell.OnButtonChessCellClick -= TeleportClick;
                contentChessCell.StopShaking();
               // contentChessCell.IsHitTestVisible = false;
                if (Grid.GetColumn(cellPos[playersList[PlayerTurn].position + i]) == Grid.GetColumn(parentChessCell) && Grid.GetRow(cellPos[playersList[PlayerTurn].position + i]) == Grid.GetRow(parentChessCell)) index = playersList[PlayerTurn].position + i;
            }

            //sử lý khi đi qua ô bắt đầu
            if (index >= 0 && index < 13 && playersList[PlayerTurn].position > 28)
            {
                if (playersList[PlayerTurn].isDoubleStart) playersList[PlayerTurn].money += 2000 * (turn[PlayerTurn] / 2 + 1);
                else playersList[PlayerTurn].money += 1000 * (turn[PlayerTurn] / 2 + 1);
                if (turn[PlayerTurn] / 2 + 1 < 10) turn[PlayerTurn]++;

                sideBar.update(playersList, PlayerTurn);
            }

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Hiệu ứng của thẻ Teleport đã kích hoạt", "Green"), 2.5, (str) =>
            {
                playersList[PlayerTurn].position = index;
                Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[index]));
                Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[index]));
                Goto();
            });
        }

        #region Trả thuế khi vào đất người khác

        //xử lý trả tiền khi đủ tiền trả khi vào đất người khác
        void EnoughMoneyToPay()
        {
            //nếu có không có miễn mất tiền
            if (!playersList[PlayerTurn].isLoseMoney)
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đi vào ô đất của " + playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].name
                    + " Bạn đã trả " + lands[cellManager[playersList[PlayerTurn].position].index].Tax(), "Red"), 3, (s) =>
                    {
                        playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                    });
            }
            else playersList[PlayerTurn].isLoseMoney = false;
            playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
            sideBar.update(playersList, PlayerTurn);
            SwitchView(CenterMapView.PlayerUsing);
        }

        //xử lý trả tiền khi không đủ tiền trả khi vào đất người khác
        void NotEnoughMoneyToPay()
        {
            //bán đến khi đủ tiền trả nợ
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền để trả!","Red"), 3, (s) =>{ });
            SellLand sellLand = new SellLand(playersList[PlayerTurn]);
            sellLand.OnCancleButtonClick += SellLand_OnButtonCancleClick;
            sellLand.OnSellLandButtonClick += SellLand_OnSellLandButtonClick;

            centerMapView.Content = sellLand;
        }

        //bán đất
        private void SellLand_OnSellLandButtonClick(object sender, SellLandButtonClickEventArgs e)
        {
            Land land = e.land;
            playersList[PlayerTurn].money += land.landValue / 2;
            playersList[PlayerTurn].RemoveLand(land.name);
            lands[cellManager[playersList[PlayerTurn].indexCells[e.index]].index].GetDefault();
            ContentChessCell contentChessCell = (ContentChessCell)cellPos[playersList[PlayerTurn].indexCells[e.index]].Child;
            contentChessCell.RemoveMarkLand();

            centerMapView.Content = null;
            //tự động trả nếu đủ tiền
            if (playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].Tax())
            {
                playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                NotEnoughMoneyToPay();
            }
            else NotEnoughMoneyToPay();

            sideBar.update(playersList, PlayerTurn);
        }

        //bán đến khi đủ tiền trả (nếu tổng giá trị tài sản có thể trả được)
        private void SellLand_OnButtonCancleClick(object sender, RoutedEventArgs e)
        {
            if (playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].Tax())
            {
                playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                SwitchView(CenterMapView.PlayerUsing);
            }
            else NotEnoughMoneyToPay();
        }

        //xử lý khi đi vào ô đất của người khác
        void PayLandRent()
        {
            //nếu đủ tiền thì tự động trả
            if (playersList[PlayerTurn].money >= lands[cellManager[playersList[PlayerTurn].position].index].Tax()
                || playersList[PlayerTurn].isLoseMoney) EnoughMoneyToPay();
            //nếu không đủ tiền xử lý sự kiện bán đất, bán nhà để trả nợ
            else
            {
                int sum = playersList[PlayerTurn].money;
                for (int i = 0; i < playersList[PlayerTurn].lands.Count; i++) sum += playersList[PlayerTurn].lands[i].landValue / 2;
                if (sum >= lands[cellManager[playersList[PlayerTurn].position].index].Tax()) NotEnoughMoneyToPay();
                else
                {
                    Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Người chơi *" + playersList[PlayerTurn].name + "* Đã phá sản", "Red"), 3, (s) =>
                    {
                        playersList[PlayerTurn].Loser();
                        BanCo.Children.Remove(players[PlayerTurn]);
                        bankrupt++;
                        if (NumberOfPlayers - bankrupt == 1)
                        {
                            for (int i = 0; i < NumberOfPlayers; i++) 
                                if (!playersList[i].isLoser)
                                {
                                    EndGame(playersList[i]);
                                    countDownTimer.Stop();
                                    return;
                                }    
                        }
                        ChangeTurn();
                    });
                }
            }
        }

        #endregion

        //đổi lượt
        void ChangeTurn()
        {
            if (!gameMode && PlayerTurn == NumberOfPlayers - 1) numberTurn++;
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention || playersList[PlayerTurn].isLoser)
            {
                if (!gameMode && PlayerTurn == NumberOfPlayers - 1) numberTurn++;
                Player _player = playersList[PlayerTurn];
                RemovePowersEffect(ref _player);
                playersList[PlayerTurn] = _player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }

            if (!gameMode && numberTurn == numberTurns) GameSummary();
            else
            {
                sideBar.update(playersList, PlayerTurn);
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Đến lượt " + playersList[PlayerTurn].name, "Blue"), 3, (s) =>
                {
                    countDownTimer.Start();
                });
                countDown = 5;
                SwitchView(CenterMapView.Dice);
                countDownTimer.Stop();
            }
        }

        //tổng kết chế độ setup sau khi đủ số lượt
        void GameSummary()
        {
            List<int> moneys = new List<int>();
            //tổng kết lại tiền đang có
            for (int i = 0; i < NumberOfPlayers; i++) 
            {
                moneys.Add(playersList[i].money);
                for (int j = 0; j < playersList[i].lands.Count; j++)
                {
                    moneys[i] += playersList[i].lands[j].value / 2;
                }
            }

            int max = moneys[0];
            int index = 0;
            for (int i = 1; i < NumberOfPlayers; i++)
                if (moneys[i] > max) 
                {
                    max = moneys[i];
                    index = i;
                }

            EndGame(playersList[index]);
            countDownTimer.Stop();
        }

        //đưa nhân vật vào tù
        void PlayerToPrison(bool check)
        {
            playersList[PlayerTurn].position = 10;
            Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[10]));
            Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[10]));
            if (check) SwitchView(CenterMapView.PlayerUsing);
            else ChangeTurn();
            sideBar.update(playersList, PlayerTurn);
        }

        //xử lý các hiệu ứng và thay đổi di chuyển
        void ActivationEffect()
        {
            if (playersList[PlayerTurn].isInPrison) playersList[PlayerTurn].isInPrison = false;

            // kích hoạt các hiệu ứng đang ở trên người
            Player player = playersList[PlayerTurn];
            RemovePowersEffect(ref player);
            playersList[PlayerTurn] = player;
            if (playersList[PlayerTurn].isDoubleDice) dice *= 2;
            if (playersList[PlayerTurn].isSplitDice) dice /= 2;

            //nếu không có tác dụng của thẻ PowerTeleport thì cho nhân vật di chuyển đến đích đến
            if (!playersList[PlayerTurn].isTeleport) ChangePlayerPosition();
            else UsingPowerTeleport();

            sideBar.update(playersList, PlayerTurn);
        }

        #region xử lý sự kiện đi đến các ô trên bàn cờ

        //đi đến ô đất
        void GoToLand()
        {
            //nếu đất trống thì hiện bản mua để người chơi lựa chọn
            if (getCurrentLand().owner == -1)
            {
                countDown = 30;
                SwitchView(CenterMapView.ComeEmptyLand);
            }
            //nếu là đất của mình và không bị người khác khóa thì sẽ hiện bảng nâng cấp
            else if (getCurrentLand().owner == PlayerTurn && !getCurrentLand().isLock)
            {
                countDown = 30;
                SwitchView(CenterMapView.ComeOwnLand);
            }

            //nếu là đất của người khác và không bị khóa thì tự động trả thuế và thông báo lên (nếu có)
            else if (getCurrentLand().owner != PlayerTurn && !getCurrentLand().isLock)
            {
                countDown = 15;
                PayLandRent();
            }

            //nếu mảnh đất bị khóa
            else
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Hiện tại hành tinh " + getCurrentLand().name + " đã bị khóa", "Red"), 3, (s) =>
                {
                    SwitchView(CenterMapView.PlayerUsing);
                });
            }
        }

        //xem thử thẻ cơ hội hay khí vận có thay đổi vị trí nhân vật trên bàn cờ hay không
        bool isChangePosition = false; 

        //đi đến ô cơ hội
        void GotoChance()
        {
            countDown = 20;

            // Tiến hành random thẻ cơ hội
            Random random = new Random();
            Chance chance = chances[random.Next(0, 13)];
            isChangePosition = chance.isChangePosition;
            ChanceCard chanceCard = new ChanceCard(chance);
            ComeSpecialLand comeSpecialLand = new ComeSpecialLand(chanceCard);
            centerMapView.Content = comeSpecialLand;
            comeSpecialLand.OnOKButtonClick += SpecialLandOKButtonClick;
            Player player = playersList[PlayerTurn];
            chance.Using(ref player);
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText(chance.description, "Blue"), 3, (s) => { });
        }

        //đi đến ô khí vận
        void GotoCommunityChest()
        {
            countDown = 20;

            // Tiến hành random thẻ khí vận
            Random random = new Random();
            CommunityChest communityChest = communityChests[random.Next(0, 12)];
            isChangePosition = communityChest.isChangePosition;
            LuckCard luckCard = new LuckCard(communityChest);
            ComeSpecialLand comeSpecialLand = new ComeSpecialLand(luckCard);
            centerMapView.Content = comeSpecialLand;
            comeSpecialLand.OnOKButtonClick += SpecialLandOKButtonClick;
            Player player = playersList[PlayerTurn];
            communityChest.Using(ref player);
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText(communityChest.description, "Blue"), 3, (s) => { });
            if (communityChest.GetType().Name == "CommunityChestWedding") CommunityChestWeddingEvent();
            else if (communityChest.GetType().Name == "CommunityChestBribe") CommunityChestBribeEvent();
        }

        //xử lý sự kiện khi random ra thẻ CommunityChestWedding
        void CommunityChestWeddingEvent()
        {
            playersList[PlayerTurn].money += 500 * (NumberOfPlayers - 1);
            for (int i = 0; i < NumberOfPlayers; i++)
                if (i != PlayerTurn) playersList[i].money -= 500;
        }

        //xử lý sự kiện khi random ra thẻ CommunityChestBribe
        void CommunityChestBribeEvent()
        {
            playersList[PlayerTurn].money -= 500 * (NumberOfPlayers - 1);
            for (int i = 0; i < NumberOfPlayers; i++)
                if (i != PlayerTurn) playersList[i].money += 500;
        }

        Power randomPower;

        //đi đến ô quyền năng
        void GotoPower()
        {
            countDown = 20;
            //Tiến hành random thẻ quyền năng
            randomPower = RandomPower();
            PowerCard powerCard = new PowerCard(randomPower);
            ComeSpecialLand comeSpecialLand = new ComeSpecialLand(powerCard);       
            centerMapView.Content = comeSpecialLand;
            comeSpecialLand.OnOKButtonClick += SpecialLandOKButtonClick;
        }

        //đi đến ô tù
        void GotoInPrison()
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô vào tù
        void GotoPrison()
        {
            playersList[PlayerTurn].isInPrison = true;

            //đưa player đến ô vào tù
            if (!playersList[PlayerTurn].isOutPrison && !playersList[PlayerTurn].isOutPrisonCard) 
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đi đến ô vào tù và bị đưa đến ô ở tù ", "Red"), 2.5, (str) =>
                {
                    PlayerToPrison(true);
                });
            else SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô bắt đầu
        void GotoStart()
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô thuế
        void GotoTax()
        {
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đi đến thuế và bị phạt 10% số tiền hiện có ", "Red"), 2.5, (str) =>
            {
                //phạt 10% số tiền hiện có khi đi vào ô thuế
                if (!playersList[PlayerTurn].isLoseMoney)
                    playersList[PlayerTurn].money = Convert.ToInt32(Math.Ceiling(0.9 * playersList[PlayerTurn].money));
                else playersList[PlayerTurn].isLoseMoney = false;
                sideBar.update(playersList, PlayerTurn);
                SwitchView(CenterMapView.PlayerUsing);
            });
        }

        //đi đến ô bãi đỗ xe
        void GotoParking()
        {
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText(" Trạm nghỉ ", "Green"), 2.5, (str) => { });
            SwitchView(CenterMapView.PlayerUsing);
        }

        #endregion

        //Các thao tác khi đi vào các ô trên bàn cờ
        void Goto()
        {
            countDown = 30; // Giá trị mặc định
            if (cellManager[playersList[PlayerTurn].position].type == CellType.Dat) GoToLand();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.CoHoi) SwitchView(CenterMapView.ComeChance);
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.KhiVan) SwitchView(CenterMapView.ComeLuck);
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.QuyenNang) SwitchView(CenterMapView.ComePower);
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.OTu) GotoInPrison();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.VaoTu) GotoPrison();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.Thue) GotoTax();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.BaiDoXe) GotoParking();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.BatDau) GotoStart();
        }

        //xử lý sự kiện khi xúc xắc quay
        private void HandleSpinnedDice(object sender, SpinnedDiceEventAgrs e)
        {
            dice = e.valueOfDice;

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn quay được *" + dice + "*", "Blue"), 1.5, (str) =>
            {
                // nếu người chơi đang ở trong tù thì phải đổ được 1 hoặc 6 mới được phép di chuyển ra ngoài
                if ((playersList[PlayerTurn].isInPrison && (dice == 1 || dice == 6)) || !playersList[PlayerTurn].isInPrison)
                {
                    ActivationEffect();
                    if (!playersList[PlayerTurn].isTeleport) Goto();
                    sideBar.update(playersList, PlayerTurn);
                }
                else SwitchView(CenterMapView.PayPrison);
            });
        }

        //trả tiền để được đi tiếp
        private void PayPrison_OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đã trả 1000 tiền bảo lãnh để ra khỏi tù", "Blue"), 1.5, (str) => { });
            playersList[PlayerTurn].money -= 1000;
            sideBar.update(playersList, PlayerTurn);
            ActivationEffect();
            if (!playersList[PlayerTurn].isTeleport) Goto();
        }

        #endregion

        #region Xử lý sự kiện trên ComeEmptyLandView và ComeOwnLandView

        //mua đất
        private void ComeEmptyLandView_OnBuyButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu người chơi mua thì gọi lệnh bên dưới
            if ((playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].value || playersList[PlayerTurn].isLoseMoney) && !playersList[PlayerTurn].isFreezeBank)
            {
                if (!playersList[PlayerTurn].isLoseMoney)
                    playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].value;
                else playersList[PlayerTurn].isLoseMoney = false;

                lands[cellManager[playersList[PlayerTurn].position].index].owner = PlayerTurn;
                playersList[PlayerTurn].AddLand(lands[cellManager[playersList[PlayerTurn].position].index], cellManager[playersList[PlayerTurn].position].index, playersList[PlayerTurn].position);
                sideBar.update(playersList, PlayerTurn);

                // đánh dấu ô đất đã mua bằng màu của người chơi
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[playersList[PlayerTurn].position].Child;
                contentChessCell.MarkLand(PlayerTurn);
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đã mua hành tinh *" + getCurrentLand().name + "*", "Green"), 2, (s) =>
                {
                    ChangeTurn();
                });
            }
            else if (playersList[PlayerTurn].isFreezeBank)
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Tài khoản của bạn đã bị đóng băng", "Red"), 1.5, (s) => { });
            else
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền", "Red"), 1.5, (s) => { });
        }

        //nâng cấp
        private void ComeOwnLandView_OnUpgradeButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu player đồng ý nâng cấp thì gọi lệnh bên dưới
            if ((playersList[PlayerTurn].money >= lands[cellManager[playersList[PlayerTurn].position].index].Upgrade(lands[cellManager[playersList[PlayerTurn].position].index].level + 1) 
                || playersList[PlayerTurn].isLoseMoney) && !playersList[PlayerTurn].isFreezeBank) 
            {
                if (!playersList[PlayerTurn].isLoseMoney)
                {
                    playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Upgrade();
                }
                else playersList[PlayerTurn].isLoseMoney = false;

                sideBar.update(playersList, PlayerTurn);

                // thêm sao vào ô đất
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[playersList[PlayerTurn].position].Child;
                contentChessCell.AddStar(lands[cellManager[playersList[PlayerTurn].position].index].level);

                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Đã nâng cấp *"+getCurrentLand().name+"* lên *cấp "+getCurrentLand().level, "Green"), 2.5, (s) =>
                {
                    ChangeTurn();
                });
            }
            else if (playersList[PlayerTurn].isFreezeBank)
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Tài khoản của bạn đã bị đóng băng", "Red"), 1.5, (s) => { });
            else
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền", "Red"), 1.5, (s) => { });

            sideBar.update(playersList, PlayerTurn);
        }

        //bán đất
        private void ComeOwnLandView_OnSellButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu người chơi bán thì gọi lệnh bên dưới
            //đóng băng tài khoản bán k đc cộng tiền
            if (!playersList[PlayerTurn].isFreezeBank) playersList[PlayerTurn].money += lands[cellManager[playersList[PlayerTurn].position].index].landValue / 2;
            playersList[PlayerTurn].RemoveLand(cellManager[playersList[PlayerTurn].position].index);
            lands[cellManager[playersList[PlayerTurn].position].index].GetDefault();

            ContentChessCell contentChessCell = (ContentChessCell)cellPos[playersList[PlayerTurn].position].Child;
            contentChessCell.MarkLand(-1);
            sideBar.update(playersList, PlayerTurn);

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đã bán hành tinh *" + getCurrentLand().name + "*", "Green"), 2, (s) =>
            {
                ChangeTurn();
            });
        }

        #endregion

        #region Các sự kiện khi đi vào các ô đặc biệt

        //nhấn ok khi nhận được thẻ
        private void SpecialLandOKButtonClick(object sender, RoutedEventArgs e)
        {
            if (playersList[PlayerTurn].powers.Count >= 5 && (playersList[PlayerTurn].position == 17 || playersList[PlayerTurn].position == 33))
            {
                RemovePowerView removePowerView = new RemovePowerView(playersList[PlayerTurn]);
                removePowerView.OnRemoveCardButtonClick += RemovePowerView_OnRemoveCardButtonClick;
                removePowerView.OnCancleButtonClick += RemovePowerView_OnCancleButtonClick;
                centerMapView.Content = removePowerView;
            }
            else
            {
                SwitchView(CenterMapView.PlayerUsing);

                //Cập nhật lại vị trí
                if (isChangePosition)
                {
                    Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[playersList[PlayerTurn].position]));
                    Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[playersList[PlayerTurn].position]));

                    if (playersList[PlayerTurn].position == 0)
                    {
                        if (playersList[PlayerTurn].isDoubleStart) playersList[PlayerTurn].money += 2000 * (turn[PlayerTurn] / 2 + 1);
                        else playersList[PlayerTurn].money += 1000 * (turn[PlayerTurn] / 2 + 1);
                        if (turn[PlayerTurn] / 2 + 1 < 10) turn[PlayerTurn]++;
                    }
                    Goto();
                    isChangePosition = false;
                }
            }
        }

        private void RemovePowerView_OnCancleButtonClick(object sender, RoutedEventArgs e)
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        private void RemovePowerView_OnRemoveCardButtonClick(object sender, RemoveCardButtonClickEventArgs e)
        {
            playersList[PlayerTurn].RemovePower(e.power.name);
            playersList[PlayerTurn].AddPower(randomPower);
            sideBar.update(playersList, PlayerTurn);
            SwitchView(CenterMapView.PlayerUsing);
        }

        #endregion

        #region Xử lý các sự kiện liên quan đến sử dụng thẻ Power

        bool checkUseCell;

        //xử lý những thẻ sử dụng lên bản thân
        void UsingCardOnYourself(Power power)
        {
            centerMapView.Content = null;
            usingPlayer = playersList[PlayerTurn];
            if (power.Using(ref usingPlayer, dice))
            {
                power.PowerFunction(ref usingPlayer);

                if (power.name == "Dịch chuyển")
                {
                    usingPlayer.isInPrison = false;
                    for (int i = 0; i < 40; i++)
                    {
                        ContentChessCell contentChessCell = (ContentChessCell)cellPos[i].Child;
                        contentChessCell.OnButtonChessCellClick += MoveToAnyCellClick;
                        contentChessCell.StartShaking();
                       // contentChessCell.IsHitTestVisible = true;
                    }
                }

                // nếu thẻ power đó có sử dụng đến đất
                else if (power.usingLand && usingPlayer.lands.Count > 0)
                {
                    usingPower = power;
                    checkUseCell = true;
                    for (int i = 0; i < usingPlayer.lands.Count; i++)
                    {
                        ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[i]].Child;
                        contentChessCell.OnButtonChessCellClick += UsingCardOnYourselfClick;
                        contentChessCell.StartShaking();
                       // contentChessCell.IsHitTestVisible = true;
                    }
                }
                else
                {
                    Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * power.value + " khi sử dụng thẻ " + power.name, "Green"), 2.5, (str) =>
                    {
                        playersList[PlayerTurn] = usingPlayer;
                        SwitchView(CenterMapView.Dice);
                        sideBar.update(playersList, PlayerTurn);
                        ChangeTurn();
                    });
                }
            }
            else if (playersList[PlayerTurn].money >= power.value * dice && power.usingLand && usingPlayer.lands.Count == 0)
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không có bất kỳ hành tinh nào để sử dụng", "Red"), 2.5, (str) =>
                {
                    SwitchView(CenterMapView.Prev);
                    SwitchView(CenterMapView.UseCard);
                });
            }

        }

        //xử lý sau khi chọn được nơi đến trên bàn cờ
        private void MoveToAnyCellClick(object sender, RoutedEventArgs e)
        {
            ContentChessCell chessCell = sender as ContentChessCell;
            Border parentChessCell = (Border)chessCell.Parent;

            int index = -1;

            for (int i = 0; i < 40; i++)
            {
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[i].Child;
                contentChessCell.OnButtonChessCellClick -= MoveToAnyCellClick;
                contentChessCell.StopShaking();
               // contentChessCell.IsHitTestVisible = false;
                if (Grid.GetColumn(cellPos[i]) == Grid.GetColumn(parentChessCell) && Grid.GetRow(cellPos[i]) == Grid.GetRow(parentChessCell)) index = i;
            }

            playersList[PlayerTurn].position = index;
            Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[index]));
            Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[index]));
            playersList[PlayerTurn] = usingPlayer;
            Goto();
        }

        //xử lý sự kiện sau khi chọn được mảnh đất áp dụng power
        private void UsingCardOnYourselfClick(object sender, RoutedEventArgs e)
        {
            if (checkUseCell)
            {
                ContentChessCell chessCell = sender as ContentChessCell;
                Border parentChessCell = (Border)chessCell.Parent;

                int index = -1;
                checkUseCell = false;
                for (int i = 0; i < usingPlayer.indexCells.Count; i++)
                {
                    ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[i]].Child;
                    contentChessCell.OnButtonChessCellClick -= UsingCardOnYourselfClick;
                    contentChessCell.StopShaking();
                   // contentChessCell.IsHitTestVisible = false;
                    if (Grid.GetColumn(cellPos[usingPlayer.indexCells[i]]) == Grid.GetColumn(parentChessCell) && Grid.GetRow(cellPos[usingPlayer.indexCells[i]]) == Grid.GetRow(parentChessCell)) index = i;
                }

                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * usingPower.value + " khi sử dụng thẻ " + usingPower.name + " lên hành tinh " + usingPlayer.lands[index].name, "Green"), 2.5, (str) =>
                {
                    usingPower.PowerFunction(ref usingPlayer, index);
                    if (usingPower.GetType().Name == "PowerHalveUpgradeFee") chessCell.AddStar(lands[usingPlayer.indexCells[index]].level);
                    
                    //playersList[PlayerTurn] = usingPlayer;
                    ChangeTurn();
                });
            }
        }

        // Sử dụng 1 thẻ
        private void UseCardView_OnUseACardButtonClick(object sender, UseACardButtonClickEventArgs e)
        {
            if (e.power.GetType().Name == "Power")
            {
                if (playersList[PlayerTurn].isInPrison) playersList[PlayerTurn].isInPrison = false;
                else playersList[PlayerTurn].money += 1000;
                playersList[PlayerTurn].isOutPrisonCard = false;
                SwitchView(CenterMapView.Prev);
                sideBar.update(playersList, PlayerTurn);
            }
            else
            {
                usingPower = e.power;
                if (e.isEnoughMoneyToUse)
                {
                    if (e.power.type) UsingCardOnYourself(e.power); //thẻ sử dụng lên bản thân   
                    else SwitchView(CenterMapView.UseCardToAnother); //thẻ sử dụng lên người khác
                }
                else
                    Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền", "Red"), 1, (str) => { });
            }
        }

        // Chọn một người để sử dụng
        private void UseCardToAnotherView_OnButtonPlayerClick(object sender, BtnAnotherPlayerClickEventArgs e)
        {
            centerMapView.Content = null;
            Player playerUse = playersList[PlayerTurn];
            Player affectedPlayers = playersList[e.idPlayer];
            usingPlayer = playersList[e.idPlayer];
            if (usingPower.Using(ref playerUse, ref affectedPlayers, dice) && !affectedPlayers.isImmune)
            {
                usingPower.PowerFunction(ref affectedPlayers);

                //những thẻ di chuyển người chơi nên cần update lại vị trí
                if (usingPower.GetType().Name == "PowerAppointPersonToPrison" || usingPower.GetType().Name == "PowerTeleportPersonToTheTax")
                {
                    if (playersList[e.idPlayer].position == 10) playersList[PlayerTurn].isInPrison = true;
                    Grid.SetRow(players[e.idPlayer], Grid.GetRow(cellPos[playersList[e.idPlayer].position]));
                    Grid.SetColumn(players[e.idPlayer], Grid.GetColumn(cellPos[playersList[e.idPlayer].position]));
                    Goto();
                }

                // nếu thẻ power đó có sử dụng đến đất
                if (usingPower.usingLand && affectedPlayers.lands.Count > 0)
                {
                    checkUseCell = true;
                    for (int j = 0; j < usingPlayer.lands.Count; j++)
                    {
                        ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[j]].Child;
                        contentChessCell.OnButtonChessCellClick += UseCardToAnotherClick;
                        contentChessCell.StartShaking();
                        //contentChessCell.IsHitTestVisible = true;
                    }
                }
                else
                {
                    Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * usingPower.value + " khi sử dụng thẻ " + usingPower.name + " lên người chơi " + usingPlayer.name, "Green"), 2.5, (str) =>
                    {
                        //playersList[PlayerTurn] = playerUse;
                        //playersList[i] = affectedPlayers;
                        SwitchView(CenterMapView.Dice);
                        sideBar.update(playersList, PlayerTurn);
                        ChangeTurn();
                    });
                }
            }
            else if (playersList[PlayerTurn].money >= usingPower.value * dice && usingPower.usingLand && affectedPlayers.lands.Count == 0)
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Người chơi " + affectedPlayers.name + " không có bất kỳ hành tinh nào", "Red"), 2.5, (str) =>
                {
                    SwitchView(CenterMapView.Prev);
                    SwitchView(CenterMapView.UseCardToAnother);
                });
            }
            else if (playersList[PlayerTurn].money >= usingPower.value * dice && usingPower.GetType().Name == "PowerCancelPowerCard" && affectedPlayers.powers.Count == 0)
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Người chơi " + affectedPlayers.name + " không có bất kỳ thẻ quyền năng nào", "Red"), 2.5, (str) =>
                {
                    SwitchView(CenterMapView.Prev);
                });
            }
            else if (playersList[PlayerTurn].money < usingPower.value * dice) 
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền để sử dụng thẻ", "Red"), 1.5, (str) =>
                {
                    SwitchView(CenterMapView.Prev);
                });
            }
            sideBar.update(playersList, e.idPlayer);
            sideBar.update(playersList, PlayerTurn);
        }

        //xử lý sau khi chọn được mảnh đất của người khác muốn áp dụng hiệu ứng
        private void UseCardToAnotherClick(object sender, RoutedEventArgs e)
        {
            if (checkUseCell)
            {
                ContentChessCell chessCell = sender as ContentChessCell;
                Border parentChessCell = (Border)chessCell.Parent;

                int index = -1;
                checkUseCell = false;
                for (int i = 0; i < usingPlayer.indexCells.Count; i++)
                {
                    ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[i]].Child;
                    contentChessCell.OnButtonChessCellClick -= UseCardToAnotherClick;
                    contentChessCell.StopShaking();
                    //contentChessCell.IsHitTestVisible = false;
                    if (Grid.GetColumn(cellPos[usingPlayer.indexCells[i]]) == Grid.GetColumn(parentChessCell) && Grid.GetRow(cellPos[usingPlayer.indexCells[i]]) == Grid.GetRow(parentChessCell)) index = i;
                }

                if (usingPower.GetType().Name == "PowerStealLand")
                {
                    lands[usingPlayer.indexLands[index]].owner = PlayerTurn;
                    playersList[PlayerTurn].AddLand(lands[usingPlayer.indexLands[index]], usingPlayer.indexLands[index], usingPlayer.indexCells[index]);
                    chessCell.MarkLand(PlayerTurn);
                    sideBar.update(playersList, PlayerTurn);
                } 
                else  if(usingPower.GetType().Name == "PowerLandLevelReduction") chessCell.subStar(2);

                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * usingPower.value + " khi sử dụng thẻ "
                  + usingPower.name + " lên hành tinh " + usingPlayer.lands[index].name + " của người chơi " + usingPlayer.name, "Green"), 2.5, (str) =>
                  {
                      usingPower.PowerFunction(ref usingPlayer, index);
                      ChangeTurn();
                  });
            }
        }

        #endregion

        #region Hàm khác

        void SwitchView(CenterMapView view)
        {
            try
            {
                if (centerMapView.Content != null)
                    ((BaseCenterMapView)centerMapView.Content).unmoutedAnim(); // Chạy animation ẩn view
            }
            catch (Exception ex) { };

            // Đợi 0.1s sau khi chạy xong animation ẩn view
            Noti.SetTimeout(() =>
            {
                // Chuyển lại view trước đó
                if (view == CenterMapView.Prev)
                {
                    if (stackView.Count != 0)
                        stackView.Pop(); // pop view hiện tại

                    if (stackView.Count == 0)
                    {
                        SwitchView(CenterMapView.Dice);
                        return;
                    }

                    if (stackView.Count != 0)
                        SwitchView(stackView.Pop()); // Chuyển sang view trước

                    return;
                }

                // Dice view: xoá toàn bộ stack và chuyển view
                if (view == CenterMapView.Dice)
                {
                    stackView.Clear();
                    CreateDiceView();
                    return;
                }

                stackView.Push(view);
                switch (view)
                {
                    case CenterMapView.ComeEmptyLand:
                        CreateComeEmptyLand();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.ComeOwnLand:
                        CreateComeOwnLand();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.ComePower:
                        GotoPower();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.ComeLuck:
                        GotoCommunityChest();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.ComeChance:
                        GotoChance();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.PlayerUsing:
                        centerMapView.Content = playerUsing;
                        countDownTimer.Start();
                        break;

                    case CenterMapView.UseCard:
                        CreateUseCard();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.UseCardToAnother:
                        CreateUseCardToAnother();
                        countDownTimer.Start();
                        break;

                    case CenterMapView.Setting:
                        CreateSetting();
                        break;

                    case CenterMapView.CheatConsole:
                        CreateCheatConsole();
                        break;

                    case CenterMapView.PayPrison:
                        CreatePayPrison();
                        countDownTimer.Start();
                        break;

                    default:
                        MessageBox.Show("Không xác định được view");
                        break;
                }    
                
            }, 0.1);
        }

        void CreateDiceView()
        {
            DiceView diceView = new DiceView();
            diceView.OnSpinnedDice += HandleSpinnedDice;
            diceView.OnButtonClick += (s, e) => { countDownTimer.Stop(); };
            centerMapView.Content = diceView;
        }    

        //tạo view PayPrison
        void CreatePayPrison()
        {
            PayPrison payPrison = new PayPrison();
            payPrison.OnOkButtonClick += PayPrison_OnOkButtonClick;
            payPrison.OnSkipButtonClick += EndTurn;
            centerMapView.Content = payPrison;
        }

        //tạo view CheatConsole
        void CreateCheatConsole()
        {
            CheatConsole cheatConsole = new CheatConsole();
            cheatConsole.OnExitButtonClick += CheatConsole_OnExitButtonClick;
            cheatConsole.OnExecuteButtonClick += CheatConsole_OnExecuteButtonClick;
            centerMapView.Content = cheatConsole;
        }

        //tạo view UseCardToAnother
        void CreateUseCardToAnother()
        {
            UseCardToAnotherView useCardToAnotherView = new UseCardToAnotherView(playersList, PlayerTurn);
            useCardToAnotherView.OnButtonPlayerClick += UseCardToAnotherView_OnButtonPlayerClick;
            useCardToAnotherView.OnCancleButtonClick += BackToPrevView;
            centerMapView.Content = useCardToAnotherView;
        }

        //tạo view UseCard
        void CreateUseCard()
        {
            UseCardView useCardView = new UseCardView(playersList[PlayerTurn], dice);
            useCardView.OnCancleButtonClick += BackToPrevView;
            useCardView.OnUseACardButtonClick += UseCardView_OnUseACardButtonClick;
            centerMapView.Content = useCardView;
        }

        //tạo view ComeOwnLand
        void CreateComeOwnLand()
        {
            ComeOwnLandView comeOwnLandView = new ComeOwnLandView(getCurrentLand(), 1);
            comeOwnLandView.OnSellButtonClick += ComeOwnLandView_OnSellButtonClick;
            comeOwnLandView.OnUpgradeButtonClick += ComeOwnLandView_OnUpgradeButtonClick;
            comeOwnLandView.OnSkipButtonClick += EndTurn;
            comeOwnLandView.OnUseCardButtonClick += SwitchToUseCardView;
            centerMapView.Content = comeOwnLandView;
        }

        //tạo view ComeEmptyLand
        void CreateComeEmptyLand()
        {
            ComeEmptyLandView comeEmptyLandView = new ComeEmptyLandView(getCurrentLand());
            comeEmptyLandView.OnBuyButtonClick += ComeEmptyLandView_OnBuyButtonClick;
            comeEmptyLandView.OnSkipButtonClick += EndTurn;
            comeEmptyLandView.OnUseCardButtonClick += SwitchToUseCardView;
            centerMapView.Content = comeEmptyLandView;
        }

        //tạo view Setting
        void CreateSetting()
        {
            Setting setting = new Setting();
            setting.OnCloseButtonClick += Setting_OnOkButtonClick;
            setting.OnHomeButtonClick += Setting_OnHomeButtonClick;
            centerMapView.Content = setting;
        }

        public static readonly RoutedEvent HomeButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnHomeButtonClick), RoutingStrategy.Bubble, typeof(RoutedEventHandler), typeof(ChessBoard));

        public event RoutedEventHandler OnHomeButtonClick
        {
            add { AddHandler(HomeButtonClickEvent, value); }
            remove { RemoveHandler(HomeButtonClickEvent, value); }
        }

        private void Setting_OnHomeButtonClick(object sender, RoutedEventArgs e)
        {
            countDownTimer.Stop();
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Trở về màn hình chính", "Green"), 1.5, (str) =>
            {
                RaiseEvent(new RoutedEventArgs(HomeButtonClickEvent));
            });
        }

        //Chuyển sang view sử dụng thẻ
        private void SwitchToUseCardView(object sender, RoutedEventArgs e)
        {
            if (!playersList[PlayerTurn].isFreezeBank)
            {
                if (playersList[PlayerTurn].powers?.Any() == true) // Có thẻ
                    SwitchView(CenterMapView.UseCard);
                else
                    Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không có thẻ quyền năng", "Red"), 1.5, (str) => { });
            }
            else Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Tài khoản của bạn đã bị đóng băng không thể sử dụng quyền năng", "Red"), 1.5, (s) => { });
        }

        Land getCurrentLand() { return lands[cellManager[playersList[PlayerTurn].position].index]; }

        // xóa bỏ hiệu ứng trên người player theo từng lượt
        public void RemovePowersEffect(ref Player player)
        {
            //tự động tính toán hiệu lực của các quyền năng
            if (player.powersEffect != null)
            {
                player.Init();
                for (int i = 0; i < player.powersEffect.Count; i++)
                {
                    player.powersEffect[i].PowerFunction(ref player);
                }
            }
        }

        //random thẻ quyền năng
        public Power RandomPower()
        {
            Random random = new Random();
            int x = random.Next() % 200;
            if (x >= 0 && x < 13) return new PowerRemoveLoseMoneyNext();
            if (x > 13 && x < 27) return new PowerTeleport();
            if (x > 27 && x < 33 || x > 61 && x < 66) return new PowerAppointPersonToPrison();
            if (x > 33 && x < 47) return new PowerSplitDice();
            if (x > 47 && x < 61) return new PowerLandPriceHalved();
            if (x > 66 && x < 72 || x > 100 && x < 105) return new PowerMoveToAnyCell();
            if (x == 13 || x == 61 || x == 100 || x == 131) return new PowerRemoveAdverseEffects();
            if (x > 72 && x < 86) return new PowerExemptFromPrison();
            if (x > 86 && x < 100) return new PowerDoubleTheValueStarting();
            if (x > 105 && x < 111 || x > 151 && x < 156) return new PowerCancelPowerCard();
            if (x == 27 || x == 66 || x == 105 || x == 145) return new PowerStealLand();
            if (x > 111 && x > 125) return new PowerFreezeBankAccounts();
            if (x > 125 && x < 131 || x > 187 && x < 192) return new PowerDoubleTax();
            if (x > 131 && x < 145) return new PowerDoubleDice();
            if (x > 145 && x < 151 || x > 191 && x < 196) return new PowerHoldAPerson();
            if (x == 33 || x == 72 || x == 111 || x == 151) return new PowerDoublePriceLandForever();
            if (x > 156 && x < 170) return new PowerLockAPlotOfLand();
            if (x > 169 && x < 175 || x > 195 && x < 200) return new PowerHalveUpgradeFee();
            if (x > 174 && x < 188) return new PowerTeleportPersonToTheTax();
            return new PowerLandLevelReduction();
        }
        
        // Trở về view trước đó
        private void BackToPrevView(object sender, RoutedEventArgs e) { SwitchView(CenterMapView.Prev); }

        // Kết thúc lượt
        private void EndTurn(object sender, RoutedEventArgs e)
        {
            if (playersList[PlayerTurn].position == 30 && playersList[PlayerTurn].isInPrison)
            {
                SwitchView(CenterMapView.Prev);
                PlayerToPrison(false);
            }
            else ChangeTurn();
        }

        private void CountDownTimer_Tick(object sender, EventArgs e)
        {
            countDown -= countDownTimer.Interval.TotalSeconds; // Giảm thời gian đếm ngược

            try
            {
                if (centerMapView.Content != null)
                    ((BaseCenterMapView)centerMapView.Content).setCountdown(countDown); // Cập nhật thời gian đếm ngược lên giao diện
            }
            catch (Exception ex) { };

            if (countDown < 0)
            {
                countDownTimer.Stop();

                // Hết thời gian đếm ngược, tuỳ vào view mà xử lý
                if (stackView.Count == 0) // DiceView: tự động quay xúc xắc
                    ((DiceView)centerMapView.Content).clickBtnSpin();
                else
                    ChangeTurn();
            }
        }

        //hàm dừng nhưng không đóng băng chương trình
        public static void Wait(int milliseconds)
        {
            DispatcherTimer timer1 = new DispatcherTimer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = TimeSpan.FromMilliseconds(milliseconds);
            timer1.IsEnabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.IsEnabled = false;
                timer1.Stop();
            };
            while (timer1.IsEnabled)
            {
                Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(delegate { }));
            }
        }

        bool isSetting = false;

        //nút setting
        private void Setting_Click(object sender, RoutedEventArgs e)
        {
            Sound.StartButton();
            if (isSetting == false)
            {
                isSetting = true;
                SwitchView(CenterMapView.Setting);
                countDownTimer.Stop();
            }

            else
            {
                isSetting = false;
                SwitchView(CenterMapView.Prev);
                countDownTimer.Start();
            }
        }

        //tắt setting
        private void Setting_OnOkButtonClick(object sender, RoutedEventArgs e)
        {
            isSetting = false;
            SwitchView(CenterMapView.Prev);
            countDownTimer.Start();
        }

        public static readonly RoutedEvent EndGameButtonClickEvent =
            EventManager.RegisterRoutedEvent(nameof(OnEndGameButtonClick), RoutingStrategy.Bubble, typeof(BtnEndGameClickEventHandler), typeof(ChessBoard));

        public event BtnEndGameClickEventHandler OnEndGameButtonClick
        {
            add { AddHandler(EndGameButtonClickEvent, value); }
            remove { RemoveHandler(EndGameButtonClickEvent, value); }
        }

        private void EndGame(Player player)
        {
            countDownTimer.IsEnabled = false;
            RaiseEvent(new EndGameClickEventArgs(EndGameButtonClickEvent) { player = player });
            Override.Visibility = Visibility.Visible;
        }

        #endregion

        #region Cheat

        bool IsCheatOn = false;
        private void KeyIsDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.OemTilde && IsCheatOn == false)
            {
                IsCheatOn = true;
                SwitchView(CenterMapView.CheatConsole);
                countDownTimer.Stop();
            }
        }
        private void CheatConsole_OnExecuteButtonClick(object sender, RoutedEventArgs e)
        {
            CommandExe(CheatConsole.command_line);           
        }

        public void CommandExe(string cmd)
        {
            /*Hướng dẫn thêm command vào cheat console: 
             * lệnh đánh vào khung dùng số và giữa các phần có khoảng trắng syntax: {ID} {player} {ammount}, 
             * ID dùng để phân biệt các loại lệnh, 
             * player là player sẽ bị ảnh hưởng bởi lệnh
             * ammount là sô lượng hoặc số chỉ phụ (ví dụ thêm 100 tiền thì 100 là số chỉ phụ)
             */
            string[] CMD;
            int ID = 0;
            int player = 0;
            int ammount= 0 ;
            if (cmd == null)
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn chưa nhập command nào", "Red"), 1.5, (str) => { });
            }
            else 
            {
                CMD = cmd.Split(' ');
                ID = Int32.Parse(CMD[0]);
                player = Int32.Parse(CMD[1])-1;               
                ammount = Int32.Parse(CMD[2]);
                switch (ID)
                {
                    case 1:
                        playersList[player].money += ammount;
                        Noti.Show(notiCenterMapArea, new NotiBoxOnlyText($"Người chơi {player+1} đã được nhận {ammount}", "Blue"), 1.5, (str) => { });                       
                        break;
                    default:
                        Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Lệnh không hợp lệ", "Red"), 1, (str) => { });
                        break;
                }
                sideBar.update(playersList, PlayerTurn);
            }       
        }

        private void CheatConsole_OnExitButtonClick(object sender, RoutedEventArgs e)
        {
            IsCheatOn = false;
            countDownTimer.Start();
            SwitchView(CenterMapView.Prev);
        }

        #endregion

        #region Popup

        private void _1_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_left.PlacementTarget = _1;
            popup_left.Placement = PlacementMode.Right;
            popup_left.IsOpen = true;
            textleft.PopupText.Text = lands[0].description;
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
            textleft.PopupText.Text = lands[1].description;
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
            textleft.PopupText.Text = "Thuế";
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
            textleft.PopupText.Text = lands[2].description;
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
            textleft.PopupText.Text = lands[3].description;
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
            textleft.PopupText.Text = lands[4].description;
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
            textleft.PopupText.Text = "Cơ Hội";
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
            textleft.PopupText.Text = lands[5].description;
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
            textleft.PopupText.Text = lands[6].description;
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
            texttop.PopupText.Text = lands[7].description;
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
            texttop.PopupText.Text = lands[8].description;
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
            texttop.PopupText.Text = "Khí Vận";
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
            texttop.PopupText.Text = lands[9].description;
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
            texttop.PopupText.Text = lands[10].description;
        }

        private void _31_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _31;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = lands[21].description;
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
            texttop.PopupText.Text = lands[11].description;
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
            texttop.PopupText.Text = "Quyền Năng";
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
            texttop.PopupText.Text = lands[12].description;
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
            texttop.PopupText.Text = lands[13].description;
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
            textbottom.PopupText.Text = lands[27].description;
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
            textbottom.PopupText.Text = lands[26].description;
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
            textbottom.PopupText.Text = "Thuế";
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
            textbottom.PopupText.Text = lands[25].description;
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
            textbottom.PopupText.Text = lands[24].description;
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
            textbottom.PopupText.Text = lands[23].description;
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
            textbottom.PopupText.Text = "Quyền Năng";
        }

        private void _32_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_bottom.PlacementTarget = _32;
            popup_bottom.Placement = PlacementMode.Right;
            popup_bottom.IsOpen = true;
            textbottom.PopupText.Text = lands[22].description;
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
            textright.PopupText.Text = lands[14].description;
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
            textright.PopupText.Text = lands[15].description;
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
            textright.PopupText.Text = "Cơ Hội";
        }

        private void _24_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _24;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = lands[16].description;
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
            textright.PopupText.Text = lands[17].description;
        }

        private void _26_MouseEnter(object sender, MouseEventArgs e)
        {
            popup_right.PlacementTarget = _26;
            popup_right.Placement = PlacementMode.Right;
            popup_right.IsOpen = true;
            textright.PopupText.Text = lands[18].description;
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
            textright.PopupText.Text = "Khí Vận";
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
            textright.PopupText.Text = lands[19].description;
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
            textright.PopupText.Text = lands[20].description;
        }

        #endregion
    }
}