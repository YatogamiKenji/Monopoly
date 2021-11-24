using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //khóa 1 ô đất trong 2 lượt
    class PowerLockAPlotOfLand:Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerLockAPlotOfLand():base()
        {
            value = 500;
            name = "khóa đất";
            _numberTurns = 2;
        }

        public PowerLockAPlotOfLand(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
