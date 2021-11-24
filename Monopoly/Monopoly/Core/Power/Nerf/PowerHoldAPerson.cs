using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // giữ chân 1 người trong 5 lượt
    class PowerHoldAPerson:Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerHoldAPerson():base()
        {
            value = 1500;
            name = "giữ chân";
            _numberTurns = 5;
        }

        public PowerHoldAPerson(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 5;
        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
