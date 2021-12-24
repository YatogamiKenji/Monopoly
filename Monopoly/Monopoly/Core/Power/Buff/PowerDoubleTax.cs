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
            icon = "/Monopoly;component/Images/Power/PowerDoubleTax.png";
        }

        public PowerDoubleTax(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value && playerUse.lands.Count > 0) 
            {
                playerUse.AddPowersEffect(new PowerDoubleTax());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            playerUse.lands[index].isDoubleTax = true;
        }
    }
}
