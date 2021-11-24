using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //miễn vào tù 10 lượt
    class PowerExemptFromPrison:Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerExemptFromPrison():base()
        {
            value = 600;
            name = "Miễn vào tù";
            _numberTurns = 10;
        }

        public PowerExemptFromPrison(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 10;
        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
