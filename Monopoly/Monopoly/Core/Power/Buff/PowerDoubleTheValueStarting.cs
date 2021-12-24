namespace Monopoly
{
    // Tăng gấp đôi giá trị khi đi qua ô bắt đầu
    class PowerDoubleTheValueStarting : Power
    {
        public PowerDoubleTheValueStarting() : base()
        {
            value = 500;
            name = "Gấp đôi giá trị Cổng dịch chuyển";
            description = "Tăng gấp đôi giá trị nhận được khi đi qua cổng dịch chuyển";
            type = true;
            usingLand = false;
            icon = "/Monopoly;component/Images/Power/PowerDoubleTheValueStarting.jpg";
        }

        public PowerDoubleTheValueStarting(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, int dice)
        {
            if (playerUse.money >= dice * value)
            {
                playerUse.isDoubleStart = true;
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                return true;
            }
            return false;
        }
    }
}
