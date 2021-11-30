using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Giảm 1 nữa tiền nâng cấp nhà
    class PowerHalveUpgradeFee : Power
    {
        public PowerHalveUpgradeFee() : base()
        {
            value = 1800;
            name = "Giảm tiền nâng cấp";
            description = "Giảm một nữa tiền nâng cấp nhà";
            type = true;
            usingLand = false;
        }

        public PowerHalveUpgradeFee(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerHalveUpgradeFee());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            playerUse.RemovePowerEffect(name);
            playerUse.isUpgradeFee = true;
        }
    }
}
