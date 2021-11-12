using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class CellBase
    {
        private string _name;

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        virtual public void Chuc_nang()
        {
            
        }

        public CellBase()
        {
            _name = "";
        }

        public CellBase(string name)
        {
            _name = name;
        }
    }
}
