using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // ăn cắp đất
    class PowerStealLand:Power
    {
        public PowerStealLand():base()
        {
            value = 3000;
            name = "Trộm đất";
        }

        public PowerStealLand(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
