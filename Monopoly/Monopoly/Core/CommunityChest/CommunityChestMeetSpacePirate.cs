namespace Monopoly
{
    class CommunityChestMeetSpacePirate: CommunityChest
    {
        public CommunityChestMeetSpacePirate()
        {
            name = "Gặp Space Pirate";
            description = "Gặp Space Pirate bị cướp 1500";
            icon = "/Monopoly;component/Images/Card_Icon/Card24.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= 1500;
        }
    }
}
