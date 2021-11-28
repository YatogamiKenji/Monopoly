using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Loại bỏ lần mất tiền tiếp theo
    class PowerRemoveLoseMoneyNext : Power
    {
        public PowerRemoveLoseMoneyNext() : base()
        {
            value = 700;
            name = "Không mất tiền";
            description = "Loại bỏ lần mất tiền tiếp theo";
            type = true;
        }

        public PowerRemoveLoseMoneyNext(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                playerUse.isLoseMoney = true;
                return true;
            }
            return false;
        }
    }
}
