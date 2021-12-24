using System.Collections.Generic;

namespace Monopoly
{
    public class Player
    {
        // Tên người chơi
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        //link avt player
        private string _avatar;
        public string avatar
        {
            get { return _avatar; }
            set { _avatar = avatar; }
        }

        // Tiền người chơi có
        private int _money;
        public int money
        {
            get { return _money; }
            set { _money = value; }
        }

        // Vị trí hiện tại của nhân vật trên map
        private int _position;
        public int position
        {
            get { return _position; }
            set { _position = value; }
        }

        // Kiểm tra thử xem người chơi có vé ra tù không
        private bool _isOutPrisonCard;
        public bool isOutPrisonCard
        {
            get { return _isOutPrisonCard; }
            set { _isOutPrisonCard = value; }
        }

        // kiểm tra xem có tác dụng của miễn vô tù không
        private bool _isOutPrison;
        public bool isOutPrison
        {
            get { return _isOutPrison; }
            set { _isOutPrison = value; }
        }

        // kiểm tra xem thử có đang ở trong tù không
        private bool _isInPrison;
        public bool isInPrison
        {
            get { return _isInPrison; }
            set { _isInPrison = value; }
        }

        // Danh sách quyền năng người chơi sở hữu
        private List<Power> _powers;
        public List<Power> powers
        {
            get { return _powers; }
            set { _powers = value; }
        }

        // Danh sách đất người chơi đang sở hữu
        private List<Land> _lands;
        public List<Land> lands
        {
            get { return _lands; }
            set { _lands = value; }
        }

        // Danh sách chứa vị trí các mảnh đất
        private List<int> _indexLands;
        public List<int> indexLands
        {
            get { return _indexLands; }
            set { _indexLands = value; }
        }

        // Danh sách chứa vị trí của mảnh đất trên bàn cờ
        private List<int> _indexCells;
        public List<int> indexCells
        {
            get { return _indexCells; }
            set { _indexCells = value; }
        }

        // Danh sách quyền năng đang còn tác dụng trên người chơi
        private List<Power> _powersEffect;
        public List<Power> powersEffect
        {
            get { return _powersEffect; }
            set { _powersEffect = value; }
        }

        //Contructor không tham số
        public Player()
        {
            _name = "";
            _money = 10000;
            _position = 0;
            _isOutPrisonCard = false;
            _powers = new List<Power>();
            _powersEffect = new List<Power>();
            _lands = new List<Land>();
            _indexLands = new List<int>();
            _indexCells = new List<int>();
            _isInPrison = false;
            _isDoubleStart = false;
            _isLoseMoney = false;
            _isLoser = false;
            Init();
        }

        //Contructor có đối số
        public Player(string name, int money, byte posititon, bool outPrison)
        {
            _name = name;
            _money = money;
            _position = posititon;
            _isOutPrisonCard = outPrison;
            _powers = new List<Power>();
            _powersEffect = new List<Power>();
            _lands = new List<Land>();
            _indexLands = new List<int>();
            _indexCells = new List<int>();
            _isInPrison = false;
            _isDoubleStart = false;
            _isLoseMoney = false;
            _isLoser = false;
            Init();
        }

        public void Init()
        {
            _isOutPrison = false;
            _isDoubleDice = false;
            _isSplitDice = false;
            _isImmune = false;
            _isFreezeBank = false;
            _isRetention = false;
            _isTeleport = false;
        }

        // Thêm đất vào khi mua
        public void AddLand(Land land, int indexL, int indexC)
        {
            _lands.Add(land);
            _indexLands.Add(indexL);
            _indexCells.Add(indexC);
        }

        // Xóa bỏ mảnh đất sau khi bán
        public void RemoveLand(string name)
        {
            for (int i = 0; i < _lands.Count; i++)
                if (_lands[i].name == name)
                {
                    _lands.RemoveAt(i);
                    _indexLands.RemoveAt(i);
                    _indexCells.RemoveAt(i);
                    break;
                }
        }

        // Xóa bỏ mảnh đất sau khi bán
        public void RemoveLand(int index)
        {
            for (int i = 0; i < _lands.Count; i++)
                if (_indexLands[i] == index)
                {
                    _lands.RemoveAt(i);
                    _indexLands.RemoveAt(i);
                    _indexCells.RemoveAt(i);
                    break;
                }
        }

        // Thêm các quyền năng đang sở hữu
        public void AddPower(Power power)
        {
            _powers.Add(power);
        }

        // Xóa bỏ quyền năng sau khi sử dụng
        public void RemovePower(string name)
        {
            for (int i = 0; i < _powers.Count; i++)
                if (_powers[i].name == name)
                {
                    _powers.RemoveAt(i);
                    break;
                }
        }

        // Các quyền năng đang được sử dụng trên người (Cả tốt lẫn xấu)
        public void AddPowersEffect(Power power)
        {
            _powersEffect.Add(power);
        }

        // loại bỏ các hiệu ứng đã hết hạn
        public void RemovePowerEffect(string name)
        {
            for (int i = 0; i < _powers.Count; i++)
                if (_powersEffect[i].name == name)
                {
                    _powersEffect.RemoveAt(i);
                    break;
                }
        }

        //kiểm tra tăng gấp đôi số xúc sắc
        private bool _isDoubleDice = false;
        public bool isDoubleDice
        {
            get { return _isDoubleDice; }
            set { _isDoubleDice = value; }
        }

        //kiểm tra chia đôi xúc sắc
        private bool _isSplitDice;
        public bool isSplitDice
        {
            get { return _isSplitDice; }
            set { _isSplitDice = value; }
        }

        // kiểm tra tăng gấp đôi tiền thưởng khi đi qua ô bắt đầu
        private bool _isDoubleStart = false;
        public bool isDoubleStart
        {
            get { return _isDoubleStart; }
            set { _isDoubleStart = value; }
        }

        // kiểm tra miễn nhiễm
        private bool _isImmune;
        public bool isImmune
        {
            get { return _isImmune; }
            set { _isImmune = value; }
        }

        // kiểm tra miễn mất tiền lần tiếp theo
        private bool _isLoseMoney;
        public bool isLoseMoney
        {
            get { return _isLoseMoney; }
            set { _isLoseMoney = value; }
        }

        //Kiểm tra đóng băng tài khoản ngân hàng
        private bool _isFreezeBank;
        public bool isFreezeBank
        {
            get { return _isFreezeBank; }
            set { _isFreezeBank = value; }
        }

        //kiểm tra xem thử có đang bị giữ chân không
        private bool _isRetention;
        public bool isRetention
        {
            get { return _isRetention; }
            set { _isRetention = value; }
        }

        //kiểm tra xem có tác dụng của power dịch chuyển không
        private bool _isTeleport;
        public bool isTeleport
        {
            get { return _isTeleport; }
            set { _isTeleport = value; }
        }

        //kiểm tra xem thử người chơi có thua chưa
        private bool _isLoser;
        public bool isLoser
        {
            get { return _isLoser; }
            set { _isLoser = value; }
        }

        //Trả lại tất cả khi người chơi thua cuộc
        public void Loser()
        {
            _isLoser = true;
            _money = 0;
            _position = 0;
            _isOutPrisonCard = false;
            _powers.Clear();
            _powersEffect.Clear();
            _lands.Clear();
            _indexLands.Clear();
            _indexCells.Clear();
            _isInPrison = false;
            _isDoubleStart = false;
            _isLoseMoney = false;
            Init();
        }    
    }
}
