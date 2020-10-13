using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL.Interfaces
{
    public partial interface IChuDeBusiness
    {
        bool Create(ChuDe model);
        ChuDe GetDatabyID(string id);
        List<ChuDe> GetDataAll();

        /*List<ChuDe> GetTinTheoLoai(int id);*/
    }
}
