using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //hủy bỏ 1 thẻ quyền năng của người khác
    class PowerCancelPowerCard:Power
    {
        public PowerCancelPowerCard():base()
        {

        }

        public PowerCancelPowerCard(string name, int value) : base(name, value)
        {

        }
    }
}
