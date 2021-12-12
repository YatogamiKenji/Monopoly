using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // ăn cắp đất
    class PowerStealLand : Power
    {
        public PowerStealLand() : base()
        {
            value = 3000;
            name = "Trộm hành tinh";
            description = "Biến một ô đất của ai đó thành của mình";
            type = false;
            usingLand = true;
        }

        public PowerStealLand(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            playerUse.RemoveLand(index);
        }
    }
}
