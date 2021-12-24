namespace Monopoly
{
    // thể loại của các ô trên bàn cờ
    public enum CellType { Dat, CoHoi, KhiVan, QuyenNang, BatDau, BaiDoXe, VaoTu, OTu, Thue }

    class Cell
    {
        // xem thử ô đó là loại gì
        private CellType _type;
        public CellType type
        {
            get { return _type; }
            set { _type = value; }
        }

        // nếu là đất thì lưu vị trí của nó trong list dữ liệu đất để xử lý
        private int _index;
        public int index
        {
            get { return _index; }
            set { _index = value; }
        }

        // khởi tạo index = -1
        public Cell()
        {
            _index = -1;
        }

        //contructor vị trí của đất
        public Cell(int index)
        {
            _index = index;
        }

        //contructor đầy đủ đối số
        public Cell(int index, CellType cellType)
        {
            _index = index;
            _type = cellType;
        }
    }
}

