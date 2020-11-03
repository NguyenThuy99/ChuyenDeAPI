using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ITKBBusiness
    {
        bool Update(TKB model);
        bool Delete(int id);
        bool Create(TKB model);
        List<TKB> GetDataAll();
        TKB GetDatabyID(string id);
    }
}
