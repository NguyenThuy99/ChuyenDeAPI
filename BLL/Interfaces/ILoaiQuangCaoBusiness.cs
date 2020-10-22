using System;
using System.Collections.Generic;
using System.Text;
using Model;
namespace BLL
{
    public partial interface ILoaiQuangCaoBusiness
    {
        bool Create(LoaiQuangCao model);
        bool Update(LoaiQuangCao model);
        bool Delete(int id);
        public List<LoaiQuangCao> GetDataAll();
    }
}
