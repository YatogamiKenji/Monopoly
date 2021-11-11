using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
    class CellLand : CellBase
    {
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
        public CellLand(): base()
        {
            _value = 0;
            _level = 0;
            _landValue = 0;
        }

        // Contructor đầy đủ các đối số
        public CellLand(string name, int value, byte level): base(name)
        {
            this._value = value;
            _landValue = value;
            this._level = level;
        }

        public override void Chuc_nang()
        {
            MessageBox.Show(name + " " + value.ToString() + " " + level.ToString());
        }
    }
}
