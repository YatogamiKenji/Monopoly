namespace Monopoly
{
    // ăn cắp đất
    class PowerStealLand : Power
    {
        public PowerStealLand() : base()
        {
            value = 3000;
            name = "Trộm hành tinh";
            description = "Biến một ô đất của ai đó thành của mình";
            type = false;
            usingLand = true;
            icon = "/Monopoly;component/Images/Power/PowerStealLand.png";
        }

        public PowerStealLand(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value && affectedPlayers.lands.Count > 0) 
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            playerUse.RemoveLand(index);
        }
    }
}
