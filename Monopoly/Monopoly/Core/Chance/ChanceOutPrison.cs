﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceOutPrison: Chance
    {
        public ChanceOutPrison()
        {
            name = "Ra tù";
            description = "Sử dụng thẻ này để ra tù";
            icon = "/Monopoly;component/Images/Card_Icon/Card20.png";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.isOutPrisonCard = true;
        }
    }
}
