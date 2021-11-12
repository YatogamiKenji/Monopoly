using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    class Chance
    {
        private int n;
        public void RandomChance(Player p, List<Player> players)
        {
            //co the dung if(chance)
            Random rand = new Random();
            n = rand.Next(1, 6);
            switch (n)
            {
                case 1:
                    MoveTo(p);
                    break;
                case 2:
                    AddMoney(p, players);
                    break;
                case 3:
                    SubtractMoney(p, players);
                    break;
                case 4:
                    OutOfJail(p);
                    break;
                case 5:
                    MoveBackward(p);
                    break;
                default:
                    //thong bao loi
                    break;
            }
        }
        public void MoveTo(Player p)
        {
            //p.position = vi tri;
        }
        public void AddMoney(Player p, List<Player> players)
        {
            //p.money += x tien;
            //thong bao
        }
        public void SubtractMoney(Player p, List<Player> players)
        {
            //p.money -= x tien;
            //thong bao
        }
        public void OutOfJail(Player p)
        {
            p.outPrison = true;
            //thong bao
        }
        public void MoveBackward(Player p)
        {
            //p.position -= x vi tri;
            //thong bao
        }

    }
}
