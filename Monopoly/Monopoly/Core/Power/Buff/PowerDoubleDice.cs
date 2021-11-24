using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // nhân đôi xúc sắc
    class PowerDoubleDice: Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerDoubleDice():base()
        {
            value = 900;
            name = "Nhân đôi bước nhảy";
            _numberTurns = 7;
        }

        public PowerDoubleDice(string name, int value, string description) : base(name, value, description)
        {
            numberTurns = 7;
        }

        public override void powerFunction(Player playerUse, int dice)
        {
            
        }
    }
}
