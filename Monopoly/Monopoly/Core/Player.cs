using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        private bool _isOutPrison;
        public bool isOutPrison
        {
            get { return _isOutPrison; }
            set { _isOutPrison = value; }
        }

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
            _isOutPrison = false;
            _powers = new List<Power>();
            _powersEffect = new List<Power>();
            _lands = new List<Land>();
            Init();
        }

        //Contructor có đối số
        public Player(string name, int money, byte posititon, bool outPrison)
        {
            _name = name;
            _money = money;
            _position = posititon;
            _isOutPrison = outPrison;
            _powers = new List<Power>();
            _powersEffect = new List<Power>();
            _lands = new List<Land>();
            Init();
        }

        public void Init()
        {
            _isUpgradeFee = false;
            _isDoubleStart = false;
            _isDoubleDice = false;
            _isSplitDice = false;
            _isInPrison = false;
            _isImmune = false;
            _isLoseMoney = false;
            _isFreezeBank = false;
            _isRetention = false;
        }

        // Thêm đất vào khi mua
        public void AddLand(Land land)
        {
            _lands.Add(land);
        }

        // Xóa bỏ mảnh đất sau khi bán
        public void RemoveLand(string name)
        {
            for (int i = 0; i < _lands.Count; i++)
                if (_lands[i].name == name)
                {
                    _lands.RemoveAt(i);
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

        // kiểm tra giảm 1 nữa tiền nâng cấp tiếp theo
        private bool _isUpgradeFee;
        public bool isUpgradeFee
        {
            get { return _isUpgradeFee; }
            set { _isUpgradeFee = value; }
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
    }
}
