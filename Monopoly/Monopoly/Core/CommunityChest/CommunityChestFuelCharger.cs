namespace Monopoly
{
    class CommunityChestFuelCharger: CommunityChest
    {
        public CommunityChestFuelCharger()
        {
            name = "Sạc nhiên liệu";
            description = "Sạc nhiên liệu trả 500";
            icon = "/Monopoly;component/Images/Card_Icon/Card33.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= 500;
        }
    }
}
