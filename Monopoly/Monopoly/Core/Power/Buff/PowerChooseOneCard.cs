using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //chọn 1 thẻ khí vận or cơ hội
    class PowerChooseOneCard:Power
    {
        public PowerChooseOneCard():base()
        {
            value = 500;
            name = "Chọn 1 thẻ khí vận hoặc cơ hội";
        }

        public PowerChooseOneCard(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, int dice)
        {
            
        }
    }
}
