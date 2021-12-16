using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceRescueShipDistress: Chance
    {
        public ChanceRescueShipDistress()
        {
            name = "Cứu tàu bị nạn";
            description = "Cứu tàu bị nạn";
            icon = "/Monopoly;component/Images/Card_Icon/Card9.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 1000;
        }
    }
}
