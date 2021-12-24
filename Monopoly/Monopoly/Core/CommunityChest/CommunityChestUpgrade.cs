namespace Monopoly
{
    class CommunityChestUpgrade: CommunityChest
    {
        public CommunityChestUpgrade()
        {
            name = "Nâng cấp tàu";
            description = "Nâng cấp tàu trả 2500";
            icon = "/Monopoly;component/Images/Card_Icon/Card4.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= 2500;
        }
    }
}
