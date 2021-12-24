namespace Monopoly
{
    class ChanceOutPrison: Chance
    {
        public ChanceOutPrison()
        {
            name = "Ra tù";
            description = "Sử dụng thẻ này để ra tù";
            icon = "/Monopoly;component/Images/Card_Icon/Card20.png";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            if (!playerUse.isOutPrison) playerUse.isOutPrisonCard = true;
            else playerUse.money += 1000;
        }
    }
}
