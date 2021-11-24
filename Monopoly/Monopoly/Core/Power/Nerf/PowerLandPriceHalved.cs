using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Giảm 50% giá trị đất trong 2 lượt
    class PowerLandPriceHalved: Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerLandPriceHalved():base()
        {
            value = 700;
            name = "giảm giá trị đất";
            _numberTurns = 2;
        }

        public PowerLandPriceHalved(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
