using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Monopoly
{
    class CellLand : CellBase
    {
        private int _index;
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }

        public CellLand(int index)
        {
            _index = index;
        }
    }
}
