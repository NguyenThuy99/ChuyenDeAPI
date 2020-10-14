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
    }
}
