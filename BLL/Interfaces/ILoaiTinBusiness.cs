using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ILoaiTinBusiness
    {
        bool Create(LoaiTin model);
        public List<LoaiTin> GetDataAll();
        bool Update(LoaiTin model);
        bool Delete(int id);
        LoaiTin GetDatabyID(string id);
    }
}
