﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityChestOvertime: CommunityChest
    {
        public CommunityChestOvertime()
        {
            name = "Làm công việc ngoài giờ";
            description = "Làm công việc ngoài giờ tại các hành tinh";
            icon = "/Monopoly;component/Images/Card_Icon/Card26.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 1000;
        }
    }
}
