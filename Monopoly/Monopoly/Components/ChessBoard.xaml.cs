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
        public List<PlayerShow> players; // này chỉnh từ list canva thành PlayerShow, list này được lấy dữ liệu bên list PlayerShow của Setup
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
        List<CommunityChest> communityChests = new List<CommunityChest>();
        //giao diện danh sách các thẻ của mỗi người chơi
        ListCardPlayers listCardPlayers = new ListCardPlayers();
        //List<Power> powers = new List<Power>();
        // Số lượng người chơi
        int NumberOfPlayers = 0;

        //Biến lưu dices.Content trước đó đó là  ComeOwnLandView hay là ComePowerLandView để chuyển đổi trở lại khi hủy sử dụng thẻ
        Object ContentDicesBack;
        //Biến kiểm tra dices.Content trước đó đó là  ComeOwnLandView(false) hay là ComePowerLandView(true) để chuyển đổi trở lại khi hủy sử dụng thẻ
        int CheckContentBack = 0;


        PlayerUsing playerUsing = new PlayerUsing();

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
            // MessageBox.Show("cc");
            InitData();

            //InitPower();

            InitPlayer();

            InitPlayerClass();

            InitPlayerUsing();


            cellPos = new List<Canvas>(40)
            { _0,_1,_2,_3,_4,_5,_6,_7,_8,_9,_10,_11,_12,_13,_14,_15,_16,_17,_18,_19,_20,_21,_22,_23,_24,_25,_26,_27,_28,_29,_30,_31,_32,_33,_34,_35,_36,_37,_38,_39 };

            turn = new List<int>();
            for (int i = 0; i < players.Count; i++) turn.Add(0);
        }

        //khởi tạo player
        public void InitPlayerClass()
        {

            for (int i = 0; i < players.Count; i++)
            {
                Player player = new Player();
                player.name = (i + 1).ToString();
                player.position = 0;
                playersList.Add(player);
            }

            NumberOfPlayers = players.Count;


            sideBar.Players = playersList;

            sideBar.update(playersList, PlayerTurn);

            playersList[0].AddPower(new PowerAppointPersonToPrison());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddPower(new PowerSplitDice());
            playersList[0].AddLand(lands[0], 0);
            playersList[0].AddLand(lands[1], 0);
            playersList[0].AddLand(lands[2], 0);
            playersList[0].AddLand(lands[3], 0);
            playersList[0].AddLand(lands[4], 0);
            playersList[0].AddLand(lands[5], 0);
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

        void InitPlayerUsing()
        {
            playerUsing.OnUseCardButtonClick += PlayerUsing_OnUseCardButtonClick;
            playerUsing.OnSellButtonClick += PlayerUsing_OnSellButtonClick;
            playerUsing.OnSkipButtonClick += PlayerUsing_OnSkipButtonClick;
        }


        private void PlayerUsing_OnSkipButtonClick(object sender, RoutedEventArgs e)
        {
            dices.Content = null;
            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
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

        private void PlayerUsing_OnSellButtonClick(object sender, RoutedEventArgs e)
        {
            ListLandPlayers listLandPlayers = new ListLandPlayers(playersList[PlayerTurn].lands);
            SellLand sellLand = new SellLand(listLandPlayers);

            for (int i = 0; i < listLandPlayers.contenButtonCards.Count; i++)
            {
                listLandPlayers.contenButtonCards[i].OnButtonCardClick += SellLand_OnButtonCardClick;
            }
        }

        private void PlayerUsing_OnUseCardButtonClick(object sender, RoutedEventArgs e)
        {
            ListCardPlayers listCardPlayers = new ListCardPlayers(playersList[PlayerTurn].powers);
            usingCard UsingCard = new usingCard(listCardPlayers);

            for (int i = 0; i < listCardPlayers.contenButtonCards.Count; i++)
            {
                listCardPlayers.contenButtonCards[i].OnButtonCardClick += ChessBoard_OnButtonCardClick;
            }

            UsingCard.OnButtonCancleClick += UsingCard_OnButtonCancleClick;
            _usingCard = UsingCard;
            dices.Content = UsingCard;
        }

        //void InitPower()
        //{
        //    //buff
        //    powers.Add(new PowerChooseOneCard());
        //    powers.Add(new PowerDoubleDice());
        //    powers.Add(new PowerDoublePriceLandForever());
        //    powers.Add(new PowerDoubleTax());
        //    powers.Add(new PowerDoubleTheValueStarting());
        //    powers.Add(new PowerExemptFromPrison());
        //    powers.Add(new PowerHalveUpgradeFee());
        //    powers.Add(new PowerMoveToAnyCell());
        //    powers.Add(new PowerRemoveAdverseEffects());
        //    powers.Add(new PowerRemoveLoseMoneyNext());
        //    //nerf
        //    powers.Add(new PowerAppointPersonToPrison());
        //    powers.Add(new PowerCancelPowerCard());
        //    powers.Add(new PowerFreezeBankAccounts());
        //    powers.Add(new PowerHoldAPerson());
        //    powers.Add(new PowerLandLevelReduction());
        //    powers.Add(new PowerLandPriceHalved());
        //    powers.Add(new PowerLockAPlotOfLand());
        //    powers.Add(new PowerSplitDice());
        //    powers.Add(new PowerStealLand());
        //    powers.Add(new PowerTeleportPersonToTheTax());
        //}



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

        //create value ramdom
        public Random random = new Random();
        public int dice = 0;


        public void But_xucxac_Click(object sender, RoutedEventArgs e)
        {

            dice = random.Next(1, 7);

            notification.content.Text = dice.ToString();
            But_xucxac.Visibility = Visibility.Visible;
            //animation faceout 
            Storyboard slide = Resources["OpenMenu"] as Storyboard;
            slide.Begin(notification);




            //dice = 17;
            //tính số vòng đã đi được


            But_xucxac.Visibility = Visibility.Collapsed;

            // nếu người chơi đang ở trong tù thì phải đổ được 1 hoặc 6 mới được phép di chuyển ra ngoài
            if ((playersList[PlayerTurn].isInPrison && (dice == 1 || dice == 6)) || !playersList[PlayerTurn].isInPrison)
            {
                if (playersList[PlayerTurn].isInPrison) playersList[PlayerTurn].isInPrison = false;

                // kích hoạt các hiệu ứng đang ở trên người
                Player player = playersList[PlayerTurn];
                RemovePowersEffect(ref player);
                playersList[PlayerTurn] = player;
                if (playersList[PlayerTurn].isDoubleDice) dice *= 2;
                if (playersList[PlayerTurn].isSplitDice) dice /= 2;

                //nếu không có tác dụng của thẻ PowerTeleport thì cho nhân vật di chuyển đến đích đến
                if (!playersList[PlayerTurn].isTeleport)
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
                else
                {
                    int index = 0;
                    //mở sự kiện để chọn ô
                    //sau khi chọn xong vị trí được lưu vào index
                    //sử lý khi người chơi đ ngang ô bắt đầu
                    if (index >= 0 && index < 13 && playersList[PlayerTurn].position > 30)
                    {
                        if (playersList[PlayerTurn].isDoubleStart) playersList[PlayerTurn].money += 2000 * (turn[PlayerTurn] / 2 + 1);
                        else playersList[PlayerTurn].money += 1000 * (turn[PlayerTurn] / 2 + 1);
                        if (turn[PlayerTurn] / 2 + 1 < 10) turn[PlayerTurn]++;

                        sideBar.update(playersList, PlayerTurn);
                    }

                    playersList[PlayerTurn].position = index;
                    Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[index]));
                    Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[index]));
                }

                sideBar.update(playersList, PlayerTurn);

                //xử lý nếu đi vào ô đất
                if (cellManager[playersList[PlayerTurn].position].type == CellType.Dat)
                {
                    //nếu đất trống thì hiện bản mua để người chơi lựa chọn
                    if (lands[cellManager[playersList[PlayerTurn].position].index].owner == -1)
                    {
                        ComeEmptyLandView comeEmptyLandView = new ComeEmptyLandView(lands[cellManager[playersList[PlayerTurn].position].index]);
                        comeEmptyLandView.OnBuyButtonClick += ComeEmptyLandView_OnBuyButtonClick;
                        comeEmptyLandView.OnSkipButtonClick += ComeEmptyLandView_OnSkipButtonClick;
                        comeEmptyLandView.OnUseCardButtonClick += ComeLandView_OnUseCardButtonClick;
                        dices.Content = comeEmptyLandView;
                        ContentDicesBack = comeEmptyLandView;
                        CheckContentBack = 0;
                    }

                    //nếu là đất của mình thì sẽ hiện bảng nâng cấp
                    else if (lands[cellManager[playersList[PlayerTurn].position].index].owner == PlayerTurn)
                    {
                        ComeOwnLandView comeOwnLandView = new ComeOwnLandView(lands[cellManager[playersList[PlayerTurn].position].index]);
                        comeOwnLandView.SetInfor(1);
                        comeOwnLandView.OnSellButtonClick += ComeOwnLandView_OnSellButtonClick;
                        comeOwnLandView.OnBuyButtonClick += ComeOwnLandView_OnBuyButtonClick;
                        comeOwnLandView.OnSkipButtonClick += ComeOwnLandView_OnSkipButtonClick;
                        comeOwnLandView.OnUseCardButtonClick += ComeLandView_OnUseCardButtonClick;
                        dices.Content = comeOwnLandView;
                        ContentDicesBack = comeOwnLandView;
                        CheckContentBack = 1;
                    }

                    //nếu là đất của người khác thì tự động trả thuế và thông báo lên (nếu có)
                    else if (lands[cellManager[playersList[PlayerTurn].position].index].owner != PlayerTurn)
                    {
                        //nếu đủ tiền thì tự động trả
                        if (playersList[PlayerTurn].money >= lands[cellManager[playersList[PlayerTurn].position].index].Tax() || playersList[PlayerTurn].isLoseMoney)
                        {
                            //nếu có không có miễn mất tiền
                            if (!playersList[PlayerTurn].isLoseMoney)
                                playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                            else playersList[PlayerTurn].isLoseMoney = false;
                            playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                            But_xucxac.Visibility = Visibility.Visible;
                            sideBar.update(playersList, PlayerTurn);
                        }
                        //nếu không đủ tiền xử lý sự kiện bán đất, bán nhà để trả nợ
                        else
                        {
                            //bán đến khi đủ tiền trả nợ
                            while (playersList[PlayerTurn].money < lands[cellManager[playersList[PlayerTurn].position].index].Tax())
                            {
                                ListLandPlayers listLandPlayers = new ListLandPlayers(playersList[PlayerTurn].lands);
                                SellLand sellLand = new SellLand(listLandPlayers);

                                for (int i = 0; i < listLandPlayers.contenButtonCards.Count; i++)
                                {
                                    listLandPlayers.contenButtonCards[i].OnButtonCardClick += SellLand_OnButtonCardClick;
                                }

                                dices.Content = sellLand;
                            }

                            //tự động trả
                            playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                            playersList[lands[cellManager[playersList[PlayerTurn].position].index].owner].money += lands[cellManager[playersList[PlayerTurn].position].index].Tax();
                            But_xucxac.Visibility = Visibility.Visible;
                            sideBar.update(playersList, PlayerTurn);
                        }


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
                }

                //xử lý khi đi vào ô cơ hội
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.CoHoi)
                {
                    // Tiến hành random thẻ cơ hội
                    //ComeLuckLand comeLuckLand = new ComeLuckLand();
                    //dices.Content = comeLuckLand;
                    dices.Content = playerUsing;
                    sideBar.update(playersList, PlayerTurn);
                    CheckContentBack = 2;
                }

                //xử lý khi đi vào ô khí vận
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.KhiVan)
                {
                    // Tiến hành random thẻ khí vận
                    //ComeChanceCard comeChanceCard = new ComeChanceCard();
                    //dices.Content = comeChanceCard;
                    dices.Content = playerUsing;
                    sideBar.update(playersList, PlayerTurn);
                    But_xucxac.Visibility = Visibility.Visible;
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

                //xử lý khi đi vào ô quyền năng
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.QuyenNang)
                {
                    //Tiến hành random thẻ quyền năng
                    Power power = RandomPower();
                    PowerCard powerCard = new PowerCard(power);
                    ComeSpecialLand comeSpecialLand = new ComeSpecialLand();
                    comeSpecialLand.Title = "Ô QUYỀN NĂNG";
                    comeSpecialLand.PicCard.Content = powerCard;
                    dices.Content = comeSpecialLand;
                    playersList[PlayerTurn].AddPower(power);
                    comeSpecialLand.OnOKButtonClick += ComeSpecialLand_OnOKButtonClick;
                }

                //xử lý khi đi vào ô ở tù
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.OTu)
                {
                    dices.Content = playerUsing;
                }

                //xử lý khi đi vào ô vào tù
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.VaoTu)
                {
                    //đưa player đến ô vào tù
                    if (!playersList[PlayerTurn].isOutPrison)
                    {
                        playersList[PlayerTurn].position = 10;
                        playersList[PlayerTurn].isInPrison = true;
                        Grid.SetRow(players[PlayerTurn], Grid.GetRow(cellPos[10]));
                        Grid.SetColumn(players[PlayerTurn], Grid.GetColumn(cellPos[10]));
                        But_xucxac.Visibility = Visibility.Visible;
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
                }

                //xử lý khi đi vào ô thuế
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.Thue)
                {
                    //phạt 10% số tiền hiện có khi đi vào ô thuế
                    if (!playersList[PlayerTurn].isLoseMoney)
                        playersList[PlayerTurn].money = Convert.ToInt32(Math.Ceiling(0.9 * playersList[PlayerTurn].money));
                    else playersList[PlayerTurn].isLoseMoney = false;
                    dices.Content = playerUsing;
                }

                //xử lý khi đi vào bãi đổ xe
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.BaiDoXe)
                {
                    dices.Content = playerUsing;
                }

                // xử lý khi đi vào ô bắt đầu
                else if (cellManager[playersList[PlayerTurn].position].type == CellType.BatDau)
                {
                    dices.Content = playerUsing;
                }

                sideBar.update(playersList, PlayerTurn);
            }
            else
            {
                But_xucxac.Visibility = Visibility.Visible;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                sideBar.update(playersList, PlayerTurn);
                if (playersList[PlayerTurn].isRetention)
                {
                    Player _player = playersList[PlayerTurn];
                    RemovePowersEffect(ref _player);
                    playersList[PlayerTurn] = _player;
                    PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                }
            } 
                
        }

        //bỏ qua
        private void ComeSpecialLand_OnOKButtonClick(object sender, RoutedEventArgs e)
        {
            dices.Content = playerUsing;
            ComeEmptyLandView_OnSkipButtonClick(sender, e);
        }

        usingCard _usingCard;

        //sử dụng thẻ
        private void ComeLandView_OnUseCardButtonClick(object sender, RoutedEventArgs e)
        {
            ListCardPlayers listCardPlayers = new ListCardPlayers(playersList[PlayerTurn].powers);
            // Grid.SetRow(listCardPlayers, 1);
            usingCard UsingCard = new usingCard(listCardPlayers);
            //usingCard usingCard = new usingCard();

            for (int i = 0; i < listCardPlayers.contenButtonCards.Count; i++)
            {
                listCardPlayers.contenButtonCards[i].OnButtonCardClick += ChessBoard_OnButtonCardClick;
            }
            UsingCard.OnButtonCancleClick += UsingCard_OnButtonCancleClick;
            _usingCard = UsingCard;
            dices.Content = UsingCard;
        }

        private void SellLand_OnButtonCardClick(object sender, RoutedEventArgs e)
        {
            ContenButtonCard Card = (ContenButtonCard)sender;
            playersList[PlayerTurn].money += Card.land.landValue / 2;
            for (int i = 0; i < playersList[PlayerTurn].lands.Count; i++)
                if (playersList[PlayerTurn].lands[i].name == Card.land.name)
                {
                    lands[playersList[PlayerTurn].indexLands[i]].GetDefault();
                    playersList[PlayerTurn].RemoveLand(playersList[PlayerTurn].indexLands[i]);
                    break;
                }

            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = null;
            sideBar.update(playersList, PlayerTurn);
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention)
            {
                Player _player = playersList[PlayerTurn];
                RemovePowersEffect(ref _player);
                playersList[PlayerTurn] = _player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }
        }

        // nếu đổi ý không sử dụng thẻ nữa
        private void UsingCard_OnButtonCancleClick(object sender, RoutedEventArgs e)
        {
            //dices.Visibility = Visibility.Collapsed;

            if (CheckContentBack == 0) dices.Content = (ComeEmptyLandView)ContentDicesBack;
            else if (CheckContentBack == 1) dices.Content = (ComeOwnLandView)ContentDicesBack;
            else if (CheckContentBack == 2) dices.Content = playerUsing;
        }

        // xử lý các sự kiện nếu sử dụng các thẻ trong dách sách thẻ 
        private void ChessBoard_OnButtonCardClick(object sender, RoutedEventArgs e)
        {
            ContenButtonCard Card = (ContenButtonCard)sender;

            //  MessageBox.Show(Card.IDCard);
            // nếu thẻ được sử dụng là thẻ chọn một người chơi vào tù
            /*if(Card.IDCard == "PowerAppointPersonToPrison" ||
                Card.IDCard == "PowerCancelPowerCard" || 
                Card.IDCard == "PowerFreezeBankAccounts" || 
                Card.IDCard == "PowerHoldAPerson" || 
                Card.IDCard == "PowerLandLevelReduction" || 
                Card.IDCard == "PowerLandPriceHalved" || 
                Card.IDCard == "PowerLockAPlotOfLand" || 
                Card.IDCard == "PowerSplitDice" || 
                Card.IDCard == "PowerStealLand" || 
                Card.IDCard == "PowerTeleportPersonToTheTax")
            {
                ListContentPlayers candidatePlayers = new ListContentPlayers(playersList, PlayerTurn);

                UseCardToAnother useCardToAnother = new UseCardToAnother(candidatePlayers);

                foreach( ContentPlayer ButtonPlayer in useCardToAnother.haha.ListButtonPlayers)
                {
                    ButtonPlayer.NameCardImpact = Card.IDCard;
                    ButtonPlayer.OnButtonPlayerClick += ButtonPlayer_OnButtonPlayerClick;
                }
                dices.Content = useCardToAnother;
            }   
            else
            {
                Player player = playersList[PlayerTurn];
                Power power = playersList[PlayerTurn].powers[index];
                power.Using(ref player, dice);
                power.PowerFunction(ref player);
                playersList[PlayerTurn] = player;
            }   */

            if (Card.power.type)
            {
                Player player = playersList[PlayerTurn];
                Power power = Card.power;
                if (power.Using(ref player, dice)) power.PowerFunction(ref player);

                // nếu thẻ power đó có sử dụng đến đất
                if (power.usingLand)
                {
                    power.PowerFunction(ref player, 0);
                }

                playersList[PlayerTurn] = player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;

                if (playersList[PlayerTurn].isRetention)
                {
                    Player _player = playersList[PlayerTurn];
                    RemovePowersEffect(ref _player);
                    playersList[PlayerTurn] = _player;
                    PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                }

                But_xucxac.Visibility = Visibility.Visible;
                dices.Content = null;
                //animation faceout 
                //Storyboard slide = Resources["OpenMenu"] as Storyboard;
                //slide.Begin(notification);


                sideBar.update(playersList, PlayerTurn);

            }
            else
            {
                ListContentPlayers candidatePlayers = new ListContentPlayers(playersList, PlayerTurn);

                UseCardToAnother useCardToAnother = new UseCardToAnother(candidatePlayers);
                useCardToAnother.OnButtonCancleClick += UseCardToAnother_OnButtonCancleClick;

                foreach (ContentPlayer ButtonPlayer in useCardToAnother.haha.ListButtonPlayers)
                {
                    ButtonPlayer.power = Card.power;
                    ButtonPlayer.NameCardImpact = Card.IDCard;
                    ButtonPlayer.OnButtonPlayerClick += ButtonPlayer_OnButtonPlayerClick;
                }
                dices.Content = useCardToAnother;
            }
        }

        private void UseCardToAnother_OnButtonCancleClick(object sender, RoutedEventArgs e)
        {
            dices.Content = _usingCard;
        }

        //xử lý sự kiện sau khi chọn được người hứng chịu hiệu ứng của thẻ quyền năng
        private void ButtonPlayer_OnButtonPlayerClick(object sender, RoutedEventArgs e)
        {
            //throw new NotImplementedException();
            ContentPlayer PickedPlayer = sender as ContentPlayer;

            for (int i = 0; i < playersList.Count; i++) // trong danh sách các người chơi 
            {
                if (playersList[i].name == PickedPlayer.NamePlayer) // xác định người chơi nào bị chọn
                {
                    Player playerUse = playersList[PlayerTurn];
                    Player affectedPlayers = playersList[i];
                    if (PickedPlayer.power.Using(ref playerUse, ref affectedPlayers, dice) && !affectedPlayers.isImmune)
                    {
                        PickedPlayer.power.PowerFunction(ref affectedPlayers);

                        //những thẻ di chuyển người chơi nên cần update lại vị trí
                        if (PickedPlayer.NameCardImpact == "PowerAppointPersonToPrison" ||
                            PickedPlayer.NameCardImpact == "PowerTeleportPersonToTheTax")
                        {
                            if (playersList[i].position == 10) playersList[PlayerTurn].isInPrison = true;
                            Grid.SetRow(players[i], Grid.GetRow(cellPos[playersList[i].position]));
                            Grid.SetColumn(players[i], Grid.GetColumn(cellPos[playersList[i].position]));
                        }

                        // nếu thẻ power đó có sử dụng đến đất
                        if (PickedPlayer.power.usingLand)
                        {
                            PickedPlayer.power.PowerFunction(ref affectedPlayers, 0);
                            if (PickedPlayer.NameCardImpact == "PowerStealLand")
                            {
                                lands[cellManager[0].index].owner = PlayerTurn;
                                playerUse.AddLand(lands[cellManager[0].index], cellManager[0].index);
                            }
                        }
                    }

                    playersList[PlayerTurn] = playerUse;
                    playersList[i] = affectedPlayers;
                    PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                    if (playersList[PlayerTurn].isRetention)
                    {
                        Player player = playersList[PlayerTurn];
                        RemovePowersEffect(ref player);
                        playersList[PlayerTurn] = player;
                        PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                    }

                    But_xucxac.Visibility = Visibility.Visible;
                    dices.Content = null;
                    //animation faceout 

                    //Storyboard slide = Resources["OpenMenu"] as Storyboard;
                    //slide.Begin(notification);



                    sideBar.update(playersList, PlayerTurn);
                    /*if(PickedPlayer.NameCardImpact == "PowerAppointPersonToPrison")
                   {

                       // sự kiện khi pick thẻ PowerAppointPersonToPrison viết ở đây, người bị chọn có chỉ số là i
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerCancelPowerCard")
                   {

                       // sự kiện khi pick thẻ PowerCancelPowerCard viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerFreezeBankAccounts")
                   {

                       // sự kiện khi pick thẻ PowerFreezeBankAccounts viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerHoldAPerson")
                   {

                       // sự kiện khi pick thẻ PowerHoldAPerson viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerLandLevelReduction")
                   {

                       // sự kiện khi pick thẻ PowerLandLevelReduction viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerLandPriceHalved")
                   {

                       // sự kiện khi pick thẻ PowerLandPriceHalved viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerLockAPlotOfLand")
                   {

                       // sự kiện khi pick thẻ PowerLockAPlotOfLand viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerSplitDice")
                   {

                       // sự kiện khi pick thẻ PowerSplitDice viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerStealLand")
                   {

                       // sự kiện khi pick thẻ PowerStealLand viết ở đây
                   }
                   else if (PickedPlayer.NameCardImpact == "PowerTeleportPersonToTheTax")
                   {

                       // sự kiện khi pick thẻ PowerTeleportPersonToTheTax viết ở đây
                   }*/


                }
            }
            //ComeOwnLandView_OnSkipButtonClick(sender, e);
        }

        //bỏ qua
        private void ComeOwnLandView_OnSkipButtonClick(object sender, RoutedEventArgs e)
        {
            //tính lượt của các player
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention) PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers; if (playersList[PlayerTurn].isRetention)
            {
                Player player = playersList[PlayerTurn];
                RemovePowersEffect(ref player);
                playersList[PlayerTurn] = player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }


            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = null;
            //animation faceout 

            //Storyboard slide = Resources["OpenMenu"] as Storyboard;
            //slide.Begin(notification);



        }

        //bán đất
        private void ComeOwnLandView_OnBuyButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu người chơi bán thì gọi lệnh bên dưới
            //đóng băng tài khoản bán k đc cộng tiền
            if (!playersList[PlayerTurn].isFreezeBank) playersList[PlayerTurn].money += lands[cellManager[playersList[PlayerTurn].position].index].landValue / 2;
            playersList[PlayerTurn].RemoveLand(cellManager[playersList[PlayerTurn].position].index);
            lands[cellManager[playersList[PlayerTurn].position].index].GetDefault();

            sideBar.update(playersList, PlayerTurn);

            //tính lượt của các player
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention)
            {
                Player player = playersList[PlayerTurn];
                RemovePowersEffect(ref player);
                playersList[PlayerTurn] = player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }


            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = null;
            //animation faceout 

            //Storyboard slide = Resources["OpenMenu"] as Storyboard;
            //slide.Begin(notification);


        }

        //nâng cấp
        private void ComeOwnLandView_OnSellButtonClick(object sender, RoutedEventArgs e)
        {
            //nếu player đồng ý nâng cấp thì gọi lệnh bên dưới
            if ((playersList[PlayerTurn].money > lands[cellManager[playersList[PlayerTurn].position].index].Upgrade() || playersList[PlayerTurn].isLoseMoney) && !playersList[PlayerTurn].isFreezeBank)
            {
                int fee = 1;
                if (!playersList[PlayerTurn].isLoseMoney)
                {
                    if (playersList[PlayerTurn].isUpgradeFee)
                    {
                        playersList[PlayerTurn].isUpgradeFee = false;
                        fee = 2;
                    }
                    playersList[PlayerTurn].money -= lands[cellManager[playersList[PlayerTurn].position].index].Upgrade() / fee;
                    playersList[PlayerTurn].UpdateLand(cellManager[playersList[PlayerTurn].position].index);
                }
                else playersList[PlayerTurn].isLoseMoney = false;

                sideBar.update(playersList, PlayerTurn);

                //tính lượt của các player
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                if (playersList[PlayerTurn].isRetention)
                {
                    Player player = playersList[PlayerTurn];
                    RemovePowersEffect(ref player);
                    playersList[PlayerTurn] = player;
                    PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                }
                But_xucxac.Visibility = Visibility.Visible;
                dices.Content = null;
                //animation faceout 

                //Storyboard slide = Resources["OpenMenu"] as Storyboard;
                //slide.Begin(notification);


            }
            else MessageBox.Show("không đủ tiền");


            sideBar.update(playersList, PlayerTurn);
        }

        //bỏ qua
        private void ComeEmptyLandView_OnSkipButtonClick(object sender, RoutedEventArgs e)
        {
            //tính lượt của các player
            PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            if (playersList[PlayerTurn].isRetention)
            {
                Player player = playersList[PlayerTurn];
                RemovePowersEffect(ref player);
                playersList[PlayerTurn] = player;
                PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
            }


            sideBar.update(playersList, PlayerTurn);
            But_xucxac.Visibility = Visibility.Visible;
            dices.Content = null;

            //animation faceout 
            //Storyboard slide = Resources["OpenMenu"] as Storyboard;
            //slide.Begin(notification);




        }

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
                playersList[PlayerTurn].AddLand(lands[cellManager[playersList[PlayerTurn].position].index], cellManager[playersList[PlayerTurn].position].index);
                sideBar.update(playersList, PlayerTurn);

                Noti.Show(notiCenterMapArea, new NotiBuyLand(lands[cellManager[playersList[PlayerTurn].position].index].name), 2, (s) =>
                {
                    //tính lượt của các player
                    PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                    if (playersList[PlayerTurn].isRetention)
                    {
                        Player player = playersList[PlayerTurn];
                        RemovePowersEffect(ref player);
                        playersList[PlayerTurn] = player;
                        PlayerTurn = (PlayerTurn + 1) % NumberOfPlayers;
                    }
                    But_xucxac.Visibility = Visibility.Visible;
                    dices.Content = null;
                    sideBar.update(playersList, PlayerTurn);
                });

                
                
                //animation faceout 

                //Storyboard slide = Resources["OpenMenu"] as Storyboard;
                //slide.Begin(notification);



            }
            else
            {
                Noti.Show(notiCenterMapArea, new NotiBoxOnlyText("Bạn không đủ tiền", "Red"), 1.5, (s) =>{});
            }
            
        }



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
