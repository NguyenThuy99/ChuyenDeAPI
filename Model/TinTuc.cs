using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class TinTuc
    {
        public int id { get; set; }
        public int idloai { get; set; }
        public string tieude { get; set; }
        public string hinhanh { get; set; }
        public string mota { get; set; }
        public string noidung { get; set; }
        public DateTime? ngaydang { get; set; }
    }
}
