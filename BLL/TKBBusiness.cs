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
    }
}
