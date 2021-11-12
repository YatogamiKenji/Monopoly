using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class CommunityChest
    {
        private int n;
        public void RandomCC(Player p)
        {
            Random rand = new Random();
            n = rand.Next(1, 6);
            switch (n)
            {
                case 1:
                    ToJail(p);
                    break;
                case 2:
                    AddMoney(p);
                    break;
                case 3:
                    SubtractMoney(p);
                    break;
                case 4:
                    ToStart(p);
                    break;
                case 5:
                    MoveBackward(p);
                    break;
                default:
                    //thong bao loi
                    break;
            }
        }
        public void ToJail(Player p)
        {
            //p.position = vi tri nha tu;
            //thong bao
        }
        public void AddMoney(Player p)
        {
            //p.money += x tien;
            //thong bao
        }
        public void SubtractMoney(Player p)
        {
            //p.money -= x tien;
            //thong bao
        }
        public void ToStart(Player p)
        {
            //p.position = vi tri start;
            //thong bao
        }
        public void MoveBackward(Player p)
        {
            //p.position -= x vi tri;
            //thong bao
        }
    }
}
