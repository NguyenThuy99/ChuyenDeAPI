using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public partial interface IThucDonRepository
    {
        bool Update(ThucDon model);
        bool Delete(int id);
        bool Create(ThucDon model);
        List<ThucDon> GetDataAll();
    }
}
