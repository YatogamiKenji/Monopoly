namespace Monopoly
{
    class CommunityChestBankError: CommunityChest
    {
        public CommunityChestBankError()
        {
            name = "Nhà Bank liên vũ trụ lỗi tiền";
            description = "Nhà Bank liên vũ trụ lỗi tiền thưởng 3000";
            icon = "/Monopoly;component/Images/Card_Icon/Card7.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 3000;
        }
    }
}
