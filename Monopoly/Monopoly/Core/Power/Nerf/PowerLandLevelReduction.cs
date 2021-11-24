using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // giảm level đất người khác
    class PowerLandLevelReduction:Power
    {
        public PowerLandLevelReduction():base()
        {
            value = 2500;
            name = "Giảm level";
        }

        public PowerLandLevelReduction(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
