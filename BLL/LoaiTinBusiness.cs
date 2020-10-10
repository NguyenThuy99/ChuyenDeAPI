
using DAL;
using DAL.Interfaces;
using Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace BLL
{
    public partial class LoaiTinBusiness : ILoaiTinBusiness
    {
        private ILoaiTinRepository _res;
        public LoaiTinBusiness(ILoaiTinRepository LoaiTinGroupRes)
        {
            ILoaiTinRepository loaiTinGroupRes = LoaiTinGroupRes;
            _res = loaiTinGroupRes;
        }

        public List<LoaiTin> GetData()
        {
            var allItemGroups = _res.GetData();
            var lstParent = allItemGroups.Where(ds => ds.parent_item_group_id == null).OrderBy(s => s.seq_num).ToList();
            foreach (var item in lstParent)
            {
                item.children = GetHiearchyList(allItemGroups, item);
            }
            return lstParent;
        }
        public List<LoaiTin> GetHiearchyList(List<LoaiTin> lstAll, LoaiTin node)
        {
            var lstChilds = lstAll.Where(ds => ds.parent_item_group_id == node.item_group_id).ToList();
            if (lstChilds.Count == 0)
                return null;
            for (int i = 0; i < lstChilds.Count; i++)
            {
                var childs = GetHiearchyList(lstAll, lstChilds[i]);
                lstChilds[i].type = (childs == null || childs.Count == 0) ? "leaf" : "";
                lstChilds[i].children = childs;
            }
            return lstChilds.OrderBy(s => s.seq_num).ToList();
        }

        List<LoaiTin> ILoaiTinBusiness.GetData()
        {
            throw new NotImplementedException();
        }
    }
}
