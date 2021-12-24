namespace Monopoly
{
    class PowerTeleport: Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerTeleport():base()
        {
            value = 900;
            name = "Di chuyển";
            description = "Dịch chuyển đến 1 ô bất kỳ trong phạm vi xúc sắc đổ được";
            type = true;
            usingLand = false;
            _numberTurns = 5;
            icon = "/Monopoly;component/Images/Power/PowerMoveToAnyCell.jpg";
        }

        public PowerTeleport(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 5;
        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerTeleport());
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
                playerUse.isTeleport = true;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
