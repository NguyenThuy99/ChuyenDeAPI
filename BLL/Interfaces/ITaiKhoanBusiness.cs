using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace BLL
{
    public partial interface ITaiKhoanBusiness
    {
        TaiKhoan Authenticate(string username, string password);
        TaiKhoan GetDatabyID(string id);
    }
}
