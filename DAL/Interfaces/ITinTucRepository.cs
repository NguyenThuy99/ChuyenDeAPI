using Microsoft.TeamFoundation.SourceControl.WebApi;
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
        List<ItemModel> GetDataAll();
        List<ItemModel> Search(int pageIndex, int pageSize, out long total, string item_group_id);
    }
}
