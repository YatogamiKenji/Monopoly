using System;

namespace Monopoly
{
    //hủy bỏ 1 thẻ quyền năng của người khác
    class PowerCancelPowerCard : Power
    {
        public PowerCancelPowerCard() : base()
        {
            value = 2000;
            name = "Hủy bỏ quyền năng";
            description = "Hủy bỏ 1 quyền năng trên tay người khác";
            type = false;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerCancelPowerCard.jpg";
        }

        public PowerCancelPowerCard(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value && affectedPlayers.powers.Count > 0) 
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                Random random = new Random();
                affectedPlayers.RemovePower(affectedPlayers.powers[random.Next(0, affectedPlayers.powers.Count)].name);
                return true;
            }
            return false;
        }
    }
}
