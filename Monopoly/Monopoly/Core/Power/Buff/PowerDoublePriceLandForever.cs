using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // tăng giá trị đất gấp đôi vĩnh viễn
    class PowerDoublePriceLandForever:Power
    {
        public PowerDoublePriceLandForever():base()
        {
            value = 3000;
            name = "Tăng giá trị đất";
        }

        public PowerDoublePriceLandForever(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
