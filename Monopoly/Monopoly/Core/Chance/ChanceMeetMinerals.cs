using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceMeetMinerals: Chance
    {
        public ChanceMeetMinerals()
        {
            name = "Gặp khoáng sản";
            description = "Gặp khoáng sản quý hiếm thưởng 3000";
            icon = "/Monopoly;component/Images/Card_Icon/Card25.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 3000;
        }
    }
}
