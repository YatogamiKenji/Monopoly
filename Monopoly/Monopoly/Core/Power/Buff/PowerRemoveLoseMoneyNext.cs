using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    // Loại bỏ lần mất tiền tiếp theo
    class PowerRemoveLoseMoneyNext: Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerRemoveLoseMoneyNext():base()
        {
            value = 700;
            name = "Không mất tiền";
            _numberTurns = 1;
        }

        public PowerRemoveLoseMoneyNext(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 1;
        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
