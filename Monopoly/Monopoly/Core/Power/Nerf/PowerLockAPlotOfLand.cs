using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //khóa 1 ô đất trong 2 lượt
    class PowerLockAPlotOfLand : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerLockAPlotOfLand() : base()
        {
            value = 500;
            name = "Khóa hành tinh";
            _numberTurns = 2;
            description = "Khóa 1 hành tinh của một người chơi trong vòng 2 lượt";
            type = false;
            usingLand = false;
        }

        public PowerLockAPlotOfLand(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money > dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerLockAPlotOfLand());
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            if (_numberTurns > 0)
            {
                _numberTurns--;
            }
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
