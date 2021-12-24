using System;

namespace Monopoly
{
    public class Land
    {
        // Tên mảnh đất
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        private string _nameDefault;

        //link avt land
        private string _avatar;
        public string avatar
        {
            get { return _avatar; }
            set { _avatar = value; }
        }

        // Giá trị ban đầu của mảnh đất
        private int _value;
        public int value
        {
            get
            {
                if (_isReduceValue) return _value / 2;
                return _value;
            }
            set { _value = value; }
        }

        private int _valueDefault;

        // Tổng giá trị mảnh đất sau mỗi lần nâng cấp
        private int _landValue;
        public int landValue
        {
            get
            {
                if (_isDoublePrice) return 2 * _landValue;
                else if (_isReduceValue) return (int)(0.5 * _landValue);
                return _landValue;
            }
            set { _landValue = value; }
        }

        // Cấp độ của mảnh đất
        private byte _level;
        public byte level
        {
            get { return _level; }
            set { _level = value; }
        }

        // chủ nhân -1: vô chủ, 0: player1, 1: player 2, 2: player3, 3: player 4
        private int _owner;
        public int owner
        {
            get { return _owner; }
            set { _owner = value; }
        }

        //mô tả mảnh đất :v
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }


        // tăng gấp đôi giá thuế đất
        private bool _isDoubleTax;
        public bool isDoubleTax
        {
            get { return _isDoubleTax; }
            set { _isDoubleTax = value; }
        }

        //tăng giá trị đất
        private bool _isDoublePrice;
        public bool isDoublePrice
        {
            get { return _isDoublePrice; }
            set { _isDoublePrice = value; }
        }

        // giảm giá trị đất
        private bool _isReduceValue;
        public bool isReduceValue
        {
            get { return _isReduceValue; }
            set { _isReduceValue = value; }
        }

        // Contructor không đối số
        public Land()
        {
            _name = "";
            _value = 0;
            _level = 0;
            _landValue = 0;
            Init();
        }

        // Contructor đầy đủ các đối số
        public Land(string name, int value, byte level)
        {
            _name = name;
            _value = value;
            _landValue = value;
            _level = level;
            Init();
        }

        public void Init()
        {
            _owner = -1;
            _isDoublePrice = false;
            _isDoubleTax = false;
            _isLock = false;
        }

        // Thuế phải trả khi đi vào ô đất
        public int Tax()
        {
            double tax = 1;
            if (_isDoubleTax) tax = 2;
            if (_isDoublePrice) tax *= 2;
            if (_isReduceValue) tax = tax * 0.5;
            if (_level >= 0 && _level <= 3) return (int)(tax * Convert.ToInt32(Math.Ceiling(0.1 * _landValue)));
            return (int)(tax * Convert.ToInt32(Math.Ceiling(0.2 * _landValue)));
        }

        // Thuế từng level
        public int Tax(int level)
        {
            double tax = 1;
            if (_isDoubleTax) tax = 2;
            if (_isDoublePrice) tax *= 2;
            if (_isReduceValue) tax /= 2;
            if (level == 0) return (int)(tax * Convert.ToInt32(Math.Ceiling(0.1 * _value)));
            else if (level == 1) return (int)(tax * Convert.ToInt32(Math.Ceiling(0.24 * _value)));
            else if (level == 2) return (int)(tax * Convert.ToInt32(Math.Ceiling(0.4 * _value)));
            else if (level == 3) return (int)(tax * Convert.ToInt32(Math.Ceiling(0.58 * _value)));
            else if (level == 4) return (int)(tax * Convert.ToInt32(Math.Ceiling(0.78 * _value)));
            return (int)(tax * Convert.ToInt32(Math.Ceiling(1.08 * _value)));
        }

        // Nâng cấp lên level tiếp theo
        public int Upgrade()
        {
            if (_level == 0)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.4 * _value));
                _level++;
                return Convert.ToInt32(Math.Ceiling(1.4 * _value));
            }
            else if (_level == 1)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.6 * _value));
                _level++;
                return Convert.ToInt32(Math.Ceiling(1.6 * _value));
            }
            else if (_level == 2)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.8 * _value));
                _level++;
                return Convert.ToInt32(Math.Ceiling(1.8 * _value));
            }
            else if (_level == 3)
            {
                _landValue += 2 * _value;
                _level++;
                return 2 * _value;
            }
            _landValue += 3 * _value;
            _level++;
            return 3 * _value;
        }

        //giá nâng cấp từng level
        public int Upgrade(int level)
        {
            if (level == 1)
                return Convert.ToInt32(Math.Ceiling(1.4 * _value));
            else if (level == 2)
                return Convert.ToInt32(Math.Ceiling(1.6 * _value));
            else if (level == 3)
                return Convert.ToInt32(Math.Ceiling(1.8 * _value));
            else if (level == 4)
                return 2 * _value;
            return 3 * _value;
        }

        public void LowerLevel()
        {
            if (_level == 5) _landValue -= 5 * _value;
            else if (_level == 4) _landValue -= Convert.ToInt32(Math.Ceiling(3.8 * _value));
            else if (_level == 3) _landValue -= Convert.ToInt32(Math.Ceiling(3.4 * _value));
            else _landValue = _value;
            if (_level - 2 >= 0) _level -= 2;
            else _level = 0;
        }

        public int SellLand()
        {
            return _value / 2;
        }

        //kiểm tra đất có đang bị khóa không
        private bool _isLock;
        public bool isLock
        {
            get { return _isLock; }
            set { _isLock = value; }
        }

        //trả về dữ liệu mặc định
        public void GetDefault()
        {
            _name = _nameDefault;
            _value = _valueDefault;
            _level = 0;
            _landValue = _value;
            _owner = -1;
            Init();
        }

        //set dữ liệu mặc định
        public void SetDefault()
        {
            _nameDefault = _name;
            _valueDefault = _value;
            Init();
        }
    }
}
