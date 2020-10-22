using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ILoaiChuDeBusiness
    {
        bool Create(LoaiChuDe model);
        bool Update(LoaiChuDe model);
        bool Delete(int id);
        public List<LoaiChuDe> GetDataAll();
        LoaiChuDe GetDatabyID(string id);
    }
}
