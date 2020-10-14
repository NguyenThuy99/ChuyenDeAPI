using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;


namespace BLL
{
    public partial class LoaiQuangCaoBusiness : ILoaiQuangCaoBusiness
    {
        private ILoaiQuangCaoRepository _res;
        public LoaiQuangCaoBusiness(ILoaiQuangCaoRepository LoaiQuangCaoGroupRes)
        {
            ILoaiQuangCaoRepository loaiTinGroupRes = LoaiQuangCaoGroupRes;
            _res = loaiTinGroupRes;
        }
        public List<LoaiQuangCao> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
