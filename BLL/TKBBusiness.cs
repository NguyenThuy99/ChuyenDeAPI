using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BLL
{
    public partial class TKBBusiness : ITKBBusiness
    {
        private ITKBRepository _res;
        public TKBBusiness(ITKBRepository TinTucGroupRes)
        {
            _res = TinTucGroupRes;
        }
        public List<TKB> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(TKB model)
        {
            return _res.Update(model);
        }
        public bool Create(TKB model)
        {
            return _res.Create(model);
        }
        public TKB GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
