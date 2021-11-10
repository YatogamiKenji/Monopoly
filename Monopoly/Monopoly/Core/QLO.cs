using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class QLO
    {
        private enum Loai { Dat, CoHoi, KhiVan, QuyenNang, BatDau, BaiDoXe, VaoTu, RaTu}
        CellBase[] QuanLy;
        QLO()
        {
            for(int i =0; i<40; i++)
            {
                if (i == 0)
                    QuanLy[i] = new CellLand();
            }
        }
    }
}
