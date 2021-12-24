namespace Monopoly
{
    // Chỉ định 1 người vào tù
    class PowerAppointPersonToPrison : Power
    {
        public PowerAppointPersonToPrison() : base()
        {
            value = 1000;
            name = "Vào tù";
            description = "Chỉ định 1 người chơi bất kỳ vào tù";
            type = false;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerAppointPersonToPrison.jpg";
        }

        public PowerAppointPersonToPrison(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;

                if (!affectedPlayers.isOutPrison)
                {
                    affectedPlayers.position = 10;
                    affectedPlayers.isInPrison = true;
                }
                return true;
            }
            return false;
        }
    }
}
