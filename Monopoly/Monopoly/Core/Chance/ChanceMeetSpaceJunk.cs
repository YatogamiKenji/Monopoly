using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class ChanceMeetSpaceJunk: Chance
    {
        public ChanceMeetSpaceJunk()
        {
            name = "Va phải rác vũ trụ";
            description = "Va phải rác vũ trụ che tầm nhìn (Chất thải rắn của tàu khác) trả tiền sửa chữa 500";
            icon = "/Monopoly;component/Images/Card_Icon/Card6.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= 500;
        }
    }
}
