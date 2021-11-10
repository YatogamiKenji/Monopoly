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

        // Giá trị ban đầu của mảnh đất
        private int _value;
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        // Giá trị mảnh đất sau mỗi lần nâng cấp
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

        // Contructor không đối số
        public Land()
        {
            _name = "";
            _value = 0;
            _level = 0;
            _landValue = 0;
        }

        // Contructor đầy đủ các đối số
        public Land(string name, int value, byte level)
        {
            this._name = name;
            this._value = value;
            _landValue = value;
            this._level = level;
        }

        // Thuế phải trả khi đi vào ô đất
        public int Tax()
        {
            if (_level >= 1 && _level <= 3) return Convert.ToInt32(Math.Ceiling(0.1 * _landValue));
            return Convert.ToInt32(Math.Ceiling(0.2 * _landValue));
        }

        // Giá cần để nâng cấp lên từng level
        public int Upgrade()
        {
            if (_level == 1)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.4 * _value));
                return Convert.ToInt32(Math.Ceiling(1.4 * _value));
            }
            else if (_level == 2)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.6 * _value));
                return Convert.ToInt32(Math.Ceiling(1.6 * _value));
            }
            else if (_level == 3)
            {
                _landValue += Convert.ToInt32(Math.Ceiling(1.8 * _value));
                return Convert.ToInt32(Math.Ceiling(1.8 * _value));
            }
            else if (_level == 4)
            {
                _landValue += 2 * _value;
                return 2 * _value;
            }
            _landValue += 3 * _value;
            return 3 * _value;
        }
    }
}
