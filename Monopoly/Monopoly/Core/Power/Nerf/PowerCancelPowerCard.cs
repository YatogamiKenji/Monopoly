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
            value = 2000;
            name = "Hủy bỏ quyền năng";
        }

        public PowerCancelPowerCard(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
