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

        //mô tả thẻ quyền năng :v
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Contructor không tham số
        public Power()
        {
            _name = "";
            _value = 0;
            _description = "";
        }

        // Contructor có tham số
        public Power(string name, int value, string description)
        {
            _name = name;
            _value = value;
            _description = description;
        }

        public virtual void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }

        public virtual void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
