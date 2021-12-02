using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // tăng giá trị đất gấp đôi vĩnh viễn
    class PowerDoublePriceLandForever : Power
    {
        public PowerDoublePriceLandForever() : base()
        {
            value = 3000;
            name = "Tăng giá trị hành tinh";
            description = "Tăng gấp đôi giá trị hành tinh";
            type = true;
            usingLand = true;
        }

        public PowerDoublePriceLandForever(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerDoublePriceLandForever());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            for (int i = 0; i < playerUse.lands.Count; i++)
                if (playerUse.indexLands[i] == index)
                {
                    playerUse.lands[i].isDoublePrice = true;
                    break;
                }
        }
    }
}
