using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL
{
    public partial interface ILoaiChuDeRepository
    {
        bool Update(LoaiChuDe model);
        bool Delete(int id);
        bool Create(LoaiChuDe model);
        List<LoaiChuDe> GetDataAll();
        LoaiChuDe GetDatabyID(string id);
    }
}
