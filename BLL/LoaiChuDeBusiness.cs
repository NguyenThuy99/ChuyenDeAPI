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
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(LoaiChuDe model)
        {
            return _res.Update(model);
        }
        public bool Create(LoaiChuDe model)
        {
            return _res.Create(model);
        }
        public LoaiChuDe GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
    }
}
