using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface IQuangCaoBusiness
    {
        QuangCao GetDatabyID(string id);
        List<QuangCao> GetDataAll();
    }
}
