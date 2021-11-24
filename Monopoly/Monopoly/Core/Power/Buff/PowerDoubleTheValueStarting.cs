using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Tăng gấp đôi giá trị khi đi qua ô bắt đầu
    class PowerDoubleTheValueStarting: Power
    {
        public PowerDoubleTheValueStarting() : base()
        {
            value = 500;
            name = "tăng gấp đôi giá trị khi đi qua ô bắt đầu";
        }

        public PowerDoubleTheValueStarting(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
