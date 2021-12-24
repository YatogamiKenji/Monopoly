namespace Monopoly
{
    class CommunityChestWinTheRace: CommunityChest
    {
        public CommunityChestWinTheRace()
        {
            name = "Thắng giải đua tàu vũ trụ";
            description = "Thắng giải đua tàu vũ trụ thưởng 2000";
            icon = "/Monopoly;component/Images/Card_Icon/Card34.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money += 2000;
        }
    }
}
