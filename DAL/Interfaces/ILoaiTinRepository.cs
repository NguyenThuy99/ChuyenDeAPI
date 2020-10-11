using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ILoaiTinRepository
    {
      /*  bool Create(TinTuc model);*/
       /* TinTuc GetDatabyID(string id);*/
        List<LoaiTin> GetDataAll();
       /* List<LoaiTin> GetData();*/
    }
}
