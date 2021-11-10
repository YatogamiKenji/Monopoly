using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //dịch chuyển một người đến ô nào đó và phải trả thuế
    class PowerTeleportPersonToTheTax : Power
    {
        public PowerTeleportPersonToTheTax():base()
        {

        }

        public PowerTeleportPersonToTheTax(string name, int value) : base(name, value)
        {

        }
    }
}
