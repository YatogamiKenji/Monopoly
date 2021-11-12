using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Power
    {
        // Tên thẻ quyền năng
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Giá trị thẻ quyền năng
        private int _value;
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        // Contructor không tham số
        public Power()
        {
            _name = "";
            _value = 0;
        }

        // Contructor có tham số
        public Power(string name, int value)
        {
            this._name = name;
            this._value = value;
        }
    }
}
