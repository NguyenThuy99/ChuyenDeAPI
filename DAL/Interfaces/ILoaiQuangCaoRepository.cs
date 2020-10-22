using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public partial interface ILoaiQuangCaoRepository
    {
        bool Update(LoaiQuangCao model);
        bool Delete(int id);
        bool Create(LoaiQuangCao model);
        List<LoaiQuangCao> GetDataAll();
    }
}
