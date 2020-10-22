
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class LoaiTinBusiness : ILoaiTinBusiness
    {
        private ILoaiTinRepository _res;
        public LoaiTinBusiness(ILoaiTinRepository LoaiTinGroupRes)
        {
            ILoaiTinRepository loaiTinGroupRes = LoaiTinGroupRes;
            _res = loaiTinGroupRes;
        }
        public List<LoaiTin> GetDataAll()
        {
            return _res.GetDataAll();
        }
        public bool Delete(int id)
        {
            return _res.Delete(id);
        }
        public bool Update(LoaiTin model)
        {
            return _res.Update(model);
        }
        public bool Create(LoaiTin model)
        {
            return _res.Create(model);
        }
        public LoaiTin GetDatabyID(string id)
        {
            return _res.GetDatabyID(id);
        }
        /*   public List<LoaiTin> GetData()
           {
               return _res.GetData();
           }*/

        /*  List<LoaiTin> ILoaiTinBusiness.GetData()
          {
              throw new NotImplementedException();
          }*/
    }
}
