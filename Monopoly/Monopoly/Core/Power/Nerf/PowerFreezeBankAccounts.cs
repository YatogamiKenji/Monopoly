using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //đóng băng tài khoản ngân hàng
    class PowerFreezeBankAccounts:Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerFreezeBankAccounts():base()
        {
            value = 1000;
            name = "đóng băng tài khoản";
            _numberTurns = 2;
        }

        public PowerFreezeBankAccounts(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override void powerFunction(Player playerUse, Player affectedPlayers, int dice)
        {

        }
    }
}
