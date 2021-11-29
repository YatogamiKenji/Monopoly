using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Tăng gấp đôi giá trị thuế
    class PowerDoubleTax : Power
    {
        public PowerDoubleTax() : base()
        {
            value = 1500;
            name = "Tăng giá trị thuế";
            description = "Tăng gấp đôi giá trị thuế của một hành tinh";
            type = true;
            usingLand = true;
        }

        public PowerDoubleTax(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerDoubleTax());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            //vị trí của mảnh đất
            //int index = 0;
            // chọn mảnh đất
            //playerUse.lands[index].isDoubleTax = true;
        }
    }
}
