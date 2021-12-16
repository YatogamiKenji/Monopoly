using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityChestWinTheRace: CommunityChest
    {
        public CommunityChestWinTheRace()
        {
            name = "Thắng giải đua tàu vũ trụ";
            description = "Thắng giải đua tàu vũ trụ";
            icon = "/Monopoly;component/Images/Card_Icon/Card34.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 2000;
        }
    }
}
