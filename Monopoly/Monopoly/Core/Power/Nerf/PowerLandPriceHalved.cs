namespace Monopoly
{
    //Giảm 50% giá trị đất trong 2 lượt
    class PowerLandPriceHalved : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerLandPriceHalved() : base()
        {
            value = 700;
            name = "Giảm giá trị hành tinh";
            _numberTurns = 2;
            description = "Giảm 50% giá trị hành tinh của một người chơi trong vòng 2 lượt";
            type = false;
            usingLand = true;
            icon = "/Monopoly;component/Images/Power/PowerLandPriceHalved.jpg";
        }

        public PowerLandPriceHalved(int index) : base()
        {
            value = 700;
            name = "Giảm giá trị hành tinh";
            _numberTurns = 2;
            description = "Giảm 50% giá trị hành tinh của một người chơi trong vòng 2 lượt";
            type = false;
            usingLand = true;
            this.index = index;
        }

        int index;

        public PowerLandPriceHalved(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money > dice * value && affectedPlayers.lands.Count > 0) 
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerLandPriceHalved());
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (_numberTurns > 0)
            {
                _numberTurns--;
            }
            if (_numberTurns == 0)
            {
                playerUse.RemovePowerEffect(name);
                playerUse.lands[index].isReduceValue = false;
            }
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            playerUse.lands[index].isReduceValue = true;
            playerUse.AddPowersEffect(new PowerLandPriceHalved(index));
        }
    }
}
