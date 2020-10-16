using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
   public class TaiKhoan
    {
        public string id { get; set; }
        public string usename { get; set; }
        public string passwword { get; set; }
        public string role { get; set; }
        public string hoten { get; set; }
        public DateTime ngaysinh { get; set; }
        public string diachi { get; set; }
        public string email { get; set; }
        public string token { get; set; }
    }
}
