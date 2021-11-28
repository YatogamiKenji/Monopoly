using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //dịch chuyển đến 1 ô bất kỳ
    class PowerMoveToAnyCell : Power
    {
        public PowerMoveToAnyCell() : base()
        {
            value = 1000;
            name = "Dịch chuyển";
            description = "Dịch chuyển đến một ô được người chơi chỉ định trên bàn cờ";
            type = true;
        }

        public PowerMoveToAnyCell(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerMoveToAnyCell());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }
    }
}
