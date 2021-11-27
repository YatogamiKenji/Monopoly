using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Tăng gấp đôi giá trị khi đi qua ô bắt đầu
    class PowerDoubleTheValueStarting : Power
    {
        public PowerDoubleTheValueStarting() : base()
        {
            value = 500;
            name = "Gấp đôi giá trị Cổng dịch chuyển";
            description = "Tăng gấp đôi giá trị nhận được khi đi qua cổng dịch chuyển";
            type = true;
        }

        public PowerDoubleTheValueStarting(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerDoubleTheValueStarting());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            playerUse.isDoubleStart = true;
        }
    }
}
