using System;
using Model;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ILoaiTinRepository
    {
        bool Create(LoaiTin model);
        /*LoaiTin GetDatabyID(string id);
        List<TinTuc> GetDataAll();*/
    }
}
