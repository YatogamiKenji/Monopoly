namespace Monopoly
{
    // nhân đôi xúc sắc
    class PowerDoubleDice : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerDoubleDice() : base()
        {
            value = 900;
            name = "Nhân đôi bước nhảy";
            _numberTurns = 3;
            description = "Nhân đôi xúc xắc trong vòng 7 lượt";
            type = true;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerDoubleDice.jpg";
        }

        public PowerDoubleDice(string name, int value, string description) : base(name, value, description)
        {
            numberTurns = 3;
        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerDoubleDice());
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (_numberTurns > 0)
            {
                _numberTurns--;
                playerUse.isDoubleDice = true;
            }
            if (_numberTurns == 0) playerUse.RemovePower(name);
        }
    }
}
