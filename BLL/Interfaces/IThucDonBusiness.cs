using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL.Interfaces
{
    public partial interface IThucDonBusiness
    {
        bool Update(ThucDon model);
        bool Delete(int id);
        bool Create(ThucDon model);
        List<ThucDon> GetDataAll();
    }
}
