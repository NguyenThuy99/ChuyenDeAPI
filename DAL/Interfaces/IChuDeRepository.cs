﻿using System;
using System.Collections.Generic;
using System.Text;
using Model;

namespace DAL.Interfaces
{
    public interface IChuDeRepository
    {
        bool Update(ChuDe model);
        bool Delete(int id);
        bool Create(ChuDe model);
        ChuDe GetDatabyID(string id);
        public List<ChuDe> GetDataAll();
        List<ChuDe> GetTinTheoLoai(int idcd);
        /*   List<ChuDe> GetTinTheoLoai(int idloai);*/
    }
}
