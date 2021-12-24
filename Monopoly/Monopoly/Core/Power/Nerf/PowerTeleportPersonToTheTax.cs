using System;

namespace Monopoly
{
    //dịch chuyển một người đến ô thuế
    class PowerTeleportPersonToTheTax : Power
    {
        public PowerTeleportPersonToTheTax() : base()
        {
            value = 700;
            name = "Ép buộc";
            description = "Dịch chuyển một người chơi đến ô thuế và trả thuế gấp đôi";
            type = false;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerTeleportPersonToTheTax.jpg";
        }

        public PowerTeleportPersonToTheTax(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.money = Convert.ToInt32(Math.Ceiling(0.8 * affectedPlayers.money));
                affectedPlayers.position = 3;
                return true;
            }
            return false;
        }
    }
}
