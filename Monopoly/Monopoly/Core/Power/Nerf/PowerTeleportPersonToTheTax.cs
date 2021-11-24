using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //dịch chuyển một người đến ô nào đó và phải trả thuế
    class PowerTeleportPersonToTheTax : Power
    {
        public PowerTeleportPersonToTheTax():base()
        {
            value = 700;
            name = "ép buộc";
        }

        public PowerTeleportPersonToTheTax(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
