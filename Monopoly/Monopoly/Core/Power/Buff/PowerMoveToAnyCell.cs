using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //dịch chuyển đến 1 ô bất kỳ
    class PowerMoveToAnyCell: Power
    {
        public PowerMoveToAnyCell():base()
        {

        }

        public PowerMoveToAnyCell(string name, int value) : base(name, value)
        {

        }
    }
}
