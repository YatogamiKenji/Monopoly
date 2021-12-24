namespace Monopoly
{
    class ChanceFlyTooFast: Chance
    {
        public ChanceFlyTooFast()
        {
            name = "Bay quá tốc độ";
            description = "Bay quá tốc độ bị cảnh sát vũ trụ bắt phạt 1500";
            icon = "/Monopoly;component/Images/Card_Icon/Card31.jpg";
            isChangePosition = false;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.money -= 1500;
        }
    }
}
