using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        //link avt land
        private string _avatar;
        public string avatar
        {
            get { return _avatar; }
            set { _avatar = avatar; }
        }

        // Giá trị ban đầu của mảnh đất
        private int _value;
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        // Tổng giá trị mảnh đất sau mỗi lần nâng cấp
        private int _landValue;
        public int landValue
        {
            get { return _landValue; }
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

        // Contructor không đối số
        public Land()
        {
            _name = "";
            _value = 0;
            _level = 0;
            _landValue = 0;
            _owner = -1;
        }

        // Contructor đầy đủ các đối số
        public Land(string name, int value, byte level)
        {
            _name = name;
            _value = value;
            _landValue = value;
            _level = level;
            _owner = -1;
        }

        // Thuế phải trả khi đi vào ô đất
        public int Tax()
        {
            if (_level >= 1 && _level <= 3) return Convert.ToInt32(Math.Ceiling(0.1 * _landValue));
            return Convert.ToInt32(Math.Ceiling(0.2 * _landValue));
        }

        public int Tax(int level)
        {
            if (level == 0) return Convert.ToInt32(Math.Ceiling(0.1 * _value));
            else if (level == 1) return Convert.ToInt32(Math.Ceiling(0.24 * _value));
            else if (level == 2) return Convert.ToInt32(Math.Ceiling(0.4 * _value));
            else if (level == 3) return Convert.ToInt32(Math.Ceiling(0.58 * _value));
            else if (level == 4) return Convert.ToInt32(Math.Ceiling(0.78 * _value));
            return Convert.ToInt32(Math.Ceiling(1.08 * _value));
        }

        // Giá cần để nâng cấp lên level tiếp theo
        public int Upgrade()
        {
            if (_level == 1)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.4 * _value));
                _level++;
                return Convert.ToInt32(Math.Ceiling(1.4 * _value));
            }
            else if (_level == 2)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.6 * _value));
                _level++;
                return Convert.ToInt32(Math.Ceiling(1.6 * _value));
            }
            else if (_level == 3)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.8 * _value));
                _level++;
                return Convert.ToInt32(Math.Ceiling(1.8 * _value));
            }
            else if (_level == 4)
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
    }
}
