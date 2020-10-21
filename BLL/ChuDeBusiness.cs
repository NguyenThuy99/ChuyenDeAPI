using BLL.Interfaces;
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace BLL
{
    public class ChuDeBusiness : IChuDeBusiness
    {
        private IChuDeRepository _res;
        public ChuDeBusiness(IChuDeRepository TinTucGroupRes)
        {
            _res = TinTucGroupRes;
        }
        public bool Create(ChuDe model)
        {
            return _res.Create(model);
        }
        public ChuDe GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public List<ChuDe> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(ChuDe model)
        {
            return _res.Update(model);
        }
        /*
                public List<ChuDe> GetTinTheoLoai(int id)
                {
                    return _res.GetTinTheoLoai(id);
                }*/
    }
}
