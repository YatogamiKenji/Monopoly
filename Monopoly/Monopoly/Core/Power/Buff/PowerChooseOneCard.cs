using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //chọn 1 thẻ khí vận or cơ hội
    class PowerChooseOneCard : Power
    {
        public PowerChooseOneCard() : base()
        {
            value = 500;
            name = "Chọn 1 thẻ";
            description = "Chọn 1 thẻ cơ hội hoặc khí vận";
        }

        public PowerChooseOneCard(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerChooseOneCard());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
            }
            return false;
        }
    }
}
