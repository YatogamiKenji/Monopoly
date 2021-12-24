namespace Monopoly
{
    class ChanceGoToDevil: Chance
    {
        public ChanceGoToDevil()
        {
            name = "Dịch chuyển đến Devil";
            description = "Gặp WormHole dịch chuyển đến Devil";
            icon = "/Monopoly;component/Images/Card_Icon/Card32.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position = 26;
        }
    }
}
