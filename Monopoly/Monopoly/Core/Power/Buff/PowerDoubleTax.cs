using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Tăng gấp đôi giá trị thuế
    class PowerDoubleTax:Power
    {
        public PowerDoubleTax():base()
        {
            value = 1500;
            name = "tăng giá trị thuế";
        }

        public PowerDoubleTax(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
