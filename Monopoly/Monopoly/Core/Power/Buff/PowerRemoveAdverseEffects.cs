﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //loại bỏ hiệu ứng bất lợi trong X lượt
    class PowerRemoveAdverseEffects: Power
    {
        // Số lượt có tác dụng của quyền năng
        private int _numberTurns;
        public int numberTurns
        {
            get { return _numberTurns; }
            set { _numberTurns = value; }
        }

        public PowerRemoveAdverseEffects():base()
        {
            value = 2500;
            name = "Miễn nhiễm";
            _numberTurns = 5;
        }

        public PowerRemoveAdverseEffects(string name, int value, string description) : base(name, value, description)
        {
            _numberTurns = 5;
        }

        public override void powerFunction(Player playerUse, int dice)
        {

        }
    }
}
