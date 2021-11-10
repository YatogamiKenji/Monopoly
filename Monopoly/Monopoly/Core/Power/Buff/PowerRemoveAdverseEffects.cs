using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //loại bỏ hiệu ứng bất lợi trong X lượt
    class PowerRemoveAdverseEffects: Power
    {
        public PowerRemoveAdverseEffects():base()
        {

        }

        public PowerRemoveAdverseEffects(string name, int value):base(name,value)
        {

        }
    }
}
