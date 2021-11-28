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
        public PowerTeleportPersonToTheTax() : base()
        {
            value = 700;
            name = "Ép buộc";
            description = "Dịch chuyển một người chơi đến ô bất kỳ";
            type = false;
        }

        public PowerTeleportPersonToTheTax(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money > dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }
    }
}
