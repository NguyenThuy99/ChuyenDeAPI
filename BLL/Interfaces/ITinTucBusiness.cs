using Model; 
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
   public partial interface  ITinTucBusiness
    {
        bool Create(TinTuc model);
        TinTuc GetDatabyID(string id);
        List<TinTuc> GetDataAll();
        bool Update(TinTuc model);
        bool Delete(int id);
        List<TinTuc> GetTinTheoLoai(int id);
        List<TinTuc> Search(int pageIndex, int pageSize, out long total, string tieude);
    }
}
