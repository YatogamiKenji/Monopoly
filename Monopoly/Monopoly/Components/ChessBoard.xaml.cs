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
using System.Windows.Controls.Primitives;
using System.Windows.Media.Animation;
using System.IO;

namespace Monopoly.Components
{
    enum CenterMapView { Dice, ComeEmptyLand, ComeOwnLand, ComeLuck, ComePower, ComeChance, UseCard, UseCardToAnother, PlayerUsing, Prev}

    public partial class ChessBoard : UserControl
    {
        #region Danh sách biến

        public int PlayerTurn = 0; //lượt của player nào

        public List<int> turn; //số vòng hiện tại

        //danh sách chứa các player
        public List<PlayerShow> players; // này chỉnh từ list canva thành PlayerShow, list này được lấy dữ liệu bên list PlayerShow của Setup

        List<Border> cellPos; //chứa các ô trên bàn cờ ở trên thiết kế (XAML)

        List<Player> playersList = new List<Player>(); //lưu dữ liệu của các player

        Cell[] cellManager = new Cell[40]; //lưu dữ liệu của các ô trên bàn cờ

        List<Land> lands = new List<Land>(); //lưu dữ liệu đất
        
        List<Chance> chances = new List<Chance>(); //lưu dữ liệu các thẻ cơ hội

        List<CommunityChest> communityChests = new List<CommunityChest>(); //lưu dữ liệu các thẻ khí vận

        ListCardPlayers listCardPlayers = new ListCardPlayers(); //giao diện danh sách các thẻ của mỗi người chơi

        int NumberOfPlayers = 0; // Số lượng người chơi

        PlayerUsing playerUsing = new PlayerUsing(); //biến này lưu compoenent khi đi vào các ô đặc biệt

        bool checkSellLand; //kiểm tra là lệnh bán do nợ hay bán để kiếm tiền sd

        Stack<CenterMapView> stackView = new Stack<CenterMapView>();

        //chỉ số của xúc sắc
        int dice;

        #endregion

        #region Init UI

        public ChessBoard()
        {
            InitializeComponent();
            Init();
        }

        public ChessBoard(List<PlayerShow> PlayerShowFromSetup)
        {
            InitializeComponent();
            this.players = PlayerShowFromSetup;
            Init();
        }

        //khởi tạo giá trị
        public void Init()
        {
            InitData();

            InitPlayer();

            InitPlayerClass();

            InitPlayerUsing();

            cellPos = new List<Border>(40)
            { _0,_1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31,_32,_33,_34,_35,_36,_37,_38,_39 };

            turn = new List<int>();
            for (int i = 0; i < players.Count; i++) turn.Add(0);

            SwitchView(CenterMapView.Dice);
        }

        //khởi tạo player
        public void InitPlayerClass()
        {

            for (int i = 0; i < players.Count; i++)
            {
                Player player = new Player();
                player.name = players[i].Title;
                player.position = 0;
                playersList.Add(player);
            }

            NumberOfPlayers = players.Count;


            sideBar.Players = playersList;

            sideBar.update(playersList, PlayerTurn);

            //PowerStart();

            playersList[0].AddPower(new PowerDoubleDice());
            playersList[0].AddPower(new PowerDoublePriceLandForever());
            playersList[0].AddPower(new PowerDoubleTax());
            playersList[0].AddPower(new PowerDoubleTheValueStarting());
            playersList[0].AddPower(new PowerExemptFromPrison());
            playersList[0].AddPower(new PowerHalveUpgradeFee());
            playersList[0].AddPower(new PowerMoveToAnyCell());
            playersList[0].AddPower(new PowerRemoveAdverseEffects());
            playersList[0].AddPower(new PowerRemoveLoseMoneyNext());
            playersList[0].AddPower(new PowerTeleport());
            playersList[0].AddPower(new PowerAppointPersonToPrison());
            playersList[0].AddPower(new PowerCancelPowerCard());
            playersList[0].AddPower(new PowerFreezeBankAccounts());
            playersList[0].AddPower(new PowerHoldAPerson());
            playersList[0].AddPower(new PowerLandLevelReduction());
            playersList[0].AddPower(new PowerLandPriceHalved());
            playersList[0].AddPower(new PowerLockAPlotOfLand());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerStealLand());
            playersList[0].AddPower(new PowerTeleportPersonToTheTax());
            playersList[0].AddLand(lands[0], 0, 1);
            playersList[0].AddLand(lands[1], 1, 2);
            playersList[0].AddLand(lands[2], 2, 4);
            playersList[0].AddLand(lands[3], 3, 5);
            playersList[0].AddLand(lands[4], 4, 6);
            playersList[0].AddLand(lands[5], 5, 8);
            playersList[1].AddPower(new PowerCancelPowerCard());
            playersList[1].AddPower(new PowerSplitDice());
            playersList[1].AddLand(lands[6], 6, 9);
            playersList[1].AddLand(lands[7], 7, 11);
            playersList[1].AddLand(lands[8], 8, 12);
        }

        //khởi tạo data
        void InitData()
        {
            var content = System.IO.File.ReadAllText(Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName + @"\Data\Land.json");
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

        void PowerStart()
        {
            for (int i = 0; i < NumberOfPlayers; i++)
            {
                for (int j = 0; j < 3; j++) playersList[i].AddPower(RandomPower());
                sideBar.update(playersList, i);
            }
        }

        #endregion

        #region Init PlayerUsing

        //khởi tạo compoenent Player Using
        void InitPlayerUsing()
        {
            playerUsing.OnUseCardButtonClick += SwitchToUseCardView;
            playerUsing.OnSellButtonClick += PlayerUsing_OnSellButtonClick;
            playerUsing.OnSkipButtonClick += EndTurn;
        }

        //bán đất
        private void PlayerUsing_OnSellButtonClick(object sender, RoutedEventArgs e)
        {
            ListLandPlayers listLandPlayers = new ListLandPlayers(playersList[PlayerTurn].lands);
            SellLand sellLand = new SellLand(listLandPlayers);

            for (int i = 0; i < listLandPlayers.contenButtonCards.Count; i++)
            {
                listLandPlayers.contenButtonCards[i].OnButtonCardClick += SellLand_OnButtonCardClick;
            }

            sellLand.OnButtonCancleClick += BackToPrevView;

            checkSellLand = true;
            centerMapView.Content = sellLand;
        }


        #endregion

        #region Sự kiện xử lý khi quay xúc sắc

        //Thay đổi vị trí nhân vật từng bước
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
                    if (playersList[PlayerTurn].isDoubleStart) playersList[PlayerTurn].money += 2000 * (turn[PlayerTurn] / 2 + 1);
                    else playersList[PlayerTurn].money += 1000 * (turn[PlayerTurn] / 2 + 1);
                    if (turn[PlayerTurn] / 2 + 1 < 10) turn[PlayerTurn]++;
                    sideBar.update(playersList, PlayerTurn);
                }
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
                contentChessCell.IsHitTestVisible = true;
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
                contentChessCell.IsHitTestVisible = false;
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

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn đã sử dụng hiệu ứng của thẻ Teleport để di\n chuyển đến ô ", "Green"), 2.5, (str) =>
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
                playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
            else playersList[PlayerTurn].isLoseMoney = false;
            playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
            sideBar.update(playersList, PlayerTurn);
        }

        //xử lý trả tiền khi không đủ tiền trả khi vào đất người khác
        void NotEnoughMoneyToPay()
        {
            //bán đến khi đủ tiền trả nợ
            ListLandPlayers listLandPlayers = new ListLandPlayers(playersList[PlayerTurn].lands);
            SellLand sellLand = new SellLand(listLandPlayers);

            for (int i = 0; i < listLandPlayers.contenButtonCards.Count; i++)
            {
                listLandPlayers.contenButtonCards[i].OnButtonCardClick += SellLand_OnButtonCardClick;
            }

            checkSellLand = false;
            centerMapView.Content = sellLand;
        }

        //xử lý khi đi vào ô đất của người khác
        void PayLandRent()
        {
            //nếu đủ tiền thì tự động trả
            if (playersList[PlayerTurn].money >= lands[cellManager[playersList[PlayerTurn].position].index].Tax()
                || playersList[PlayerTurn].isLoseMoney) EnoughMoneyToPay();
            //nếu không đủ tiền xử lý sự kiện bán đất, bán nhà để trả nợ
            else NotEnoughMoneyToPay();

            ChangeTurn();
        }

        #endregion

        //đổi lượt
        void ChangeTurn()
        {
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention)
            {
                Player _player = playersList[PlayerTurn];
                RemovePowersEffect(ref _player);
                playersList[PlayerTurn] = _player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }
            sideBar.update(playersList, PlayerTurn);
            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Đến lượt " + playersList[PlayerTurn].name, "Blue"), 3, (s) =>
            {
                // bắt đầu thời gian đếm ngược
            });
            SwitchView(CenterMapView.Dice);
        }

        //đưa nhân vật vào tù
        void PlayerToPrison()
        {
            playersList[PlayerTurn].position = 10;
            playersList[PlayerTurn].isInPrison = true;
            Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[10]));
            Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[10]));
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention)
            {
                Player _player = playersList[PlayerTurn];
                RemovePowersEffect(ref _player);
                playersList[PlayerTurn] = _player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }

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
            if (getCurrentLand().owner == -1) SwitchView(CenterMapView.ComeEmptyLand);

            //nếu là đất của mình thì sẽ hiện bảng nâng cấp
            else if (getCurrentLand().owner == PlayerTurn) SwitchView(CenterMapView.ComeOwnLand);

            //nếu là đất của người khác thì tự động trả thuế và thông báo lên (nếu có)
            else if (getCurrentLand().owner != PlayerTurn) PayLandRent();
        }

        //đi đến ô cơ hội
        void GotoChance()
        {
            // Tiến hành random thẻ cơ hội
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô khí vận
        void GotoCommunityChest()
        {
            // Tiến hành random thẻ khí vận
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô quyền năng
        void GotoPower()
        {
            //Tiến hành random thẻ quyền năng
            Power power = RandomPower();
            PowerCard powerCard = new PowerCard(power);
            ComeSpecialLand comeSpecialLand = new ComeSpecialLand(powerCard);       
            centerMapView.Content = comeSpecialLand;
            playersList[PlayerTurn].AddPower(power);
            comeSpecialLand.OnOKButtonClick += ComeSpecialLand_OnOKButtonClick;
        }

        //đi đến ô tù
        void GotoInPrison()
        {
            //đưa player đến ô vào tù
            if (!playersList[PlayerTurn].isOutPrison) PlayerToPrison();

            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô vào tù
        void GotoPrison()
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô bắt đầu
        void GotoStart()
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô thuế
        void GotoTax()
        {
            //phạt 10% số tiền hiện có khi đi vào ô thuế
            if (!playersList[PlayerTurn].isLoseMoney)
                playersList[PlayerTurn].money = Convert.ToInt32(Math.Ceiling(0.9 * playersList[PlayerTurn].money));
            else playersList[PlayerTurn].isLoseMoney = false;
            SwitchView(CenterMapView.PlayerUsing);
        }

        //đi đến ô bãi đỗ xe
        void GotoParking()
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        #endregion

        //Các thao tác khi đi vào các ô trên bàn cờ
        void Goto()
        {
            if (cellManager[playersList[PlayerTurn].position].type == CellType.Dat) GoToLand();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.CoHoi) GotoChance();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.KhiVan) GotoCommunityChest();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.QuyenNang) GotoPower();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.OTu) GotoPrison();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.VaoTu) GotoInPrison();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.Thue) GotoTax();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.BaiDoXe) GotoParking();
            else if (cellManager[playersList[PlayerTurn].position].type == CellType.BatDau) GotoStart();
        }

        //xử lý sự kiện khi xúc xắc quay
        private void HandleSpinnedDice(object sender, SpinnedDiceEventAgrs e)
        {
            dice = e.valueOfDice;

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn quay được " + dice, "Blue"), 1.5, (str) =>
            {
                // nếu người chơi đang ở trong tù thì phải đổ được 1 hoặc 6 mới được phép di chuyển ra ngoài
                if ((playersList[PlayerTurn].isInPrison && (dice == 1 || dice == 6)) || !playersList[PlayerTurn].isInPrison)
                {
                    ActivationEffect();
                    if (!playersList[PlayerTurn].isTeleport) Goto();
                    sideBar.update(playersList, PlayerTurn);
                }
                else if (playersList[PlayerTurn].isInPrison && MessageBox.Show("bạn có muốn trả tiền để đi không", "thông báo", MessageBoxButton.OKCancel, MessageBoxImage.Question) == MessageBoxResult.OK)
                {
                    playersList[PlayerTurn].money -= 1000;
                    ActivationEffect();
                    if (!playersList[PlayerTurn].isTeleport) Goto();
                    sideBar.update(playersList, PlayerTurn);
                }
                else ChangeTurn();
            });
        }

        #endregion

        #region Các sự kiện của ComeEmptyLandView

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

                Noti.Show(notiCenterMapArea, new NotiBuyLand(lands[cellManager[playersList[PlayerTurn].position].index].name), 2, (s) =>
                {
                    ChangeTurn();
                });
            }
            else
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền", "Red"), 1.5, (s) => { });
            }
        }

        #endregion

        #region Các sự kiện của ComeOwnLandView

        //bán đất
        private void ComeOwnLandView_OnUpgradeButtonClick(object sender, RoutedEventArgs e)
        {
            

            //nếu player đồng ý nâng cấp thì gọi lệnh bên dưới
            if ((playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].Upgrade() || playersList[PlayerTurn].isLoseMoney) && !playersList[PlayerTurn].isFreezeBank)
            {
                if (!playersList[PlayerTurn].isLoseMoney)
                {
                    playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Upgrade();
                    playersList[PlayerTurn].UpdateLand(cellManager[playersList[PlayerTurn].position].index);
                }
                else playersList[PlayerTurn].isLoseMoney = false;

                sideBar.update(playersList, PlayerTurn);

                Noti.Show(notiCenterMapArea, new NotiBuyLand(lands[cellManager[playersList[PlayerTurn].position].index].name), 2, (s) =>
                {
                    ChangeTurn();
                });
            }
            else
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền", "Red"), 1.5, (s) => { });
            }

            sideBar.update(playersList, PlayerTurn);
        }

        //nâng cấp
        private void ComeOwnLandView_OnSellButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu người chơi bán thì gọi lệnh bên dưới
            //đóng băng tài khoản bán k đc cộng tiền
            if (!playersList[PlayerTurn].isFreezeBank) playersList[PlayerTurn].money += lands[cellManager[playersList[PlayerTurn].position].index].landValue / 2;
            playersList[PlayerTurn].RemoveLand(cellManager[playersList[PlayerTurn].position].index);
            lands[cellManager[playersList[PlayerTurn].position].index].GetDefault();

            sideBar.update(playersList, PlayerTurn);

            ChangeTurn();
        }

        #endregion

        #region Các sự kiện khi đi vào các ô đặc biệt

        //nhấn ok khi nhận được thẻ
        private void ComeSpecialLand_OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            SwitchView(CenterMapView.PlayerUsing);
        }

        #endregion

        #region Các sự kiện liên quan đến sử dụng thẻ Power

        //Chuyển sang view sử dụng thẻ
        private void SwitchToUseCardView(object sender, RoutedEventArgs e)
        {
            if (playersList[PlayerTurn].powers?.Any() == true) // Có thẻ
                SwitchView(CenterMapView.UseCard);
            else
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không có thẻ quyền năng", "Red"), 1.5, (str) => { });
        }

        //các biến để di truyền dữ liệu giữa các hàm
        Power usingPower = new Power();
        Player usingPlayer = new Player();
        int indexPlayer;

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
                    for (int i = 0; i < 40; i++)
                    {
                        ContentChessCell contentChessCell = (ContentChessCell)cellPos[i].Child;
                        contentChessCell.OnButtonChessCellClick += MoveToAnyCellClick;
                        contentChessCell.StartShaking();
                        contentChessCell.IsHitTestVisible = true;
                    }
                }

                // nếu thẻ power đó có sử dụng đến đất
                else if (power.usingLand && usingPlayer.lands.Count > 0)
                {
                    usingPower = power;
                    for (int i = 0; i < usingPlayer.lands.Count; i++)
                    {
                        ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[i]].Child;
                        contentChessCell.OnButtonChessCellClick += UsingCardOnYourselfClick;
                        contentChessCell.StartShaking();
                        contentChessCell.IsHitTestVisible = true;
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
                contentChessCell.IsHitTestVisible = false;
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
            ContentChessCell chessCell = sender as ContentChessCell;
            Border parentChessCell = (Border)chessCell.Parent;

            int index = -1;

            for (int i = 0; i < usingPlayer.indexCells.Count; i++)
            {
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[i]].Child;
                contentChessCell.OnButtonChessCellClick -= UsingCardOnYourselfClick;
                contentChessCell.StopShaking();
                contentChessCell.IsHitTestVisible = false;
                if (Grid.GetColumn(cellPos[usingPlayer.indexCells[i]]) == Grid.GetColumn(parentChessCell) && Grid.GetRow(cellPos[usingPlayer.indexCells[i]]) == Grid.GetRow(parentChessCell)) index = i;
            }

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * usingPower.value + " khi sử dụng thẻ " + usingPower.name + " lên hành tinh " + usingPlayer.lands[index].name, "Green"), 2.5, (str) =>
            {
                usingPower.PowerFunction(ref usingPlayer, index);
                playersList[PlayerTurn] = usingPlayer;
                if (usingPower.GetType().Name == "PowerHalveUpgradeFee") lands[playersList[PlayerTurn].indexLands[index]].Upgrade();
                ChangeTurn();
            });
        }

        // Sử dụng 1 thẻ
        private void UseCardView_OnUseACardButtonClick(object sender, UseACardButtonClickEventArgs e)
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

        // Chọn một người để sử dụng
        private void UseCardToAnotherView_OnButtonPlayerClick(object sender, BtnAnotherPlayerClickEventArgs e)
        {
            Player PickedPlayer = playersList[e.idPlayer];
            Player playerUse = playersList[PlayerTurn];
            Player affectedPlayers = new Player();
            for (int i = 0; i < playersList.Count; i++) // trong danh sách các người chơi 
            {
                if (playersList[i].name == PickedPlayer.name) // xác định người chơi nào bị chọn

                {
                    affectedPlayers = playersList[i];
                    usingPlayer = playersList[i];
                    indexPlayer = i;
                    if (usingPower.Using(ref playerUse, ref affectedPlayers, dice) && !affectedPlayers.isImmune)
                    {
                        usingPower.PowerFunction(ref affectedPlayers);

                        //những thẻ di chuyển người chơi nên cần update lại vị trí
                        if (usingPower.name == "Vào tù" ||
                            usingPower.name == "Ép buộc")
                        {
                            if (playersList[i].position == 10) playersList[PlayerTurn].isInPrison = true;
                            Grid.SetRow(players[i], Grid.GetRow(cellPos[playersList[i].position]));
                            Grid.SetColumn(players[i], Grid.GetColumn(cellPos[playersList[i].position]));
                            Goto();
                        }

                        // nếu thẻ power đó có sử dụng đến đất

                        if (usingPower.usingLand && affectedPlayers.lands.Count > 0)
                        {
                            for (int j = 0; j < usingPlayer.lands.Count; j++)
                            {
                                ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[j]].Child;
                                contentChessCell.OnButtonChessCellClick += UseCardToAnotherClick;
                                contentChessCell.StartShaking();
                                contentChessCell.IsHitTestVisible = true;
                            }
                        }
                        else
                        {
                            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * usingPower.value + " khi sử dụng thẻ " + usingPower.name + " lên người chơi " + usingPlayer.name, "Green"), 2.5, (str) =>
                            {
                                playersList[PlayerTurn] = playerUse;
                                playersList[i] = affectedPlayers;
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
                        });
                    }
                    else if (playersList[PlayerTurn].money >= usingPower.value * dice && usingPower.GetType().Name == "PowerCancelPowerCard" && affectedPlayers.powers.Count == 0)
                    {
                        Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Người chơi " + affectedPlayers.name + " không có bất kỳ thẻ quyền năng nào", "Red"), 2.5, (str) =>
                        {
                            SwitchView(CenterMapView.Prev);
                        });
                    }
                    else
                    {
                        Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền để sử dụng thẻ", "Red"), 1.5, (str) =>
                        {
                            SwitchView(CenterMapView.Prev);
                        });
                    }
                    break;
                }
                else if (playersList[i].isImmune && playersList[i].name == PickedPlayer.name)
                {
                    usingPower.Using(ref playerUse, ref affectedPlayers, dice);
                    playersList[PlayerTurn] = playerUse;
                    ChangeTurn();
                    break;
                }   
            }
        }

        //xử lý sau khi chọn được mảnh đất của người khác muốn áp dụng hiệu ứng
        private void UseCardToAnotherClick(object sender, RoutedEventArgs e)
        {
            ContentChessCell chessCell = sender as ContentChessCell;
            Border parentChessCell = (Border)chessCell.Parent;

            int index = -1;

            for (int i = 0; i < usingPlayer.indexCells.Count; i++)
            {
                ContentChessCell contentChessCell = (ContentChessCell)cellPos[usingPlayer.indexCells[i]].Child;
                contentChessCell.OnButtonChessCellClick -= UseCardToAnotherClick;
                contentChessCell.StopShaking();
                contentChessCell.IsHitTestVisible = false;
                if (Grid.GetColumn(cellPos[usingPlayer.indexCells[i]]) == Grid.GetColumn(parentChessCell) && Grid.GetRow(cellPos[usingPlayer.indexCells[i]]) == Grid.GetRow(parentChessCell)) index = i;
            }

            if (usingPower.name == "Trộm hành tinh")
            {
                lands[usingPlayer.indexLands[index]].owner = PlayerTurn;
                playersList[PlayerTurn].AddLand(lands[usingPlayer.indexLands[index]], usingPlayer.indexLands[index], usingPlayer.indexCells[index]);
            }

            Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn bị trừ " + dice * usingPower.value + " khi sử dụng thẻ " 
                + usingPower.name + " lên hành tinh " + usingPlayer.lands[index].name + " của người chơi " + usingPlayer.name, "Green"), 2.5, (str) =>
            {
                usingPower.PowerFunction(ref usingPlayer, index);
                playersList[indexPlayer] = usingPlayer;
                ChangeTurn();
            });
        }

        #endregion

        #region Sự kiện khác

        void SwitchView(CenterMapView view)
        {
            // Chuyển lại view trước đó
            if (view == CenterMapView.Prev)
            {
                if (stackView.Count != 0)
                    stackView.Pop(); // pop view hiện tại
                if (stackView.Count != 0)
                    SwitchView(stackView.Pop()); // Chuyển sang view trước
                return;
            }
            // Dice view: xoá toàn bộ stack và chuyển view
            if (view == CenterMapView.Dice)
            {
                stackView.Clear();
                DiceView diceView = new DiceView();
                diceView.OnSpinnedDice += HandleSpinnedDice;
                centerMapView.Content = diceView;
                return;
            }

            stackView.Push(view);
            switch (view)
            {
                case CenterMapView.ComeEmptyLand:
                    ComeEmptyLandView comeEmptyLandView = new ComeEmptyLandView(getCurrentLand());
                    comeEmptyLandView.OnBuyButtonClick += ComeEmptyLandView_OnBuyButtonClick;
                    comeEmptyLandView.OnSkipButtonClick += EndTurn;
                    comeEmptyLandView.OnUseCardButtonClick += SwitchToUseCardView;
                    centerMapView.Content = comeEmptyLandView;
                    break;

                case CenterMapView.ComeOwnLand:
                    ComeOwnLandView comeOwnLandView = new ComeOwnLandView(getCurrentLand(), 1);
                    comeOwnLandView.OnSellButtonClick += ComeOwnLandView_OnSellButtonClick;
                    comeOwnLandView.OnUpgradeButtonClick += ComeOwnLandView_OnUpgradeButtonClick;
                    comeOwnLandView.OnSkipButtonClick += EndTurn;
                    comeOwnLandView.OnUseCardButtonClick += SwitchToUseCardView;
                    centerMapView.Content = comeOwnLandView;
                    break;

                case CenterMapView.ComePower:
                    GotoPower();
                    break;

                case CenterMapView.ComeLuck:
                    GotoCommunityChest();
                    break;

                case CenterMapView.ComeChance:
                    GotoChance();
                    break;

                case CenterMapView.PlayerUsing:
                    centerMapView.Content = playerUsing;
                    break;

                case CenterMapView.UseCard:
                    UseCardView useCardView = new UseCardView(playersList[PlayerTurn], dice);
                    useCardView.OnCancleButtonClick += BackToPrevView;
                    useCardView.OnUseACardButtonClick += UseCardView_OnUseACardButtonClick;
                    centerMapView.Content = useCardView;
                    break;

                case CenterMapView.UseCardToAnother:
                    UseCardToAnotherView useCardToAnotherView = new UseCardToAnotherView(playersList, PlayerTurn);
                    useCardToAnotherView.OnButtonPlayerClick += UseCardToAnotherView_OnButtonPlayerClick;
                    useCardToAnotherView.OnCancleButtonClick += BackToPrevView;
                    centerMapView.Content = useCardToAnotherView;
                    break;

                default:
                    MessageBox.Show("Không xác định được view");
                    break;
            }
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
            int x = random.Next(200);
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
        private void EndTurn(object sender, RoutedEventArgs e) { ChangeTurn(); }

        //Bán đất
        private void SellLand_OnButtonCardClick(object sender, RoutedEventArgs e)
        {
            ContenButtonCardLand Card = (ContenButtonCardLand)sender;
            playersList[PlayerTurn].money += Card.land.landValue / 2;
            for (int i = 0; i < playersList[PlayerTurn].lands.Count; i++)
                if (playersList[PlayerTurn].lands[i].name == Card.land.name)
                {
                    lands[playersList[PlayerTurn].indexLands[i]].GetDefault();
                    playersList[PlayerTurn].RemoveLand(i);
                    break;
                }

            centerMapView.Content = null;

            if (checkSellLand) PlayerUsing_OnSellButtonClick(sender, e);
            else
            {
                //tự động trả nếu đủ tiền
                if (playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].Tax())
                {
                    playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                    playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                    ChangeTurn();
                }
                else NotEnoughMoneyToPay();
            }

            sideBar.update(playersList, PlayerTurn);
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
    }
}

#endregion