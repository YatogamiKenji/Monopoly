using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityChestHomeRepair: CommunityChest
    {
        public CommunityChestHomeRepair()
        {
            name = "Sửa chữa hành tinh";
            description = "Sửa chữa hành tinh";
            icon = "/Monopoly;component/Images/Card_Icon/Card13.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= playerUse.lands.Count * 200;
        }
    }
}
