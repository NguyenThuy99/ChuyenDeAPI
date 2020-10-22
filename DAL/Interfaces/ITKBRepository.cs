using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public partial interface ITKBRepository
    {
        bool Update(TKB model);
        bool Delete(int id);
        bool Create(TKB model);
        List<TKB> GetDataAll();
    }
}
