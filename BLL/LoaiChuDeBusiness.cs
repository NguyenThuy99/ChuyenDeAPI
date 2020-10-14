using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class LoaiChuDeBusiness : ILoaiChuDeBusiness
    {
        private ILoaiChuDeRepository _res;
        public LoaiChuDeBusiness(ILoaiChuDeRepository LoaiChuDeGroupRes)
        {
            ILoaiChuDeRepository loaiTinGroupRes = LoaiChuDeGroupRes;
            _res = loaiTinGroupRes;
        }
        public List<LoaiChuDe> GetDataAll()
        {
            return _res.GetDataAll();
        }
    }
}
