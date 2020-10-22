using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IQuangCaoBusiness
    {
        bool Create(QuangCao model);
        bool Update(QuangCao model);
        bool Delete(int id);
        QuangCao GetDatabyID(string id);
        List<QuangCao> GetDataAll();
        List<QuangCao> GetQuangCaoTheoLoai(int id);
    }
}
