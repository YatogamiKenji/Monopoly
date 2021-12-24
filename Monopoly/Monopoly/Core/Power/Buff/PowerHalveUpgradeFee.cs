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
            usingLand = true;
            icon = "/Monopoly;component/Images/Power/PowerHalveUpgradeFee.jpg";
        }

        public PowerHalveUpgradeFee(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value && playerUse.lands.Count > 0) 
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            if (playerUse.money >= playerUse.lands[index].Upgrade(playerUse.lands[index].level + 1) / 2)
            {
                playerUse.money -= playerUse.lands[index].Upgrade() / 2;
            }    
        }
    }
}
