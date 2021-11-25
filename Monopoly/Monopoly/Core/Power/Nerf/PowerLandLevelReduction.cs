using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // giảm level đất người khác
    class PowerLandLevelReduction : Power
    {
        public PowerLandLevelReduction() : base()
        {
            value = 2500;
            name = "Giảm level";
            description = "Giảm 2 level hành tinh của người khác";
        }

        public PowerLandLevelReduction(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money > dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerLandLevelReduction());
                return true;
            }
            return false;
        }
    }
}
