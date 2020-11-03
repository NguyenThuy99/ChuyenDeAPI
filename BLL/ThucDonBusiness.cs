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
    public partial class ThucDonBusiness : IThucDonBusiness
    {
        private IThucDonRepository _res;
        public ThucDonBusiness(IThucDonRepository TinTucGroupRes)
        {
            _res = TinTucGroupRes;
        }
        public List<ThucDon> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public ThucDon GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(ThucDon model)
        {
            return _res.Update(model);
        }
        public bool Create(ThucDon model)
        {
            return _res.Create(model);
        }
    }
}
