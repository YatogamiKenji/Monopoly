using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //dịch chuyển đến 1 ô bất kỳ
    class PowerMoveToAnyCell: Power
    {
        public PowerMoveToAnyCell():base()
        {
            value = 1000;
            name = "Dịch chuyển";
        }

        public PowerMoveToAnyCell(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
