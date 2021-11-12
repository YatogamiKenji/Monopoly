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

        }

        public PowerHalveUpgradeFee(string name, int value) : base(name, value)
        {

        }
    }
}
