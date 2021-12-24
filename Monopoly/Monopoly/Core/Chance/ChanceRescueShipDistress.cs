namespace Monopoly
{
    class ChanceRescueShipDistress: Chance
    {
        public ChanceRescueShipDistress()
        {
            name = "Cứu tàu bị nạn";
            description = "Cứu tàu bị nạn thưởng 1000";
            icon = "/Monopoly;component/Images/Card_Icon/Card9.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 1000;
        }
    }
}
