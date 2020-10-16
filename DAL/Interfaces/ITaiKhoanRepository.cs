using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface ITaiKhoanRepository
    {
        TaiKhoan GetUser(string username, string password);
        TaiKhoan GetDatabyID(string id);
    }
}
