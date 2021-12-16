using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityChestBribe: CommunityChest
    {
        public CommunityChestBribe()
        {
            name = "Hối lộ lên chức";
            description = "Hối lộ lên chức trả mỗi người 500";
            icon = "/Monopoly;component/Images/Card_Icon/Card21.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            
        }
    }
}
