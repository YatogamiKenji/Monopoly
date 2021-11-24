using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Giảm 1 nữa tiền nâng cấp nhà
    class PowerHalveUpgradeFee: Power
    {
        public PowerHalveUpgradeFee():base()
        {
            value = 1800;
            name = "giảm tiền nâng cấp nhà";
        }

        public PowerHalveUpgradeFee(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
