using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TinTucBusiness : ITinTucBusiness
    {
        private ITinTucRepository _res;
        public TinTucBusiness(ITinTucRepository TinTucGroupRes)
        {
            _res = TinTucGroupRes;
        }
        public bool Create(TinTuc model)
        {
            return _res.Create(model);
        }
        public TinTuc GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<TinTuc> GetDataAll()
        {
            return _res.GetDataAll();
        }

        public   List<TinTuc> GetTinTheoLoai(int id)
        {
            return _res.GetTinTheoLoai(id);
        }
        /* public List<TinTuc> Search(int pageIndex, int pageSize, out long total, string item_group_id)
         {
             return _res.Search(pageIndex, pageSize, out total, item_group_id);
         }*/
    }

}
