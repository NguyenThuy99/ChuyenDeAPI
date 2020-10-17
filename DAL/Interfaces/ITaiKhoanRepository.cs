using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface ITaiKhoanRepository
    {
        TaiKhoan GetUser(string usename, string password);
        TaiKhoan GetDatabyID(string id);
        bool Create(TaiKhoan model);
        bool Update(TaiKhoan model);
        bool Delete(string id);
    }
}
