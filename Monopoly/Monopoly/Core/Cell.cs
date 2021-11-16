using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public enum CellType { Dat, CoHoi, KhiVan, QuyenNang, BatDau, BaiDoXe, VaoTu, OTu, Thue }
    class Cell
    {
        private CellType _type;
        public CellType type
        {
            get { return _type; }
            set { _type = value; }
        }

        private int _index;
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }

        public Cell()
        {
            _index = -1;
        }

        public Cell(int index)
        {
            _index = index;
        }

        public Cell(int index, CellType cellType)
        {
            _index = index;
            _type = cellType;
        }
    }
}

