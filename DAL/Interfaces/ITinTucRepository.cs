﻿using Microsoft.TeamFoundation.SourceControl.WebApi;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Interfaces
{
    public partial interface ITinTucRepository
    {
        bool Create(TinTuc model);
        TinTuc GetDatabyID(string id);
        List<TinTuc> GetDataAll();
        bool Update(TinTuc model);
        bool Delete(int id);
        List<TinTuc> GetTinTheoLoai(int idloai);
        List<TinTuc> Search(int pageIndex, int pageSize, out long total, string tieude);
    }
}
