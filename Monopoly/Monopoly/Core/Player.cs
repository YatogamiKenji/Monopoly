using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monopoly
{
    public class Player
    {
        // Tên người chơi
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        //link avt player
        private string _avatar;
        public string avatar
        {
            get { return _avatar; }
            set { _avatar = avatar; }
        }

        // Tiền người chơi có
        private int _money;
        public int money
        {
            get { return _money; }
            set { _money = value; }
        }

        // Vị trí hiện tại của nhân vật trên map
        private int _position;
        public int position
        {
            get { return _position; }
            set { _position = value; }
        }

        // Kiểm tra thử xem người chơi có vé ra tù không
        private bool _outPrison;
        public bool outPrison
        {
            get { return _outPrison; }
            set { _outPrison = value; }
        }

        // Danh sách quyền năng người chơi sở hữu
        private List<Power> _powers;

        // Danh sách đất người chơi đang sở hữu
        private List<Land> _lands;
        public List<Land> lands
        {
            get { return _lands; }
            set { _lands = value; }
        }

        // Danh sách quyền năng đang còn tác dụng trên người chơi
        private List<Power> _powersEffect;

        //Contructor không tham số
        public Player()
        {
            _name = "";
            _money = 10000;
            _position = 0;
            _outPrison = false;
            _powers = new List<Power>();
            _powersEffect = new List<Power>();
        }

        //Contructor có đối số
        public Player(string name, int money, byte posititon, bool outPrison)
        {
            _name = name;
            _money = money;
            _position = posititon;
            _outPrison = outPrison;
        }

        // Thêm đất vào khi mua
        public void AddLand(Land land)
        {
            _lands.Add(land);
        }

        // Xóa bỏ mảnh đất sau khi bán
        public void RemoveLand(string name)
        {
            for (int i=0; i<_lands.Count;i++)
                if (_lands[i].name == name)
                {
                    _lands.RemoveAt(i);
                    break;
                }    
        }

        // Thêm các quyền năng đang sở hữu
        public void AddPower(Power power)
        {
            _powers.Add(power);
        }

        // Xóa bỏ quyền năng sau khi sử dụng
        public void RemovePower(string name)
        {
            for (int i = 0; i < _powers.Count; i++)
                if (_powers[i].name == name)
                {
                    _powers.RemoveAt(i);
                    break;
                }
        }

        // Các quyền năng đang được sử dụng trên người (Cả tốt lẫn xấu)
        public void AddPowersEffect(Power power)
        {
            _powers.Add(power);
        }

        // Tự động loại bỏ các hiệu ứng khi qua từng lượt
        public void RemovePowersEffect()
        {
            //tự động tính toán hiệu lực của các quyền năng
        }
    }
}
