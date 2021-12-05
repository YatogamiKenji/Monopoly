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
            type = false;
            usingLand = true;
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
                affectedPlayers.lands[0].LowerLevel();
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            for (int i = 0; i < playerUse.lands.Count; i++)
                if (playerUse.indexLands[i] == index)
                {
                    playerUse.lands[i].LowerLevel();
                    break;
                }
        }
    }
}
