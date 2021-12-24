namespace Monopoly
{
    // giữ chân 1 người trong 5 lượt
    class PowerHoldAPerson : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerHoldAPerson() : base()
        {
            value = 1500;
            name = "Giữ chân";
            _numberTurns = 5;
            description = "Giữ chân 1 người tại vị trí cũ trong vòng 5 lượt";
            type = false;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerHoldAPerson.jpg";
        }

        public PowerHoldAPerson(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 5;
        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerHoldAPerson());
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (_numberTurns > 0)
            {
                _numberTurns--;
                playerUse.isRetention = true;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
