﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //Giảm 50% giá trị đất trong 2 lượt
    class PowerLandPriceHalved : Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerLandPriceHalved() : base()
        {
            value = 700;
            name = "Giảm giá trị hành tinh";
            _numberTurns = 2;
            description = "Giảm 50% giá trị hành tinh của một người chơi trong vòng 2 lượt";
        }

        public PowerLandPriceHalved(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 2;
        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money > dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.AddPowersEffect(new PowerLandPriceHalved());
                return true;
            }
            return false;
        }

        public override void PowerFunction(ref Player playerUse)
        {
            _numberTurns--;
            if (_numberTurns == 0) playerUse.RemovePowerEffect(name);
        }
    }
}
