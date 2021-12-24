namespace Monopoly
{
    //đóng băng tài khoản ngân hàng
    class PowerFreezeBankAccounts : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerFreezeBankAccounts() : base()
        {
            value = 1000;
            name = "Đóng băng tài khoản";
            _numberTurns = 2;
            description = "Đóng băng tài khoản của người khác trong vòng 2 lượt";
            type = false;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerFreezeBankAccounts.png";
        }

        public PowerFreezeBankAccounts(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerFreezeBankAccounts());
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (_numberTurns > 0)
            {
                playerUse.isFreezeBank = true;
                _numberTurns--;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
