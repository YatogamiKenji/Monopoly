namespace Monopoly
{
    // tăng giá trị đất gấp đôi vĩnh viễn
    class PowerDoublePriceLandForever : Power
    {
        public PowerDoublePriceLandForever() : base()
        {
            value = 3000;
            name = "Tăng giá trị hành tinh";
            description = "Tăng gấp đôi giá trị hành tinh";
            type = true;
            usingLand = true;
            icon = "/Monopoly;component/Images/Power/PowerDoublePriceLandForever.png";
        }

        public PowerDoublePriceLandForever(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value && playerUse.lands.Count > 0) 
            {
                playerUse.AddPowersEffect(new PowerDoublePriceLandForever());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            playerUse.lands[index].isDoublePrice = true;
        }
    }
}
