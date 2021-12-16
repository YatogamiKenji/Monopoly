using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceBeingAttacked: Chance
    {
        public ChanceBeingAttacked()
        {
            name = "Bị tấn công";
            description = "Bị tấn công (Gặp phải dân Istanlao tấn công sửa chữa tàu)";
            icon = "/Monopoly;component/Images/Card_Icon/Card5.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= 2500;
        }
    }
}
