using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Chỉ định 1 người vào tù
    class PowerAppointPersonToPrison:Power
    {
        public PowerAppointPersonToPrison():base()
        {
            value = 1000;
            name = "vào tù";
        }

        public PowerAppointPersonToPrison(string name, int value, string description) : base(name, value, description)
        {

        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {
            
        }
    }
}
