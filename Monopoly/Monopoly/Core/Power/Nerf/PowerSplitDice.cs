namespace Monopoly
{
    // chia đôi xúc sắc
    class PowerSplitDice : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerSplitDice() : base()
        {
            value = 500;
            name = "Chia đôi";
            _numberTurns = 7;
            description = "Chia đôi xúc xắc của một người chơi trong vòng 7 lượt";
            type = false;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerSplitDice.jpg";
        }

        public PowerSplitDice(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 7;
        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerSplitDice());
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (_numberTurns > 0)
            {
                playerUse.isSplitDice = true;
                _numberTurns--;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
