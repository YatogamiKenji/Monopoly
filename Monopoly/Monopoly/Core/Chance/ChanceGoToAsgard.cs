namespace Monopoly
{
    class ChanceGoToAsgard: Chance
    {
        public ChanceGoToAsgard()
        {
            name = "Dịch chuyển đến Asgard";
            description = "Gặp Cổng dịch chuyển mini dịch chuyển đến Asgard";
            icon = "/Monopoly;component/Images/Card_Icon/Card32.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position = 15;
        }
    }
}
