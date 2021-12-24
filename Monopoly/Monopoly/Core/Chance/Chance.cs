namespace Monopoly
{
    public class Chance
    {
        // Tên thẻ cơ hội
        private string _name;
        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        //Hình ảnh thẻ cơ hội
        private string _icon;
        public string icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

        //mô tả thẻ cơ hội :v
        private string _description;
        public string description
        {
            get { return _description; }
            set { _description = value; }
        }

        //kiểm tra xe thử thẻ cơ hội có thay đổi vị trí của người chơi không
        private bool _isChangePosition;
        public bool isChangePosition
        {
            get { return _isChangePosition; }
            set { _isChangePosition = value; }
        }

        // Contructor không tham số
        public Chance()
        {
            _name = "";
            _description = "";
            _isChangePosition = false;
        }

        // Contructor có tham số
        public Chance(string name, int value, string description)
        {
            _name = name;
            _description = description;
            _isChangePosition = false;
        }

        public virtual void Using(ref Player playerUse)
        {
            
        }
    }
}
