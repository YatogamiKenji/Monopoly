namespace Monopoly
{
    // giảm level đất người khác
    class PowerLandLevelReduction : Power
    {
        public PowerLandLevelReduction() : base()
        {
            value = 2500;
            name = "Giảm level";
            description = "Giảm 2 level hành tinh của người khác";
            type = false;
            usingLand = true;
            icon = "/Monopoly;component/Images/Power/PowerLandLevelReduction.jpg";
        }

        public PowerLandLevelReduction(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value && affectedPlayers.lands.Count > 0) 
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.lands[0].LowerLevel();
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            playerUse.lands[index].LowerLevel();
        }
    }
}
