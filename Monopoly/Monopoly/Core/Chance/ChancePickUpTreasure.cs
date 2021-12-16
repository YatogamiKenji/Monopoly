using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChancePickUpTreasure: Chance
    {
        public ChancePickUpTreasure()
        {
            name = "Nhặt được kho báu";
            description = "Nhặt được kho báu";
            icon = "/Monopoly;component/Images/Card_Icon/Card35.png";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 2000;
        }
    }
}
