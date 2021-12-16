﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityChestGoToStart: CommunityChest
    {
        public CommunityChestGoToStart()
        {
            name = "Đến Cổng Dịch Chuyển";
            description = "Gặp WormHole bạn sẽ được đến cổng";
            icon = "/Monopoly;component/Images/Card_Icon/Card37.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position = 0;
        }
    }
}
