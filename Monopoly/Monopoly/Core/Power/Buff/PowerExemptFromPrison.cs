namespace Monopoly
{
    //miễn vào tù 10 lượt
    class PowerExemptFromPrison : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerExemptFromPrison() : base()
        {
            value = 600;
            name = "Miễn vào tù";
            _numberTurns = 10;
            description = "Miễn vào tù trong vòng 10 lượt";
            type = true;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerExemptFromPrison.png";
        }

        public PowerExemptFromPrison(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 10;
        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerExemptFromPrison());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (numberTurns > 0)
            {
                _numberTurns--;
                playerUse.isOutPrison = true;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
