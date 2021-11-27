﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    //hủy bỏ 1 thẻ quyền năng của người khác
    class PowerCancelPowerCard : Power
    {
        public PowerCancelPowerCard() : base()
        {
            value = 2000;
            name = "Hủy bỏ quyền năng";
            description = "Hủy bỏ 1 quyền năng trên tay người khác";
            type = false;
        }

        public PowerCancelPowerCard(string name, int value, string description) : base(name, value, description)
        {

        }

        public override bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            if (playerUse.money > dice * value)
            {
                playerUse.RemovePower(name);
                playerUse.money -= dice * value;
                affectedPlayers.RemovePower("Tên thẻ cần hủy");
                return true;
            }
            return false;
        }
    }
}
