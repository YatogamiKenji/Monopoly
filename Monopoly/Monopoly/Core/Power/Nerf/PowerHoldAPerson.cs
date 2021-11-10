using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // giữ chân 1 người trong 5 lượt
    class PowerHoldAPerson:Power
    {
        public PowerHoldAPerson():base()
        {

        }

        public PowerHoldAPerson(string name, int value) :base(name,value)
        {

        }
    }
}
