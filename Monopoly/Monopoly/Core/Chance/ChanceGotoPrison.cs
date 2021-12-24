namespace Monopoly
{
    class ChanceGotoPrison: Chance
    {
        public ChanceGotoPrison()
        {
            name = "Vào tù";
            description = "Vào tù";
            icon = "/Monopoly;component/Images/Card_Icon/Card18.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position = 10;
            playerUse.isInPrison = true;
        }
    }
}
