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

        int index;

        public PowerLockAPlotOfLand() : base()
        {
            value = 500;
            name = "Khóa hành tinh";
            _numberTurns = 2;
            description = "Khóa 1 hành tinh của một người chơi trong vòng 2 lượt";
            type = false;
            usingLand = false;
        }

        public PowerLockAPlotOfLand(int index) : base()
        {
            value = 500;
            name = "Khóa hành tinh";
            _numberTurns = 2;
            description = "Khóa 1 hành tinh của một người chơi trong vòng 2 lượt";
            type = false;
            usingLand = false;
            this.index = index;
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
            if (_numberTurns == 0)
            {
                playerUse.RemovePowerEffect(name);
                for (int i = 0; i < playerUse.lands.Count; i++)
                    if (playerUse.indexLands[i] == index)
                    {
                        playerUse.lands[i].isLock = false;
                        break;
                    }
            }
        }

        public override void PowerFunction(ref Player playerUse, int index)
        {
            for (int i = 0; i < playerUse.lands.Count; i++)
                if (playerUse.indexLands[i] == index)
                {
                    playerUse.lands[i].isLock = true;
                    playerUse.AddPowersEffect(new PowerLockAPlotOfLand(index));
                    break;
                }
        }
    }
}
