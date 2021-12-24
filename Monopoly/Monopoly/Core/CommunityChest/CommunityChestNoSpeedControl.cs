namespace Monopoly
{
    class CommunityChestNoSpeedControl: CommunityChest
    {
        public CommunityChestNoSpeedControl()
        {
            name = "Không kiểm soát tốc độ";
            description = "Không kiểm soát tốc độ Tiến 3 bước";
            icon = "/Monopoly;component/Images/Card_Icon/Card31.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position += 3;
        }
    }
}
