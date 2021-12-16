using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceGotoPrison: Chance
    {
        public ChanceGotoPrison()
        {
            name = "Vào tù";
            description = "Vào tù";
            icon = "/Monopoly;component/Images/Card_Icon/Card18.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position = 10;
        }
    }
}
