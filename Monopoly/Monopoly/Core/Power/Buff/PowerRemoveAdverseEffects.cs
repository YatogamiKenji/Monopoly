namespace Monopoly
{
    //loại bỏ hiệu ứng bất lợi trong X lượt
    class PowerRemoveAdverseEffects : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerRemoveAdverseEffects() : base()
        {
            value = 2500;
            name = "Miễn nhiễm";
            _numberTurns = 5;
            description = "Miễn nhiễm với bất kỳ hiệu ứng bất lợi nào trong vòng 5 lượt";
            type = true;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerRemoveAdverseEffects.jpg";
        }

        public PowerRemoveAdverseEffects(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 5;
        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.AddPowersEffect(new PowerRemoveAdverseEffects());
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
                playerUse.isImmune = true;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
