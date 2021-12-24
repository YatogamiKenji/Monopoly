namespace Monopoly
{
    class ChancePickUpTreasure: Chance
    {
        public ChancePickUpTreasure()
        {
            name = "Nhặt được kho báu";
            description = "Nhặt được kho báu thưởng 2000";
            icon = "/Monopoly;component/Images/Card_Icon/Card35.png";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 2000;
        }
    }
}
