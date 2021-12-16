using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceErrorMap: Chance
    {
        public ChanceErrorMap()
        {
            name = "Bản đồ bị lỗi";
            description = "Đi lùi 4 bước";
            icon = "/Monopoly;component/Images/Card_Icon/Card21.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position -= 4;
        }
    }
}
