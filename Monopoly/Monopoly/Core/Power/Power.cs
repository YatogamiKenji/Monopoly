namespace Monopoly
{
    public class Power
    {
        // Tên thẻ quyền năng
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        // Giá trị thẻ quyền năng
        private int _value;
        public int value
        {
            get { return _value; }
            set { _value = value; }
        }

        // kiểm tra xem là loại sử dụng lên người khác hay lên chính bản thân
        private bool _type;
        public bool type
        {
            get { return _type; }
            set { _type = value; }
        }

        // kiểm tra xem thử có cần sử dụng đến đất không
        private bool _usingLand;
        public bool usingLand
        {
            get { return _usingLand; }
            set { _usingLand = value; }
        }

        private string _icon;
        public string icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        //mô tả thẻ quyền năng :v
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        // Contructor không tham số
        public Power()
        {
            _name = "";
            _value = 0;
            _description = "";
        }

        // Contructor có tham số
        public Power(string name, int value, string description)
        {
            _name = name;
            _value = value;
            _description = description;
        }

        public virtual bool Using(ref Player playerUse, ref Player affectedPlayers, int dice)
        {
            return false;
        }

        public virtual bool Using(ref Player playerUse, int dice)
        {
            return false;
        }

        public virtual void PowerFunction(ref Player playerUse)
        {

        }

        public virtual void PowerFunction(ref Player playerUse, int index)
        {

        }
    }
}
