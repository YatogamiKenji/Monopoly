namespace Monopoly
{
    class CommunityChestWedding: CommunityChest
    {
        public CommunityChestWedding()
        {
            name = "Tổ chức đám cưới";
            description = "Tổ chức đám cưới, mỗi người trả tiền mừng -500";
            icon = "/Monopoly;component/Images/Card_Icon/Card15.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            
        }
    }
}
