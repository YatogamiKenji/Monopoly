namespace Monopoly
{
    class ChanceGoToValoran: Chance
    {
        public ChanceGoToValoran()
        {
            name = "Dịch chuyển đến Valoran";
            description = "Gặp WormHole dịch chuyển đến Valoran";
            icon = "/Monopoly;component/Images/Card_Icon/Card32.jpg";
            isChangePosition = true;
        }

        public override void Using(ref Player playerUse)
        {
            playerUse.position = 34;
        }
    }
}
