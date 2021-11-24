using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // chia đôi xúc sắc
    class PowerSplitDice: Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerSplitDice():base()
        {
            value = 500;
            name = "Chia đôi";
            _numberTurns = 7;
        }

        public PowerSplitDice(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 7;
        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
